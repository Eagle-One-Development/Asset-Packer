using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace MapPacker {
	public class AssetCleaner {

		public static HashSet<string> assets = new HashSet<string>();
		private string assetPath;
		public string outputDirectory;
		private string vpkDirectory;
		private string vmapFile;
		public AppForm parentForm;

		public AssetCleaner(string assetDir, string sboxDir, string vmapFile) {
			this.assetPath = assetDir;
			this.vpkDirectory = sboxDir;
			this.vmapFile = vmapFile;
			outputDirectory = Path.GetDirectoryName(vmapFile) + "\\" + Path.GetFileNameWithoutExtension(vmapFile);
			Directory.CreateDirectory(outputDirectory);
		}

		public void GetAssets() {

			parentForm.bar.Value = 10;

			// path where the map is
			string pathToMap = vmapFile;

			Console.WriteLine($"reading map file: {pathToMap}");
			GetAssetsFromMap(pathToMap);

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
			Console.WriteLine("\nAsset pack completed.");
			MessageBox.Show("Map Successfully packed!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.None);
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
			
			if(parentForm.packCheck.Checked) {
				outputDirectory += "_content";
				Console.WriteLine("\nAssets moved: ");
			} else {
				Console.WriteLine("\nAssets packed: ");
			}

			int index = 0;
			foreach(string asset in assets) {
				index++;

				parentForm.bar.Value = 40 + 30 * (int)Math.Round(index / (float)assets.Count);

				string fileName = asset;
				try {
					string source = Path.Combine(assetPath, fileName);
					string destination = Path.Combine(outputDirectory, fileName);
					string directory = destination.Substring(0, destination.LastIndexOf("\\"));

					if(File.Exists(source)) {
						Directory.CreateDirectory(directory);
						File.Copy(source, destination, true);
						Console.WriteLine($"\t{asset}");
					} else {
						//Console.WriteLine($"{source} could not be found and was not copied");
						// asset is in core files, ignore
					}

				} catch {
					//Console.WriteLine($"{asset} could not be found or is missing");
					// asset not found, broken or otherwise defunct, ignore
				}
			}
			if(!parentForm.packCheck.Checked) {
				PackVPK();
			} else {
				SoundPlayer player = new SoundPlayer(Properties.Resources.steam_message);
				parentForm.bar.Value = 0;
				Console.WriteLine("\nAsset move completed.");
				MessageBox.Show("Content successfully moved!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.None);
			}
		}

		public void GetAssetsFromMap(string map) { // this uses a full path, since it's kinda for the original map
			try {
				var mapData = File.ReadAllBytes($"{map}");
				AssetFile mapFile = AssetFile.From(mapData);
				mapFile.TrimAssetList(); // trim it to the space where assets are actually referenced, using "map_assets_references" markers

				foreach(var item in mapFile.SplitNull()) {
					if(item.EndsWith("vmat")) {
						GetAssetsFromMaterial(item);
					} else if(item.EndsWith("vmdl")) {
						GetAssetsFromModel(item);
					} else if(item.EndsWith("vpcf")) {
						GetAssetsFromParticle(item);
					} else if(item.EndsWith("vmap")) {
						var mapItem = CleanAssetPath(item);
						var path = TrimAddonPath(map);
						if(!($"{path}\\{item}" == map)) {
							GetAssetsFromMap($"{path}\\{item}"); // we can assume that prefabs will also be wherever the original map is
							GetAssetsFromMap($"{assetPath}\\{item}"); // prefabs *could* also be in the asset directory however
						}
					}
				}
			} catch {
				// asset not in asset directory or not found
			}
		}

		public void GetAssetsFromModel(string item) {
			try {
				var modelData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				AddAsset(item); // add vmdl_c
				var material = AssetFile.From(modelData);
				foreach(var matItem in material.SplitNull()) {
					if(matItem.EndsWith("vmat")) {
						AddAsset(matItem); // add vmat_c referenced by the vmdl_c
						GetAssetsFromMaterial(matItem); // add vtex_c referenced by the vmat_c
					} else if (matItem.EndsWith("vmesh")) { // LEGACY IMPORT SUPPORT
						AddAsset(matItem); // add vmesh_c referenced by the vmdl_c
						GetAssetsFromModel(matItem); // add vmat_c referenced by the vmesh_c
					} else if (matItem.EndsWith("vphys")) {
						AddAsset(matItem); // add vphys_c referenced by a vmesh_c
					}
				}
			} catch {
				// asset not in asset directory or not found
			}
		}

		public void GetAssetsFromMaterial(string item) {
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

		public void GetAssetsFromParticle(string item) {
			try {
				var materialData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				AddAsset(item); // add vpcf_c
				var material = AssetFile.From(materialData);
				foreach(var assetItem in material.SplitNull()) {
					if(assetItem.EndsWith("vtex")) {
						AddAsset(assetItem); // add vtex_c referenced by the vpcf_c
					} else if (assetItem.EndsWith("vmat")) {
						GetAssetsFromMaterial(assetItem);
					} else if(assetItem.EndsWith("vmdl")) {
						GetAssetsFromModel(assetItem);
					} else if(assetItem.EndsWith("vpcf")) {
						if(!(item == assetItem)) // if there's a self reference in the particle for some reason
							GetAssetsFromParticle(assetItem);
					}
				}
			} catch {
				// asset not in asset directory or not found
			}
		}

		public static void AddAsset(string item) {
			// basic clean
			var asset = CleanAssetPath(item);

			if(!(asset.EndsWith("_c"))) {
				// make sure the file is an asset file as we'd want it
				return;
			}
			assets.Add(asset);
		}

		public static string CleanAssetPath(string item) {
			var asset = item.Replace("\r\n", "").Replace("\r", "").Replace("\n", "").Replace("/", "\\");

			if(asset.EndsWith("vmat")) {
				asset = asset.Replace(".vmat", ".vmat_c");
			} else if(asset.EndsWith("vmdl")) {
				asset = asset.Replace(".vmdl", ".vmdl_c");
			} else if(asset.EndsWith("vtex")) {
				asset = asset.Replace(".vtex", ".vtex_c");
			} else if (asset.EndsWith("vpcf")) {
				asset = asset.Replace(".vpcf", ".vpcf_c");
			} else if(asset.EndsWith("vsnd")) {
				asset = asset.Replace(".vsnd", ".vsnd_c");
			} else if(asset.EndsWith("vphys")) {
				asset = asset.Replace(".vphys", ".vphys_c");
			} else if(asset.EndsWith("vmesh")) {
				asset = asset.Replace(".vmesh", ".vmesh_c");
			}
			return asset;
		}

		public static string TrimAddonPath(string path) {
			// trim full path to addons/addonName/
			var addonsIndex = path.LastIndexOf("addons");
			var trim1 = path.Substring(0, addonsIndex + 7);
			var trim2 = path.Substring(addonsIndex + 7, path.Length - addonsIndex - 7);
			var addonName = trim2.Substring(0, trim2.IndexOf("\\"));
			return trim1 + addonName;
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

		public bool IsMapSkybox() {
			var splitStrings = this.SplitNull();

			for(var i = 0; i < splitStrings.Length; i++) {
				var item = splitStrings[i];
				if(item == "mapUsageType") {
					if(splitStrings[i + 1] == "skybox") { // skybox map type
						return true;
					}
				}
			}
			return false;
		}
	}
}

