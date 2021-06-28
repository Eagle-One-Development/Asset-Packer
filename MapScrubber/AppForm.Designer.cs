
namespace MapScrubber {
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
            this.SuspendLayout();
            // 
            // asset_textbox
            // 
            this.asset_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
            this.asset_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.asset_textbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.asset_textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(170)))), ((int)(((byte)(148)))));
            this.asset_textbox.Location = new System.Drawing.Point(102, 35);
            this.asset_textbox.Name = "asset_textbox";
            this.asset_textbox.ReadOnly = true;
            this.asset_textbox.Size = new System.Drawing.Size(605, 14);
            this.asset_textbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asset Directory:";
            // 
            // browse_asset
            // 
            this.browse_asset.ForeColor = System.Drawing.Color.White;
            this.browse_asset.Location = new System.Drawing.Point(713, 32);
            this.browse_asset.Name = "browse_asset";
            this.browse_asset.Size = new System.Drawing.Size(75, 23);
            this.browse_asset.TabIndex = 2;
            this.browse_asset.Text = "Browse";
            this.browse_asset.UseVisualStyleBackColor = true;
            this.browse_asset.Click += new System.EventHandler(this.browse_asset_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "s&box Directory:";
            // 
            // vpk_textbox
            // 
            this.vpk_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
            this.vpk_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.vpk_textbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vpk_textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(170)))), ((int)(((byte)(148)))));
            this.vpk_textbox.Location = new System.Drawing.Point(102, 63);
            this.vpk_textbox.Name = "vpk_textbox";
            this.vpk_textbox.ReadOnly = true;
            this.vpk_textbox.Size = new System.Drawing.Size(605, 14);
            this.vpk_textbox.TabIndex = 7;
            // 
            // browse_vpk
            // 
            this.browse_vpk.ForeColor = System.Drawing.Color.White;
            this.browse_vpk.Location = new System.Drawing.Point(713, 61);
            this.browse_vpk.Name = "browse_vpk";
            this.browse_vpk.Size = new System.Drawing.Size(75, 23);
            this.browse_vpk.TabIndex = 8;
            this.browse_vpk.Text = "Browse";
            this.browse_vpk.UseVisualStyleBackColor = true;
            this.browse_vpk.Click += new System.EventHandler(this.browse_vpk_Click);
            // 
            // browse_map
            // 
            this.browse_map.ForeColor = System.Drawing.Color.White;
            this.browse_map.Location = new System.Drawing.Point(713, 3);
            this.browse_map.Name = "browse_map";
            this.browse_map.Size = new System.Drawing.Size(75, 23);
            this.browse_map.TabIndex = 11;
            this.browse_map.Text = "Browse";
            this.browse_map.UseVisualStyleBackColor = true;
            this.browse_map.Click += new System.EventHandler(this.browse_map_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vmap File:";
            // 
            // map_textbox
            // 
            this.map_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
            this.map_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.map_textbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.map_textbox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(170)))), ((int)(((byte)(148)))));
            this.map_textbox.Location = new System.Drawing.Point(102, 6);
            this.map_textbox.Name = "map_textbox";
            this.map_textbox.ReadOnly = true;
            this.map_textbox.Size = new System.Drawing.Size(605, 14);
            this.map_textbox.TabIndex = 9;
            // 
            // packAssets
            // 
            this.packAssets.AutoSize = true;
            this.packAssets.ForeColor = System.Drawing.Color.White;
            this.packAssets.Location = new System.Drawing.Point(293, 89);
            this.packAssets.Name = "packAssets";
            this.packAssets.Size = new System.Drawing.Size(201, 54);
            this.packAssets.TabIndex = 12;
            this.packAssets.Text = "Copy Assets And Pack Into VPK";
            this.packAssets.UseVisualStyleBackColor = true;
            this.packAssets.Click += new System.EventHandler(this.packAssets_Click);
            // 
            // consoleTextbox
            // 
            this.consoleTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
            this.consoleTextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleTextbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consoleTextbox.ForeColor = System.Drawing.Color.White;
            this.consoleTextbox.Location = new System.Drawing.Point(12, 149);
            this.consoleTextbox.Name = "consoleTextbox";
            this.consoleTextbox.ReadOnly = true;
            this.consoleTextbox.Size = new System.Drawing.Size(776, 266);
            this.consoleTextbox.TabIndex = 13;
            this.consoleTextbox.Text = "";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(69)))), ((int)(((byte)(49)))));
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(182)))), ((int)(((byte)(82)))));
            this.progressBar.Location = new System.Drawing.Point(12, 421);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 23);
            this.progressBar.TabIndex = 14;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(89)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AppForm";
            this.Text = "S&Box VPK Packer";
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
	}
}
