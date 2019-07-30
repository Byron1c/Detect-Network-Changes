namespace DetectNetworkChanges
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.numCheckSecs = new System.Windows.Forms.NumericUpDown();
            this.cbNetwork = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDetails = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLinkSpeed = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblConnectedToInternet = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblConnected = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblLastChecked = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.lblAdapterName = new System.Windows.Forms.Label();
            this.lblNetName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetNetwork = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbShowBalloon = new System.Windows.Forms.CheckBox();
            this.cbShowPopup = new System.Windows.Forms.CheckBox();
            this.cbStartMinimised = new System.Windows.Forms.CheckBox();
            this.cbAutoStart = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.numLinkSpeedMin = new System.Windows.Forms.NumericUpDown();
            this.lblUpdateAvailable = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbPlaySound = new System.Windows.Forms.CheckBox();
            this.cbCheckLinkSpeed = new System.Windows.Forms.CheckBox();
            this.lblWarn = new System.Windows.Forms.Label();
            this.lblMbps = new System.Windows.Forms.Label();
            this.soundPlayer1 = new Strangetimez.SoundPlayer();
            this.enableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.disableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbEnabled = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numCheckSecs)).BeginInit();
            this.pnlDetails.SuspendLayout();
            this.cmNotify.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkSpeedMin)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 5000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check Secs";
            // 
            // numCheckSecs
            // 
            this.numCheckSecs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numCheckSecs.Location = new System.Drawing.Point(83, 88);
            this.numCheckSecs.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numCheckSecs.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numCheckSecs.Name = "numCheckSecs";
            this.numCheckSecs.Size = new System.Drawing.Size(51, 20);
            this.numCheckSecs.TabIndex = 2;
            this.toolTip1.SetToolTip(this.numCheckSecs, "How often to check");
            this.numCheckSecs.Value = new decimal(new int[] {
            299,
            0,
            0,
            0});
            this.numCheckSecs.ValueChanged += new System.EventHandler(this.numCheckSecs_ValueChanged);
            // 
            // cbNetwork
            // 
            this.cbNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbNetwork.FormattingEnabled = true;
            this.cbNetwork.Location = new System.Drawing.Point(83, 58);
            this.cbNetwork.Name = "cbNetwork";
            this.cbNetwork.Size = new System.Drawing.Size(223, 21);
            this.cbNetwork.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cbNetwork, "Selected network to monitor / check");
            this.cbNetwork.SelectedIndexChanged += new System.EventHandler(this.cbNetwork_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Network";
            // 
            // pnlDetails
            // 
            this.pnlDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetails.Controls.Add(this.label6);
            this.pnlDetails.Controls.Add(this.lblLinkSpeed);
            this.pnlDetails.Controls.Add(this.btnRefresh);
            this.pnlDetails.Controls.Add(this.label8);
            this.pnlDetails.Controls.Add(this.lblConnectedToInternet);
            this.pnlDetails.Controls.Add(this.label9);
            this.pnlDetails.Controls.Add(this.lblConnected);
            this.pnlDetails.Controls.Add(this.label7);
            this.pnlDetails.Controls.Add(this.lblIPAddress);
            this.pnlDetails.Controls.Add(this.lblAdapterName);
            this.pnlDetails.Controls.Add(this.lblNetName);
            this.pnlDetails.Controls.Add(this.label5);
            this.pnlDetails.Controls.Add(this.label4);
            this.pnlDetails.Controls.Add(this.label3);
            this.pnlDetails.Controls.Add(this.lblState);
            this.pnlDetails.Controls.Add(this.lblLastChecked);
            this.pnlDetails.Location = new System.Drawing.Point(12, 196);
            this.pnlDetails.Name = "pnlDetails";
            this.pnlDetails.Size = new System.Drawing.Size(294, 162);
            this.pnlDetails.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(115, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Mbps";
            // 
            // lblLinkSpeed
            // 
            this.lblLinkSpeed.AutoSize = true;
            this.lblLinkSpeed.Location = new System.Drawing.Point(78, 110);
            this.lblLinkSpeed.Name = "lblLinkSpeed";
            this.lblLinkSpeed.Size = new System.Drawing.Size(31, 13);
            this.lblLinkSpeed.TabIndex = 19;
            this.lblLinkSpeed.Text = "9999";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Link Speed";
            // 
            // lblConnectedToInternet
            // 
            this.lblConnectedToInternet.AutoSize = true;
            this.lblConnectedToInternet.Location = new System.Drawing.Point(256, 60);
            this.lblConnectedToInternet.Name = "lblConnectedToInternet";
            this.lblConnectedToInternet.Size = new System.Drawing.Size(21, 13);
            this.lblConnectedToInternet.TabIndex = 17;
            this.lblConnectedToInternet.Text = "No";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(119, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Connected to Internet";
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(78, 60);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(21, 13);
            this.lblConnected.TabIndex = 15;
            this.lblConnected.Text = "No";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Connected";
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Webdings", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblState.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblState.Location = new System.Drawing.Point(216, 95);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(92, 65);
            this.lblState.TabIndex = 13;
            this.lblState.Text = "r";
            this.toolTip1.SetToolTip(this.lblState, "Shows the network state.\r\nTick = no changes\r\nCross = changes found");
            // 
            // lblLastChecked
            // 
            this.lblLastChecked.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLastChecked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastChecked.Location = new System.Drawing.Point(0, 143);
            this.lblLastChecked.Name = "lblLastChecked";
            this.lblLastChecked.Padding = new System.Windows.Forms.Padding(2);
            this.lblLastChecked.Size = new System.Drawing.Size(292, 17);
            this.lblLastChecked.TabIndex = 12;
            this.lblLastChecked.Text = "00:00:00";
            this.lblLastChecked.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(78, 85);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(55, 13);
            this.lblIPAddress.TabIndex = 11;
            this.lblIPAddress.Text = "IPAddress";
            // 
            // lblAdapterName
            // 
            this.lblAdapterName.AutoSize = true;
            this.lblAdapterName.BackColor = System.Drawing.Color.Transparent;
            this.lblAdapterName.Location = new System.Drawing.Point(78, 35);
            this.lblAdapterName.Name = "lblAdapterName";
            this.lblAdapterName.Size = new System.Drawing.Size(72, 13);
            this.lblAdapterName.TabIndex = 10;
            this.lblAdapterName.Text = "AdapterName";
            // 
            // lblNetName
            // 
            this.lblNetName.AutoSize = true;
            this.lblNetName.Location = new System.Drawing.Point(78, 10);
            this.lblNetName.Name = "lblNetName";
            this.lblNetName.Size = new System.Drawing.Size(75, 13);
            this.lblNetName.TabIndex = 9;
            this.lblNetName.Text = "NetworkName";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "IPAddress";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Adapter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Network";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cmNotify;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Detect Network Changes";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmNotify
            // 
            this.cmNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableToolStripMenuItem,
            this.disableToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.cmNotify.Name = "cmNotify";
            this.cmNotify.Size = new System.Drawing.Size(113, 76);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.quitToolStripMenuItem.Text = "E&xit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // btnSetNetwork
            // 
            this.btnSetNetwork.Enabled = false;
            this.btnSetNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetNetwork.Location = new System.Drawing.Point(208, 85);
            this.btnSetNetwork.Name = "btnSetNetwork";
            this.btnSetNetwork.Size = new System.Drawing.Size(97, 23);
            this.btnSetNetwork.TabIndex = 6;
            this.btnSetNetwork.Text = "Set Network Info";
            this.toolTip1.SetToolTip(this.btnSetNetwork, "Press to set the chosen network to be the one monitored");
            this.btnSetNetwork.UseVisualStyleBackColor = true;
            this.btnSetNetwork.Click += new System.EventHandler(this.btnSetNetwork_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(318, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.resetSettingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.checkForUpdateToolStripMenuItem.Text = "&Check for Update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // resetSettingsToolStripMenuItem
            // 
            this.resetSettingsToolStripMenuItem.Name = "resetSettingsToolStripMenuItem";
            this.resetSettingsToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.resetSettingsToolStripMenuItem.Text = "&Reset Settings";
            this.resetSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(163, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cbShowBalloon
            // 
            this.cbShowBalloon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowBalloon.AutoSize = true;
            this.cbShowBalloon.Location = new System.Drawing.Point(12, 173);
            this.cbShowBalloon.Name = "cbShowBalloon";
            this.cbShowBalloon.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbShowBalloon.Size = new System.Drawing.Size(85, 17);
            this.cbShowBalloon.TabIndex = 8;
            this.cbShowBalloon.Text = "Balloon Alert";
            this.cbShowBalloon.UseVisualStyleBackColor = true;
            this.cbShowBalloon.CheckedChanged += new System.EventHandler(this.cbShowBalloon_CheckedChanged);
            // 
            // cbShowPopup
            // 
            this.cbShowPopup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbShowPopup.AutoSize = true;
            this.cbShowPopup.Location = new System.Drawing.Point(121, 173);
            this.cbShowPopup.Name = "cbShowPopup";
            this.cbShowPopup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbShowPopup.Size = new System.Drawing.Size(81, 17);
            this.cbShowPopup.TabIndex = 9;
            this.cbShowPopup.Text = "Popup Alert";
            this.cbShowPopup.UseVisualStyleBackColor = true;
            this.cbShowPopup.CheckedChanged += new System.EventHandler(this.cbShowPopup_CheckedChanged);
            // 
            // cbStartMinimised
            // 
            this.cbStartMinimised.AutoSize = true;
            this.cbStartMinimised.Location = new System.Drawing.Point(118, 35);
            this.cbStartMinimised.Name = "cbStartMinimised";
            this.cbStartMinimised.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbStartMinimised.Size = new System.Drawing.Size(97, 17);
            this.cbStartMinimised.TabIndex = 11;
            this.cbStartMinimised.Text = "Start Minimised";
            this.cbStartMinimised.UseVisualStyleBackColor = true;
            this.cbStartMinimised.CheckedChanged += new System.EventHandler(this.cbStartMinimised_CheckedChanged);
            // 
            // cbAutoStart
            // 
            this.cbAutoStart.AutoSize = true;
            this.cbAutoStart.Location = new System.Drawing.Point(12, 35);
            this.cbAutoStart.Name = "cbAutoStart";
            this.cbAutoStart.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbAutoStart.Size = new System.Drawing.Size(73, 17);
            this.cbAutoStart.TabIndex = 10;
            this.cbAutoStart.Text = "Auto Start";
            this.cbAutoStart.UseVisualStyleBackColor = true;
            this.cbAutoStart.CheckedChanged += new System.EventHandler(this.cbAutoStart_CheckedChanged);
            // 
            // numLinkSpeedMin
            // 
            this.numLinkSpeedMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLinkSpeedMin.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numLinkSpeedMin.Location = new System.Drawing.Point(226, 115);
            this.numLinkSpeedMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numLinkSpeedMin.Name = "numLinkSpeedMin";
            this.numLinkSpeedMin.Size = new System.Drawing.Size(46, 20);
            this.numLinkSpeedMin.TabIndex = 14;
            this.toolTip1.SetToolTip(this.numLinkSpeedMin, "How often to check");
            this.numLinkSpeedMin.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLinkSpeedMin.ValueChanged += new System.EventHandler(this.numLinkSpeedMin_ValueChanged);
            // 
            // lblUpdateAvailable
            // 
            this.lblUpdateAvailable.AutoSize = true;
            this.lblUpdateAvailable.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdateAvailable.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUpdateAvailable.Font = new System.Drawing.Font("Wingdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.lblUpdateAvailable.ForeColor = System.Drawing.Color.Red;
            this.lblUpdateAvailable.Location = new System.Drawing.Point(284, 3);
            this.lblUpdateAvailable.Name = "lblUpdateAvailable";
            this.lblUpdateAvailable.Size = new System.Drawing.Size(22, 17);
            this.lblUpdateAvailable.TabIndex = 22;
            this.lblUpdateAvailable.Text = "Þ";
            this.toolTip1.SetToolTip(this.lblUpdateAvailable, "An Update to Detect Network Changes is available");
            this.lblUpdateAvailable.Visible = false;
            this.lblUpdateAvailable.Click += new System.EventHandler(this.lblUpdateAvailable_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(3, 134);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 23);
            this.btnRefresh.TabIndex = 24;
            this.btnRefresh.Text = "Refresh";
            this.toolTip1.SetToolTip(this.btnRefresh, "Press to set the chosen network to be the one monitored");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbPlaySound
            // 
            this.cbPlaySound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPlaySound.AutoSize = true;
            this.cbPlaySound.Location = new System.Drawing.Point(224, 173);
            this.cbPlaySound.Name = "cbPlaySound";
            this.cbPlaySound.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbPlaySound.Size = new System.Drawing.Size(80, 17);
            this.cbPlaySound.TabIndex = 12;
            this.cbPlaySound.Text = "Play Sound";
            this.cbPlaySound.UseVisualStyleBackColor = true;
            this.cbPlaySound.CheckedChanged += new System.EventHandler(this.cbPlaySound_CheckedChanged);
            // 
            // cbCheckLinkSpeed
            // 
            this.cbCheckLinkSpeed.AutoSize = true;
            this.cbCheckLinkSpeed.Location = new System.Drawing.Point(12, 116);
            this.cbCheckLinkSpeed.Name = "cbCheckLinkSpeed";
            this.cbCheckLinkSpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCheckLinkSpeed.Size = new System.Drawing.Size(114, 17);
            this.cbCheckLinkSpeed.TabIndex = 13;
            this.cbCheckLinkSpeed.Text = "Check Link Speed";
            this.cbCheckLinkSpeed.UseVisualStyleBackColor = true;
            this.cbCheckLinkSpeed.CheckedChanged += new System.EventHandler(this.cbCheckLinkSpeed_CheckedChanged);
            // 
            // lblWarn
            // 
            this.lblWarn.AutoSize = true;
            this.lblWarn.Location = new System.Drawing.Point(131, 117);
            this.lblWarn.Name = "lblWarn";
            this.lblWarn.Size = new System.Drawing.Size(92, 13);
            this.lblWarn.TabIndex = 15;
            this.lblWarn.Text = "Warn when under";
            // 
            // lblMbps
            // 
            this.lblMbps.AutoSize = true;
            this.lblMbps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMbps.Location = new System.Drawing.Point(273, 117);
            this.lblMbps.Name = "lblMbps";
            this.lblMbps.Size = new System.Drawing.Size(33, 13);
            this.lblMbps.TabIndex = 21;
            this.lblMbps.Text = "Mbps";
            // 
            // soundPlayer1
            // 
            this.soundPlayer1.BackColor = System.Drawing.SystemColors.Control;
            this.soundPlayer1.DisabledColour = System.Drawing.SystemColors.Control;
            this.soundPlayer1.Filename = "";
            this.soundPlayer1.Location = new System.Drawing.Point(98, 142);
            this.soundPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.soundPlayer1.Name = "soundPlayer1";
            this.soundPlayer1.ShowClearButton = false;
            this.soundPlayer1.ShowDeviceList = false;
            this.soundPlayer1.ShowFilename = false;
            this.soundPlayer1.ShowTitle = true;
            this.soundPlayer1.ShowVolume = false;
            this.soundPlayer1.Size = new System.Drawing.Size(208, 24);
            this.soundPlayer1.SoundDeviceName = "Speakers (Conexant 20585 SmartA";
            this.soundPlayer1.TabIndex = 23;
            this.soundPlayer1.Title = "Sound to Play";
            this.soundPlayer1.Volume = 50;
            // 
            // enableToolStripMenuItem
            // 
            this.enableToolStripMenuItem.Name = "enableToolStripMenuItem";
            this.enableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.enableToolStripMenuItem.Text = "&Enable";
            this.enableToolStripMenuItem.Click += new System.EventHandler(this.enableToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(109, 6);
            // 
            // disableToolStripMenuItem
            // 
            this.disableToolStripMenuItem.Name = "disableToolStripMenuItem";
            this.disableToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.disableToolStripMenuItem.Text = "&Disable";
            this.disableToolStripMenuItem.Click += new System.EventHandler(this.disableToolStripMenuItem_Click);
            // 
            // cbEnabled
            // 
            this.cbEnabled.AutoSize = true;
            this.cbEnabled.Location = new System.Drawing.Point(240, 35);
            this.cbEnabled.Name = "cbEnabled";
            this.cbEnabled.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbEnabled.Size = new System.Drawing.Size(65, 17);
            this.cbEnabled.TabIndex = 25;
            this.cbEnabled.Text = "Enabled";
            this.cbEnabled.UseVisualStyleBackColor = true;
            this.cbEnabled.CheckedChanged += new System.EventHandler(this.cbEnabled_CheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 370);
            this.Controls.Add(this.cbEnabled);
            this.Controls.Add(this.soundPlayer1);
            this.Controls.Add(this.lblUpdateAvailable);
            this.Controls.Add(this.lblWarn);
            this.Controls.Add(this.numLinkSpeedMin);
            this.Controls.Add(this.cbCheckLinkSpeed);
            this.Controls.Add(this.cbPlaySound);
            this.Controls.Add(this.cbStartMinimised);
            this.Controls.Add(this.cbAutoStart);
            this.Controls.Add(this.cbShowPopup);
            this.Controls.Add(this.cbShowBalloon);
            this.Controls.Add(this.btnSetNetwork);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbNetwork);
            this.Controls.Add(this.numCheckSecs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDetails);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblMbps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 243);
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Detect Network Changes";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numCheckSecs)).EndInit();
            this.pnlDetails.ResumeLayout(false);
            this.pnlDetails.PerformLayout();
            this.cmNotify.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLinkSpeedMin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numCheckSecs;
        private System.Windows.Forms.ComboBox cbNetwork;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Label lblAdapterName;
        private System.Windows.Forms.Label lblNetName;
        private System.Windows.Forms.Label lblLastChecked;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSetNetwork;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbShowBalloon;
        private System.Windows.Forms.CheckBox cbShowPopup;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.CheckBox cbStartMinimised;
        private System.Windows.Forms.CheckBox cbAutoStart;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cmNotify;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbPlaySound;
        private System.Windows.Forms.Label lblConnectedToInternet;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLinkSpeed;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbCheckLinkSpeed;
        private System.Windows.Forms.NumericUpDown numLinkSpeedMin;
        private System.Windows.Forms.Label lblWarn;
        private System.Windows.Forms.Label lblMbps;
        private System.Windows.Forms.ToolStripMenuItem resetSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.Label lblUpdateAvailable;
        private Strangetimez.SoundPlayer soundPlayer1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem enableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.CheckBox cbEnabled;
    }
}

