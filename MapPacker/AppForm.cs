using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Media;

namespace MapPacker {

	public partial class AppForm : Form {
		public AppForm() {
			InitializeComponent();
			TextWriter tmp = Console.Out; // Save the current console TextWriter. 
			StringRedir r = new StringRedir(ref consoleTextbox);
			Console.SetOut(r); // Set console output to the StringRedir class. 
			Console.WriteLine("s&box Map Asset Packer");
			Console.WriteLine("\nHow to Use:");
			Console.WriteLine("\t[+] Compile your map.");
			Console.WriteLine("\t[+] Make sure your vmap and compiled vpk are in the same directory.");
			Console.WriteLine("\t[+] Select your vmap, asset directory and sbox directory in the boxes above.");
			Console.WriteLine("\t[+] Click pack. The found and packed assets will be listed below.");
			Console.WriteLine("\n\t[+]In case you don't want to have your content packed, just check the box and it will instead appear in a folder called 'yourMap_content'.");
			Console.WriteLine("\nFor any additional help, contact 'DoctorGurke#0007' or 'Josh Wilson#9332' on discord or make an issue on the Github.");
		}

		public ProgressBar bar {
			get {
				return progressBar;
			}

			set {
				progressBar = value;
			}
		}

		public CheckBox packCheck {
			get {
				return checkBox1;
			}

			set {
				checkBox1 = value;
			}
		}

		private void browse_asset_Click(object sender, EventArgs e) {
			using(var openFileDialog = new CommonOpenFileDialog() { IsFolderPicker = true }) {
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Title = "Select your asset directory.";

				if(openFileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
					asset_textbox.Text = openFileDialog.FileName;
				}
			}
		}

		private void browse_map_Click(object sender, EventArgs e) {
			OpenFileDialog choofdlog = new OpenFileDialog();
			choofdlog.Filter = "Vmap Files (*.vmap*)|*.vmap*";
			choofdlog.FilterIndex = 1;
			choofdlog.Title = "Select your s&box vmap.";
			choofdlog.Multiselect = false;

			if(choofdlog.ShowDialog() == DialogResult.OK) {
				this.map_textbox.Text = choofdlog.FileName;
				string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
			}
		}

		private void browse_vpk_Click(object sender, EventArgs e) {
			using(var openFileDialog = new CommonOpenFileDialog() { IsFolderPicker = true }) {
				openFileDialog.RestoreDirectory = true;
				openFileDialog.Title = "Select your s&box directory.";

				if(openFileDialog.ShowDialog() == CommonFileDialogResult.Ok) {
					vpk_textbox.Text = openFileDialog.FileName;
				}
			}
		}

		private void packAssets_Click(object sender, EventArgs e) {
			var assetDir = asset_textbox.Text;
			var sboxDir = vpk_textbox.Text;
			var vmapFile = map_textbox.Text;

			if(!File.Exists(vmapFile)) {
				MessageBox.Show("Vmap file path invalid!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if(!Directory.Exists(assetDir)) {
				MessageBox.Show("Asset directory path invalid!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if(!Directory.Exists(sboxDir)) {
				MessageBox.Show("s&box directory path invalid!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			consoleTextbox.Clear();
			AssetCleaner cleaner = new AssetCleaner(assetDir, sboxDir, vmapFile);
			cleaner.parentForm = this;
			cleaner.GetAssets();
		}

		private void label2_Click(object sender, EventArgs e) {

		}

		private void pictureBox1_Click(object sender, EventArgs e) {

		}

		private void label5_Click(object sender, EventArgs e) {

		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://github.com/Eagle-One-Development/Asset-Packer");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://discord.com/invite/eagleonedevs");
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://eagleone.dev/");
		}

		private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("https://twitter.com/EagleOneDevs");
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e) {
			if(this.checkBox1.Checked) {
				packAssets.Text = "Move Assets";
			} else {
				packAssets.Text = "Pack Assets";
			}
		}
	}

	public class StringRedir : StringWriter {
		private RichTextBox outBox;

		public StringRedir(ref RichTextBox textBox) {
			outBox = textBox;
			outBox.SelectionStart = outBox.Text.Length;
			outBox.ScrollToCaret();
		}

		public override void WriteLine(string x) {
			outBox.Text += x + "\n";
			outBox.SelectionStart = outBox.Text.Length;
			outBox.ScrollToCaret();
			outBox.Refresh();
		}
	}
}
