namespace DetectNetworkChanges
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.pbDonateQRCode = new System.Windows.Forms.PictureBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.llCompany = new System.Windows.Forms.LinkLabel();
            this.llName = new System.Windows.Forms.LinkLabel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pbDonate = new System.Windows.Forms.PictureBox();
            this.btnSupportEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQRCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDonateQRCode
            // 
            this.pbDonateQRCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonateQRCode.Image = ((System.Drawing.Image)(resources.GetObject("pbDonateQRCode.Image")));
            this.pbDonateQRCode.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbDonateQRCode.InitialImage")));
            this.pbDonateQRCode.Location = new System.Drawing.Point(440, 88);
            this.pbDonateQRCode.Name = "pbDonateQRCode";
            this.pbDonateQRCode.Size = new System.Drawing.Size(100, 100);
            this.pbDonateQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDonateQRCode.TabIndex = 209;
            this.pbDonateQRCode.TabStop = false;
            this.pbDonateQRCode.Click += new System.EventHandler(this.pbDonateQRCode_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Location = new System.Drawing.Point(178, 160);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(245, 55);
            this.txtDescription.TabIndex = 208;
            // 
            // llCompany
            // 
            this.llCompany.AutoSize = true;
            this.llCompany.BackColor = System.Drawing.Color.Transparent;
            this.llCompany.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llCompany.Location = new System.Drawing.Point(256, 127);
            this.llCompany.Name = "llCompany";
            this.llCompany.Size = new System.Drawing.Size(51, 13);
            this.llCompany.TabIndex = 206;
            this.llCompany.TabStop = true;
            this.llCompany.Text = "Company";
            this.llCompany.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llCompany_LinkClicked);
            // 
            // llName
            // 
            this.llName.AutoSize = true;
            this.llName.BackColor = System.Drawing.Color.Transparent;
            this.llName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.llName.Location = new System.Drawing.Point(256, 12);
            this.llName.Name = "llName";
            this.llName.Size = new System.Drawing.Size(127, 13);
            this.llName.TabIndex = 205;
            this.llName.TabStop = true;
            this.llName.Text = "Detect Network Changes";
            this.llName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llName_LinkClicked);
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(256, 88);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(51, 13);
            this.lblCopyright.TabIndex = 204;
            this.lblCopyright.Text = "Copyright";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(256, 50);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 203;
            this.lblVersion.Text = "Version";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(178, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 202;
            this.label18.Text = "Company";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(178, 88);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 13);
            this.label19.TabIndex = 201;
            this.label19.Text = "Copyright";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(178, 50);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 200;
            this.label20.Text = "Version";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(178, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(75, 13);
            this.label21.TabIndex = 199;
            this.label21.Text = "Product Name";
            // 
            // pbIcon
            // 
            this.pbIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.BackgroundImage")));
            this.pbIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbIcon.ErrorImage = null;
            this.pbIcon.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbIcon.InitialImage")));
            this.pbIcon.Location = new System.Drawing.Point(12, 12);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(150, 150);
            this.pbIcon.TabIndex = 198;
            this.pbIcon.TabStop = false;
            // 
            // pbDonate
            // 
            this.pbDonate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDonate.Image = ((System.Drawing.Image)(resources.GetObject("pbDonate.Image")));
            this.pbDonate.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbDonate.InitialImage")));
            this.pbDonate.Location = new System.Drawing.Point(429, 12);
            this.pbDonate.Name = "pbDonate";
            this.pbDonate.Size = new System.Drawing.Size(121, 63);
            this.pbDonate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDonate.TabIndex = 207;
            this.pbDonate.TabStop = false;
            this.pbDonate.Click += new System.EventHandler(this.pbDonate_Click);
            // 
            // btnSupportEmail
            // 
            this.btnSupportEmail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSupportEmail.Location = new System.Drawing.Point(178, 226);
            this.btnSupportEmail.Name = "btnSupportEmail";
            this.btnSupportEmail.Size = new System.Drawing.Size(245, 23);
            this.btnSupportEmail.TabIndex = 210;
            this.btnSupportEmail.Text = "Questions / Feedback / Support";
            this.btnSupportEmail.UseVisualStyleBackColor = true;
            this.btnSupportEmail.Click += new System.EventHandler(this.btnSupportEmail_Click);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 257);
            this.Controls.Add(this.btnSupportEmail);
            this.Controls.Add(this.pbDonateQRCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.llCompany);
            this.Controls.Add(this.llName);
            this.Controls.Add(this.lblCopyright);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.pbDonate);
            this.Name = "frmAbout";
            this.Text = "About Detect Network Changes";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDonateQRCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDonate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbDonateQRCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.LinkLabel llCompany;
        private System.Windows.Forms.LinkLabel llName;
        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.PictureBox pbDonate;
        private System.Windows.Forms.Button btnSupportEmail;
    }
}