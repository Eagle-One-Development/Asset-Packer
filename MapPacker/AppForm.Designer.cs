
namespace MapPacker {
	partial class AppForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
			this.asset_textbox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.browse_asset = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.vpk_textbox = new System.Windows.Forms.TextBox();
			this.browse_vpk = new System.Windows.Forms.Button();
			this.browse_map = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.map_textbox = new System.Windows.Forms.TextBox();
			this.packAssets = new System.Windows.Forms.Button();
			this.consoleTextbox = new System.Windows.Forms.RichTextBox();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.label2 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.linkLabel2 = new System.Windows.Forms.LinkLabel();
			this.linkLabel3 = new System.Windows.Forms.LinkLabel();
			this.linkLabel4 = new System.Windows.Forms.LinkLabel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.SuspendLayout();
			// 
			// asset_textbox
			// 
			this.asset_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(68)))));
			this.asset_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.asset_textbox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.asset_textbox.ForeColor = System.Drawing.Color.DarkGray;
			this.asset_textbox.Location = new System.Drawing.Point(133, 42);
			this.asset_textbox.Multiline = true;
			this.asset_textbox.Name = "asset_textbox";
			this.asset_textbox.ReadOnly = true;
			this.asset_textbox.Size = new System.Drawing.Size(575, 18);
			this.asset_textbox.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
			this.label1.Location = new System.Drawing.Point(32, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Asset Directory:";
			// 
			// browse_asset
			// 
			this.browse_asset.ForeColor = System.Drawing.Color.LightGray;
			this.browse_asset.Location = new System.Drawing.Point(714, 40);
			this.browse_asset.Name = "browse_asset";
			this.browse_asset.Size = new System.Drawing.Size(75, 23);
			this.browse_asset.TabIndex = 2;
			this.browse_asset.Text = "Browse...";
			this.browse_asset.UseVisualStyleBackColor = true;
			this.browse_asset.Click += new System.EventHandler(this.browse_asset_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
			this.label3.Location = new System.Drawing.Point(32, 74);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 15);
			this.label3.TabIndex = 6;
			this.label3.Text = "s&&box Directory:";
			// 
			// vpk_textbox
			// 
			this.vpk_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(68)))));
			this.vpk_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.vpk_textbox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.vpk_textbox.ForeColor = System.Drawing.Color.DarkGray;
			this.vpk_textbox.Location = new System.Drawing.Point(133, 71);
			this.vpk_textbox.Multiline = true;
			this.vpk_textbox.Name = "vpk_textbox";
			this.vpk_textbox.ReadOnly = true;
			this.vpk_textbox.Size = new System.Drawing.Size(575, 18);
			this.vpk_textbox.TabIndex = 7;
			// 
			// browse_vpk
			// 
			this.browse_vpk.ForeColor = System.Drawing.Color.LightGray;
			this.browse_vpk.Location = new System.Drawing.Point(714, 70);
			this.browse_vpk.Name = "browse_vpk";
			this.browse_vpk.Size = new System.Drawing.Size(75, 23);
			this.browse_vpk.TabIndex = 8;
			this.browse_vpk.Text = "Browse...";
			this.browse_vpk.UseVisualStyleBackColor = true;
			this.browse_vpk.Click += new System.EventHandler(this.browse_vpk_Click);
			// 
			// browse_map
			// 
			this.browse_map.ForeColor = System.Drawing.Color.LightGray;
			this.browse_map.Location = new System.Drawing.Point(714, 11);
			this.browse_map.Name = "browse_map";
			this.browse_map.Size = new System.Drawing.Size(75, 23);
			this.browse_map.TabIndex = 11;
			this.browse_map.Text = "Browse...";
			this.browse_map.UseVisualStyleBackColor = true;
			this.browse_map.Click += new System.EventHandler(this.browse_map_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
			this.label4.Location = new System.Drawing.Point(32, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 15);
			this.label4.TabIndex = 10;
			this.label4.Text = "Vmap File:";
			// 
			// map_textbox
			// 
			this.map_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(68)))));
			this.map_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.map_textbox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.map_textbox.ForeColor = System.Drawing.Color.DarkGray;
			this.map_textbox.Location = new System.Drawing.Point(133, 13);
			this.map_textbox.Multiline = true;
			this.map_textbox.Name = "map_textbox";
			this.map_textbox.ReadOnly = true;
			this.map_textbox.Size = new System.Drawing.Size(575, 18);
			this.map_textbox.TabIndex = 9;
			// 
			// packAssets
			// 
			this.packAssets.AutoSize = true;
			this.packAssets.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.packAssets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
			this.packAssets.Location = new System.Drawing.Point(613, 398);
			this.packAssets.Name = "packAssets";
			this.packAssets.Size = new System.Drawing.Size(175, 49);
			this.packAssets.TabIndex = 12;
			this.packAssets.Text = "Pack Assets";
			this.packAssets.UseVisualStyleBackColor = true;
			this.packAssets.Click += new System.EventHandler(this.packAssets_Click);
			// 
			// consoleTextbox
			// 
			this.consoleTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(70)))), ((int)(((byte)(55)))));
			this.consoleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.consoleTextbox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.consoleTextbox.ForeColor = System.Drawing.Color.White;
			this.consoleTextbox.Location = new System.Drawing.Point(12, 99);
			this.consoleTextbox.Name = "consoleTextbox";
			this.consoleTextbox.ReadOnly = true;
			this.consoleTextbox.Size = new System.Drawing.Size(776, 293);
			this.consoleTextbox.TabIndex = 13;
			this.consoleTextbox.Text = "";
			// 
			// progressBar
			// 
			this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
			this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
			this.progressBar.Location = new System.Drawing.Point(12, 398);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(595, 23);
			this.progressBar.TabIndex = 14;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.DarkGray;
			this.label2.Location = new System.Drawing.Point(42, 431);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(127, 15);
			this.label2.TabIndex = 15;
			this.label2.Text = "Created by Eagle One";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 428);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(20, 20);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 16;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(12, 9);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(20, 23);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox2.TabIndex = 18;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(12, 40);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(20, 23);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox3.TabIndex = 19;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(12, 70);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(20, 23);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureBox4.TabIndex = 20;
			this.pictureBox4.TabStop = false;
			// 
			// linkLabel1
			// 
			this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel1.LinkColor = System.Drawing.Color.DarkGray;
			this.linkLabel1.Location = new System.Drawing.Point(277, 431);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(43, 15);
			this.linkLabel1.TabIndex = 21;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Github";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// linkLabel2
			// 
			this.linkLabel2.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel2.LinkColor = System.Drawing.Color.DarkGray;
			this.linkLabel2.Location = new System.Drawing.Point(326, 431);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new System.Drawing.Size(50, 15);
			this.linkLabel2.TabIndex = 22;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "Discord";
			this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
			// 
			// linkLabel3
			// 
			this.linkLabel3.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel3.AutoSize = true;
			this.linkLabel3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel3.LinkColor = System.Drawing.Color.DarkGray;
			this.linkLabel3.Location = new System.Drawing.Point(382, 431);
			this.linkLabel3.Name = "linkLabel3";
			this.linkLabel3.Size = new System.Drawing.Size(52, 15);
			this.linkLabel3.TabIndex = 23;
			this.linkLabel3.TabStop = true;
			this.linkLabel3.Text = "Website";
			this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
			// 
			// linkLabel4
			// 
			this.linkLabel4.ActiveLinkColor = System.Drawing.Color.White;
			this.linkLabel4.AutoSize = true;
			this.linkLabel4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.linkLabel4.LinkColor = System.Drawing.Color.DarkGray;
			this.linkLabel4.Location = new System.Drawing.Point(440, 431);
			this.linkLabel4.Name = "linkLabel4";
			this.linkLabel4.Size = new System.Drawing.Size(42, 15);
			this.linkLabel4.TabIndex = 24;
			this.linkLabel4.TabStop = true;
			this.linkLabel4.Text = "Twitter";
			this.linkLabel4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel4_LinkClicked);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox1.ForeColor = System.Drawing.Color.DarkGray;
			this.checkBox1.Location = new System.Drawing.Point(490, 429);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(120, 19);
			this.checkBox1.TabIndex = 25;
			this.checkBox1.Text = "Do NOT pack vpk";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// AppForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(88)))), ((int)(((byte)(68)))));
			this.ClientSize = new System.Drawing.Size(800, 455);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.linkLabel4);
			this.Controls.Add(this.linkLabel3);
			this.Controls.Add(this.linkLabel2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.pictureBox4);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.consoleTextbox);
			this.Controls.Add(this.packAssets);
			this.Controls.Add(this.browse_map);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.map_textbox);
			this.Controls.Add(this.browse_vpk);
			this.Controls.Add(this.vpk_textbox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.browse_asset);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.asset_textbox);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AppForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "s&box Map Asset Packer";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox asset_textbox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button browse_asset;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox vpk_textbox;
		private System.Windows.Forms.Button browse_vpk;
		private System.Windows.Forms.Button browse_map;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox map_textbox;
		private System.Windows.Forms.Button packAssets;
		private System.Windows.Forms.RichTextBox consoleTextbox;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.LinkLabel linkLabel2;
		private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.LinkLabel linkLabel4;
		private System.Windows.Forms.CheckBox checkBox1;
	}
}
