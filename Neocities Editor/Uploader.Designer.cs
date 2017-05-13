namespace Neocities_Editor
{
    partial class Uploader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Uploader));
            this.upload = new System.Windows.Forms.Button();
            this.up_file = new System.Windows.Forms.TextBox();
            this.up_loc = new System.Windows.Forms.TextBox();
            this.cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // upload
            // 
            this.upload.Location = new System.Drawing.Point(201, 64);
            this.upload.Name = "upload";
            this.upload.Size = new System.Drawing.Size(74, 24);
            this.upload.TabIndex = 0;
            this.upload.Text = "Upload";
            this.upload.UseVisualStyleBackColor = true;
            this.upload.Click += new System.EventHandler(this.upload_Click);
            // 
            // up_file
            // 
            this.up_file.Location = new System.Drawing.Point(103, 12);
            this.up_file.Name = "up_file";
            this.up_file.ReadOnly = true;
            this.up_file.Size = new System.Drawing.Size(172, 20);
            this.up_file.TabIndex = 1;
            // 
            // up_loc
            // 
            this.up_loc.Location = new System.Drawing.Point(103, 38);
            this.up_loc.Name = "up_loc";
            this.up_loc.Size = new System.Drawing.Size(172, 20);
            this.up_loc.TabIndex = 2;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(121, 64);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(74, 24);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "File to Upload";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name/Location";
            // 
            // Uploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 98);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.up_loc);
            this.Controls.Add(this.up_file);
            this.Controls.Add(this.upload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Uploader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uploader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button upload;
        private System.Windows.Forms.TextBox up_file;
        private System.Windows.Forms.TextBox up_loc;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}