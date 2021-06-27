using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MapScrubber {
	public class AssetCleaner {

		public static HashSet<string> assets = new HashSet<string>();
		private static string assetPath;
		public string outputDirectory;
		private string vpkDirectory;
		private string vmapFile;



		public AssetCleaner(string a, string vp, string vm) {
			assetPath = a;
			vpkDirectory = vp;
			vmapFile = vm;
			outputDirectory = Path.GetDirectoryName(vmapFile) + "\\" + Path.GetFileNameWithoutExtension(vmapFile);
			Directory.CreateDirectory(outputDirectory);

		}

		public void GetAssets() {
			// path where the map is
			string pathToMap = vmapFile;

			Console.WriteLine($"reading map file: {pathToMap}");
			byte[] file = File.ReadAllBytes(pathToMap);
			AssetFile map = AssetFile.From(file);
			map.TrimAssetList(); // trim it to the space where assets are actually referenced, using "map_assets_references"

			foreach(var item in map.SplitNull()) {
				if(item.EndsWith("vmat")) {
					GetAssetsFromMaterial(item);
				}
				if(item.EndsWith("vmdl")) {
					GetAssetsFromModel(item);
				}
			}

			Console.WriteLine("Found assets:");
			foreach(var asset in assets) {
				Console.WriteLine($"\t{asset}");
			}

			CopyFiles();
		}


		public void PackVPK() {
			vpkDirectory += "\\bin\\win64\\vpk.exe";
			string command = @"""" + vmapFile.Replace(".vmap", ".vpk") + @"""";
			ExecuteCommandSync(command);


			command = @"""" + outputDirectory + @"""";
			ExecuteCommandSync(command);

			Directory.Delete(outputDirectory, true);
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
			} catch(ThreadStartException objException) {
				// Log the exception
			} catch(ThreadAbortException objException) {
				// Log the exception
			} catch(Exception objException) {
				// Log the exception
			}
		}

		public void ExecuteCommandSync(object command) {
			try {
				// create the ProcessStartInfo using "cmd" as the program to be run,
				// and "/c " as the parameters.
				// Incidentally, /c tells cmd that we want it to execute the command that follows,
				// and then exit.
				System.Diagnostics.ProcessStartInfo procStartInfo =
					new System.Diagnostics.ProcessStartInfo(vpkDirectory, "/c ");

				procStartInfo.Arguments = (string)command;
				// The following commands are needed to redirect the standard output.
				// This means that it will be redirected to the Process.StandardOutput StreamReader.
				procStartInfo.RedirectStandardOutput = true;
				procStartInfo.UseShellExecute = false;
				// Do not create the black window.
				procStartInfo.CreateNoWindow = true;
				// Now we create a process, assign its ProcessStartInfo and start it
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo = procStartInfo;
				proc.Start();
				// Get the output into a string
				string result = proc.StandardOutput.ReadToEnd();
				// Display the command output.
				Console.WriteLine(result);
			} catch(Exception objException) {
				// Log the exception
			}
		}

		public void CopyFiles() {
			foreach(string asset in assets) {


				string fileName = asset;

				if(!fileName.Contains(".vmat_c")) {
					fileName = fileName.Replace(".vmat", ".vmat_c");
				}

				if(!fileName.Contains(".vmdl_c")) {
					fileName = fileName.Replace(".vmdl", ".vmdl_c");
				}
				fileName = fileName.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
				fileName = fileName.Replace("/", "\\");

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

				} catch(DirectoryNotFoundException exception) {
					Console.WriteLine($"{source} cannot be copied to {destination} because the directory of the source file does not exist. \n Likely the file isn't in the provided asset directory. ");
				}
			}

			PackVPK();

		}

		public static void GetAssetsFromModel(string item) {
			try {
				var modelData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				assets.Add($"{item}_c"); // add vmdl_c
				var material = AssetFile.From(modelData);
				foreach(var matItem in material.SplitNull()) {
					if(matItem.EndsWith("vmat")) {
						AddAsset($"{matItem}_c"); // add vmat_c referenced by the vmdl_c
						GetAssetsFromMaterial(matItem); // add vtex_c referenced by the vmat_c
					}
				}
			} catch(Exception) {
				//Console.WriteLine($"{item}\t [NOT FOUND]");
			}
		}

		public static void GetAssetsFromMaterial(string item) {
			try {
				var materialData = File.ReadAllBytes($"{assetPath}\\{item}_c");
				assets.Add($"{item}_c"); // add vmat_c
				var material = AssetFile.From(materialData);
				foreach(var texItem in material.SplitNull()) {
					if(texItem.EndsWith("vtex")) {
						AddAsset($"{texItem}_c"); // add vtex_c referenced by the vmat_c
					}
				}
			} catch(Exception) {
				//Console.WriteLine($"{item}\t [NOT FOUND]");
			}
		}

		public static void AddAsset(string item) {
			// basic clean
			var asset = item.Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
			if(!(item.StartsWith("models") || item.StartsWith("materials") || item.StartsWith("textures")))
				return;
			assets.Add(asset);
		}
	}

	public class AssetFile {
		private string assetReference;
		public static AssetFile From(byte[] bytes) {
			AssetFile asset = new AssetFile();
			asset.assetReference = System.Text.Encoding.Default.GetString(bytes);
			return asset;
		}

		public string[] SplitNull() {
			string[] arr = { "\0" };
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

