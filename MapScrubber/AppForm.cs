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

namespace MapScrubber
{

    


    public partial class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            TextWriter tmp = Console.Out; // Save the current console TextWriter. 
            StringRedir r = new StringRedir(ref consoleTextbox);
            Console.SetOut(r); // Set console output to the StringRedir class. 
            

        }



        private void browse_asset_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new CommonOpenFileDialog() { IsFolderPicker = true })
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Your Asset Directory";

                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    asset_textbox.Text = openFileDialog.FileName;
                }
            }

        }

        private void browse_map_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "VMAP Files (*.vmap*)|*.vmap*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;
            

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                this.map_textbox.Text = choofdlog.FileName;
                string[] arrAllFiles = choofdlog.FileNames; //used when Multiselect = true
            }
        }

        private void browse_vpk_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new CommonOpenFileDialog() { IsFolderPicker = true })
            {
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Select Your S&box Directory";

                if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    vpk_textbox.Text = openFileDialog.FileName;
                }
            }
        }

        private void packAssets_Click(object sender, EventArgs e)
        {
            consoleTextbox.Clear();
            AssetCleaner cleaner = new AssetCleaner(asset_textbox.Text,vpk_textbox.Text,map_textbox.Text);
            cleaner.GetAssets();
        }
    }

    public class StringRedir : StringWriter
    {
        private RichTextBox outBox;

        public StringRedir(ref RichTextBox textBox)
        {
            outBox = textBox;
        }

        public override void WriteLine(string x)
        {
            outBox.Text += x + "\n";
            outBox.Refresh();
        }
    }
}
