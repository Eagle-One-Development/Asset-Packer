using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace MapScrubber {
	public class AssetCleaner {

		public static HashSet<string> assets = new HashSet<string>();
		private static string assetPath;
		public string outputDirectory;
		private string vpkDirectory;
		private string vmapFile;
		public AppForm parentForm;

		public AssetCleaner(string a, string vp, string vm) {
			assetPath = a;
			vpkDirectory = vp;
			vmapFile = vm;
			outputDirectory = Path.GetDirectoryName(vmapFile) + "\\" + Path.GetFileNameWithoutExtension(vmapFile);
			Directory.CreateDirectory(outputDirectory);
		}

		public void GetAssets() {

			parentForm.bar.Value = 10;

			// path where the map is
			string pathToMap = vmapFile;

			Console.WriteLine($"reading map file: {pathToMap}");
			byte[] file = File.ReadAllBytes(pathToMap);
			AssetFile map = AssetFile.From(file);
			map.TrimAssetList(); // trim it to the space where assets are actually referenced, using "map_assets_references" markers

			foreach(var item in map.SplitNull()) {
				if(item.EndsWith("vmat")) {
					GetAssetsFromMaterial(item);
				}
				if(item.EndsWith("vmdl")) {
					GetAssetsFromModel(item);
				}
			}

			parentForm.bar.Value = 30;

			if(assets.Count > 0) {
				Console.WriteLine("Found assets:");
			} else {
				Console.WriteLine("No assets found!");
				parentForm.bar.Value = 0;
				MessageBox.Show("No assets could be found!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			foreach(string asset in assets) {
				Console.WriteLine($"\t{asset}");
			}

			parentForm.bar.Value = 40;
			CopyFiles();
		}

		public void PackVPK() {
			vpkDirectory += "\\bin\\win64\\vpk.exe";
			
			//execute vpk file.vpk to extract
			string command = @"""" + vmapFile.Replace(".vmap", ".vpk") + @"""";
			ExecuteCommandSync(command);
			parentForm.bar.Value = 95;

			// execute vpk outputDirectory to repack
			command = @"""" + outputDirectory + @"""";
			ExecuteCommandSync(command);
			parentForm.bar.Value = 0;

			// delete temp directory
			Directory.Delete(outputDirectory, true);

			SoundPlayer player = new SoundPlayer(Properties.Resources.steam_message);
			player.Play();
			Console.WriteLine("Asset pack completed.");
			MessageBox.Show("VPK Successfully Completed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public void ExecuteCommandAsync(string command) {
			try {
				//Asynchronously start the Thread to process the Execute command request.
				Thread objThread = new Thread(new ParameterizedThreadStart(ExecuteCommandSync));
				//Make the thread as background thread.
				objThread.IsBackground = true;
				//Set the Priority of the thread.
				objThread.Priority = ThreadPriority.AboveNormal;
				//Start the thread.
				objThread.Start(command);
			} catch {
				// Log the exception
			}
		}

		public void ExecuteCommandSync(object command) {
			try {
				System.Diagnostics.ProcessStartInfo procStartInfo =
					_ = new System.Diagnostics.ProcessStartInfo(vpkDirectory, "/c ");

				procStartInfo.Arguments = (string)command;
				procStartInfo.RedirectStandardOutput = true;
				procStartInfo.UseShellExecute = false;
				procStartInfo.CreateNoWindow = true;
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo = procStartInfo;
				proc.Start();
				// Get the output into a string
				string result = proc.StandardOutput.ReadToEnd();
				// Display the command output.
				//Console.WriteLine(result);
			} catch {
				// Log the exception
			}
		}

		public void CopyFiles() {

			int index = 0;
			foreach(string asset in assets) {
				index++;

				parentForm.bar.Value = 40 + 30 * (int)Math.Round(index / (float)assets.Count);

				string fileName = asset;

				string source = Path.Combine(assetPath, fileName);
				string destination = Path.Combine(outputDirectory, fileName);
				string directory = destination.Substring(0, destination.LastIndexOf("\\"));

				try {
					if(File.Exists(source)) {
						Directory.CreateDirectory(directory);
						File.Copy(source, destination, true);
					} else {
						Console.WriteLine($"{source} could not be found and was not copied");
					}

				} catch(DirectoryNotFoundException) {
					Console.WriteLine($"{asset} could not be found in your asset directory.");
				}
			}
			PackVPK();
		}

		public static void GetAssetsFromModel(string item) {
			try {
				var modelData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				AddAsset(item); // add vmdl_c
				var material = AssetFile.From(modelData);
				foreach(var matItem in material.SplitNull()) {
					if(matItem.EndsWith("vmat")) {
						AddAsset(matItem); // add vmat_c referenced by the vmdl_c
						GetAssetsFromMaterial(matItem); // add vtex_c referenced by the vmat_c
					}
				}
			} catch {
				// asset not in asset directory or not found
			}
		}

		public static void GetAssetsFromMaterial(string item) {
			try {
				var materialData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				AddAsset(item); // add vmat_c
				var material = AssetFile.From(materialData);
				foreach(var texItem in material.SplitNull()) {
					if(texItem.EndsWith("vtex")) {
						AddAsset(texItem); // add vtex_c referenced by the vmat_c
					}
				}
			} catch {
				// asset not in asset directory or not found
			}
		}

		public static void AddAsset(string item) {
			// basic clean
			var asset = item.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("/", "\\");

			// compiled formats
			if(asset.EndsWith("vmat")) {
				asset = asset.Replace(".vmat", ".vmat_c");
			} else if(asset.EndsWith("vmdl")) {
				asset = asset.Replace(".vmdl", ".vmdl_c");
			} else if(asset.EndsWith("vtex")) {
				asset = asset.Replace(".vtex", ".vtex_c");
			}

			if(!(asset.StartsWith("models") || asset.StartsWith("materials") || asset.StartsWith("textures") && asset.EndsWith("_c"))) {
				// make sure the file is an asset file as we'd want it
				return;
			}
			assets.Add(asset);
		}
	}

	public class AssetFile {
		private string assetReference;
		public static AssetFile From(byte[] bytes) {
			AssetFile asset = new AssetFile();
			asset.assetReference = Encoding.Default.GetString(bytes);
			return asset;
		}

		public string[] SplitNull() {
			string[] arr = { "\0" }; // lol why doesn't this have an overload for strings
			return assetReference.Split(arr, StringSplitOptions.RemoveEmptyEntries);
		}

		public string TrimAssetList(string marker = "map_asset_references") {
			var start = assetReference.IndexOf(marker);
			var end = assetReference.LastIndexOf(marker);
			var output = assetReference.Substring(start, end - start);
			return output;
		}
	}
}

