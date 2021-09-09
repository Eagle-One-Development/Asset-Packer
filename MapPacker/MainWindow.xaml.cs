using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Collections.Generic;

namespace MapPacker {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		private RichTextBox ConsoleOutput;
		private ProgressBar _ProgressBar;
		public CheckBox PackCheckBox;
		private bool _PackCheck = true;
		public bool Packing = false;

		public double Progress {
			get {
				return _ProgressBar.Value;
			}
		}

		public bool Pack {
			get {
				return _PackCheck;
			}
		}

		public void SetProgress(float progress) {
			Application.Current.Dispatcher.Invoke(() => {
				_ProgressBar.Value = progress;
			});
		}

		private Dictionary<string, string> dictionary;

		public MainWindow() {
			InitializeComponent();
			_ProgressBar = (ProgressBar)this.FindName("ProgressBar");
			ConsoleOutput = (RichTextBox)this.FindName("ConsoleOutputText");
			PackCheckBox = (CheckBox)this.FindName("PackCheck");

			string[] args = System.Environment.GetCommandLineArgs();

			if(args.Length >= 3) { // cli args come in groups of two. first arg is always the source executing the program
				dictionary = new();

				for(int index = 1; index < args.Length; index += 2) {
					dictionary.Add(args[index], args[index + 1]);
				}

				//PrintToConsole($"args");
				bool sbox = false;
				bool vmap = false;
				bool assets = false;

				bool pack = true;
				bool pause = false;

				string sboxPath = "";
				string vmapPath = "";
				string assetsPath = "";

				PrintToConsole("MapPacker CLI usage");

				string value;
				if(dictionary.TryGetValue("-sbox", out value)) {
					PrintToConsole($"\n-sbox: {value}");
					if(!Directory.Exists(value)) {
						PrintToConsole("INVALID PATH");
					} else {
						PrintToConsole("VALID");
						var box = (RichTextBox)this.FindName("sboxLocation");
						box.Document.Blocks.Clear();
						box.Document.Blocks.Add(new Paragraph(new Run(value)));
						sboxPath = value;
						sbox = true;
					}
				}
				if(dictionary.TryGetValue("-vmap", out value)) {
					PrintToConsole($"\n-vmap: {value}");
					if(!File.Exists(value)) {
						PrintToConsole("INVALID PATH");
					} else {
						PrintToConsole("VALID");
						var box = (RichTextBox)this.FindName("vmapLocation");
						box.Document.Blocks.Clear();
						box.Document.Blocks.Add(new Paragraph(new Run(value)));
						vmapPath = value;
						vmap = true;
					}
				}
				if(dictionary.TryGetValue("-assets", out value)) {
					PrintToConsole($"\n-assets: {value}");
					if(!Directory.Exists(value)) {
						PrintToConsole("INVALID PATH");
					} else {
						PrintToConsole("VALID");
						var box = (RichTextBox)this.FindName("assetLocation");
						box.Document.Blocks.Clear();
						box.Document.Blocks.Add(new Paragraph(new Run(value)));
						assetsPath = value;
						assets = true;
					}
				}
				if(dictionary.TryGetValue("-pause", out value)) {
					if(bool.Parse(value))
						pause = true;
				}
				if(dictionary.TryGetValue("-pack", out value)) {
					if(!bool.Parse(value)) {
						PackCheckBox.IsEnabled = true;
						pack = false;
					}
				}

				if(sbox && vmap && assets) { // all main params valid
					PrintToConsole("\nAll parameters valid, continuing...\n");
					_PackCheck = pack;
					AssetPacker AssetPacker = new AssetPacker(assetsPath, sboxPath, vmapPath);
					AssetPacker.parentForm = this;
					if(pause)
						new Thread(AssetPacker.GetAssets).Start();
					else
						AssetPacker.GetAssets(true);

					if(!pause) {
						Close();
						return;
					}
				} else {
					PrintToConsole("\nNot enough valid parameters to continue!");
					if(!pause) {
						Close();
						return;
					}
				}

			} else {
				PrintToConsole("Welcome to the Eagle One Asset Packer!");
				PrintToConsole("\n\tHow to Use:");
				PrintToConsole("\n\t[+] Compile your map.");
				PrintToConsole("\t[+] Make sure your vmap and compiled vpk are in the same directory.");
				PrintToConsole("\t[+] Select your vmap, asset directory and sbox directory in the boxes above.");
				PrintToConsole("\t[+] Click pack. The found and packed assets will be listed below.");
				PrintToConsole("\n\t[+] In case you don't want to have your content packed, just check the box and it will instead appear in a folder called 'yourMap_content'.");
				PrintToConsole("\nFor any additional help, contact 'DoctorGurke#0007' or 'Josh Wilson#9332' on discord or make an issue on the Github.");
			}
		}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

		private void CloseButton_Click(object sender, RoutedEventArgs e) {
			Close();
		} 

		private void MinimizeButton_Click(object sender, RoutedEventArgs e) {
			WindowState = WindowState.Minimized;
		}

		private void LinkLabel_Click(object sender, RoutedEventArgs e) {
			Hyperlink source = sender as Hyperlink;

			if(source != null) {

				Process.Start(new ProcessStartInfo("cmd", $"/c start {source.NavigateUri}") { CreateNoWindow = true });
			}
		}

		private void OpenVmapExplorer(object sender, RoutedEventArgs e) {
			var dialog = new Microsoft.Win32.OpenFileDialog();
			dialog.FileName = ""; // Default file name
			dialog.DefaultExt = ".vmap"; // Default file extension
			dialog.Filter = "Source 2 Map File (.vmap)|*.vmap"; // Filter files by extension
			dialog.Title = "Select your vmap File";

			// Show open file dialog box
			bool? result = dialog.ShowDialog();

			// Process open file dialog box results
			if(result == true) {
				// Open document
				string filename = dialog.FileName;
				var myTextBlock = (RichTextBox)this.FindName("vmapLocation");
				if(myTextBlock != null) {
					myTextBlock.Document.Blocks.Clear();
					myTextBlock.Document.Blocks.Add(new Paragraph(new Run(filename)));
				}
			}
		}

		private void OpenAssetExplorer(object sender, RoutedEventArgs e) {
			using(var dialog = new System.Windows.Forms.FolderBrowserDialog()) {
				dialog.Description = "Select your Asset Directory";
				dialog.UseDescriptionForTitle = true;

				System.Windows.Forms.DialogResult result = dialog.ShowDialog();

				var myTextBlock = (RichTextBox)this.FindName("assetLocation");
				if(myTextBlock != null && result.ToString() == "OK") {
					myTextBlock.Document.Blocks.Clear();
					myTextBlock.Document.Blocks.Add(new Paragraph(new Run(dialog.SelectedPath)));
				}
			}
		}

		private void OpenSboxExplorer(object sender, RoutedEventArgs e) {
			using(var dialog = new System.Windows.Forms.FolderBrowserDialog()) {
				dialog.Description = "Select your s&box Directory";
				dialog.UseDescriptionForTitle = true;

				System.Windows.Forms.DialogResult result = dialog.ShowDialog();

				var myTextBlock = (RichTextBox)this.FindName("sboxLocation");
				if(myTextBlock != null && result.ToString() == "OK") {
					myTextBlock.Document.Blocks.Clear();
					myTextBlock.Document.Blocks.Add(new Paragraph(new Run(dialog.SelectedPath)));
				}
			}
		}

		public void SetCheckBoxEnabled(bool state) {
			Application.Current.Dispatcher.Invoke(() => {
				PackCheckBox.IsEnabled = state;
			});
		}

		public void PrintToConsole(string text) {
			Application.Current.Dispatcher.Invoke(() => {
				ConsoleOutput.Document.Blocks.Add(new Paragraph(new Run(text)));
				ConsoleOutput.ScrollToEnd();
			});
		}

		public void PrintToConsole(string text, string resource) {
			// this is dumb
			Application.Current.Dispatcher.Invoke(() => {
				var paragraph = new Paragraph(new Run(text));
				var style = new Style(typeof(Paragraph));
				var foregroundSetter = new Setter(ForegroundProperty, TryFindResource(resource)); // apply Foreground setter with resource
				style.Setters.Add(foregroundSetter); // add setter to style
				paragraph.Margin = new Thickness(0); // readd margin override
				paragraph.Style = style; // add style to paragraph
				ConsoleOutput.Document.Blocks.Add(paragraph); // send paragraph to richtextbox
				ConsoleOutput.ScrollToEnd(); // scroll down
			});
		}

		private void ConfirmButton_Click(object sender, RoutedEventArgs e) {
			
			var text = (RichTextBox)this.FindName("vmapLocation");
			string vmapFile = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text.Replace("\r\n", "");
			if(!File.Exists(vmapFile)) {
				MessageBox.Show("Vmap file path invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			
			text = (RichTextBox)this.FindName("assetLocation");
			string assetDir = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text.Replace("\r\n", "");
			if(!Directory.Exists(assetDir)) {
				MessageBox.Show("Asset Directory path invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}
			
			text = (RichTextBox)this.FindName("sboxLocation");
			string sboxDir = new TextRange(text.Document.ContentStart, text.Document.ContentEnd).Text.Replace("\r\n", "");
			if(!Directory.Exists(sboxDir) || !File.Exists($"{sboxDir}\\sbox.exe")) {
				MessageBox.Show("s&box Directory path invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
				return;
			}

			ConsoleOutput.Document.Blocks.Clear();

			Packing = true;
			SetCheckBoxEnabled(false);
			AssetPacker AssetPacker = new AssetPacker(assetDir, sboxDir, vmapFile);
			AssetPacker.parentForm = this;
			new Thread(AssetPacker.GetAssets).Start();
		}

		private void PackCheck_Checked(object sender, RoutedEventArgs e) {
			//ConfirmButton
			var button = (Button)this.FindName("ConfirmButton");
			button.Content = "Copy Assets";
			_PackCheck = false;
			//PrintToConsole($"check changed to {(sender as CheckBox).IsChecked}", "steam2004ControlText");
		}

		private void PackCheck_Unchecked(object sender, RoutedEventArgs e) {
			var button = (Button)this.FindName("ConfirmButton");
			button.Content = "Pack Assets";
			_PackCheck = true;
			//PrintToConsole($"\tcheck changed to {(sender as CheckBox).IsChecked}");
		}
	}
}
