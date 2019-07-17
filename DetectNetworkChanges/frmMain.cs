using DetectNetworkChanges.Objects;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Net;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.Media;


namespace DetectNetworkChanges
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// Tells the rest of the app that the form is closing
        /// </summary>
        internal Boolean formClosing = false;

        /// <summary>
        /// Flag when a problem is found - network difference found
        /// </summary>
        internal Boolean ProblemFound = false;

        /// <summary>
        /// Flag for when an event detects a network change
        /// </summary>
        internal Boolean networkChanged = false;

        /// <summary>
        /// The value found when checking the current network state
        /// </summary>
        NetworkSummary currentNS;

        /// <summary>
        /// The value stored when the app starts, or a different network is selected
        /// </summary>
        NetworkSummary checkNS;



        public frmMain()
        {
            InitializeComponent();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            // upgrade settings if a new version of the app is run
            //https://stackoverflow.com/questions/534261/how-do-you-keep-user-config-settings-across-different-assembly-versions-in-net/534335#534335
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            ProblemFound = false;

            checkNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);
            currentNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);

            setFormValues();
            updateCurrentNetworkInfo();
            updateLastChecked();

            doMainTimerTick(); // do first pass to set the screen

            tmrMain.Interval = Properties.Settings.Default.CheckSeconds * 1000;
            tmrMain.Start();

            if (Properties.Settings.Default.StartMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;

            this.FormClosing += FrmMain_FormClosing;
            this.Resize += FrmMain_Resize;
            this.notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
        }


        #region Handlers

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            networkChanged = true;
        }


        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            networkChanged = true;
        }


        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/7625421/minimize-app-to-system-tray
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                //notifyIcon1.BalloonTipText = "Detect Network Changes running...";
                //notifyIcon1.ShowBalloonTip(500);
                ShowInTaskbar = false;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
                ShowInTaskbar = true;
            }
        }


        private void tmrMain_Tick(object sender, EventArgs e)
        {
            doMainTimerTick();
        }


        private void numCheckSecs_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckSeconds = (int)numCheckSecs.Value;
            Properties.Settings.Default.Save();
            tmrMain.Interval = Properties.Settings.Default.CheckSeconds * 1000;
        }


        private void cbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNetwork.SelectedItem == null) return;

            if (Properties.Settings.Default.NetworkToCheck != cbNetwork.SelectedItem.ToString())
            {
                btnSetNetwork.Enabled = true;
            }
            else
            {
                btnSetNetwork.Enabled = false;
            }
        }


        private void btnSetNetwork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.NetworkToCheck)) return;

            Properties.Settings.Default.NetworkToCheck = cbNetwork.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            btnSetNetwork.Text = "Working...";
            btnSetNetwork.Enabled = false;
            cbNetwork.Enabled = false;

            ComboboxItemCustom selectedItem = (ComboboxItemCustom)cbNetwork.SelectedItem;

            checkNS = new NetworkSummary(Guid.Parse(selectedItem.Name));

            doMainTimerTick();

            cbNetwork.Enabled = true;
            btnSetNetwork.Text = "Set Network";

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }


        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            // Do Nothing
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Visible = false;

            if (e.CloseReason == CloseReason.WindowsShutDown && formClosing == false)
            {
                formClosing = true;
                Quit();
                return;
            }
            else
            {
                if (formClosing == false)
                {
                    formClosing = true;

                    tmrMain.Stop();

                    if (MessageBox.Show("Are you sure you want to close Detect Network Changes?\n\nNote: To hide the main window, press the Minimize button on the top right.", "Close Application",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                        formClosing = false;

                        tmrMain.Start();
                    }
                    else
                    {
                        Quit();
                    }
                }
                else
                {
                    // form is closing

                }

            }
        }


        private void cbShowBalloon_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowBalloon = cbShowBalloon.Checked;
            Properties.Settings.Default.Save();
            checkAlerts();
        }

        private void cbShowPopup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPopup = cbShowPopup.Checked;
            Properties.Settings.Default.Save();
            checkAlerts();
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Do Nothing
        }


        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                notifyIcon1.Visible = false;
                this.Show();
                WindowState = FormWindowState.Normal;

                this.BringToFront();
                this.Focus();
            }
        }


        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = cbAutoStart.Checked;
            Properties.Settings.Default.Save();
            setStartAutomatically();
        }


        private void cbStartMinimised_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartMinimized = cbStartMinimised.Checked;
            Properties.Settings.Default.Save();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
            about.Hide();
            about.Dispose();
        }


        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }


        private void cbPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PlaySound = cbPlaySound.Checked;
            Properties.Settings.Default.Save();
        }


        #endregion












        #region Functions


        /// <summary>
        /// Main timer function for checking and processing network checks
        /// </summary>
        private void doMainTimerTick()
        {
            // if no network is selected, dont bother processing
            if (string.IsNullOrEmpty(Properties.Settings.Default.NetworkToCheck)) return;

            // if the network change event is fired it sets this flag, update the network list here
            if (networkChanged)
            {
                networkChanged = false;
                fillNetworkList(Properties.Settings.Default.NetworkToCheck, NetworkConnectivityLevels.All);
            }

            try
            {
                currentNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);
            }
            catch (Exception)
            {
                return;
            }

            // display current data
            updateCurrentNetworkInfo();
            updateLastChecked();

            // if a problem is found
            if (!checkNS.Equals(currentNS))
            {
                ProblemFound = true;
                tmrMain.Stop();

                if (Properties.Settings.Default.PlaySound) SystemSounds.Exclamation.Play();
                if (Properties.Settings.Default.ShowBalloon) showBalloon("Network Settings have Changed",
                    "Network " + Properties.Settings.Default.NetworkToCheck + " has Changed",
                    false, 60);
                if (Properties.Settings.Default.ShowPopup) MessageBox.Show("Network " + Properties.Settings.Default.NetworkToCheck + " has Changed", "Detect Network Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                notifyIcon1.Icon = new System.Drawing.Icon(Application.StartupPath + @"\Icon_Problem.ico");
                lblState.Text = "r"; // Webdings X
                lblState.ForeColor = Color.OrangeRed;
                btnSetNetwork.Enabled = true;

                tmrMain.Start();
            }
            else
            {
                lblState.Text = "a"; // Webdings tick
                lblState.ForeColor = Color.ForestGreen;

                // entries match = no problem (anymore)
                if (ProblemFound == true)
                {
                    ProblemFound = false;
                    notifyIcon1.Icon = new System.Drawing.Icon(Application.StartupPath + @"\Icon.ico");
                }
            }
        }


        /// <summary>
        /// Show a notification/balloon in Windows
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="vTesting"></param>
        /// <param name="vBalloonShowSeconds"></param>
        private void showBalloon(string title, string body, Boolean vTesting, int vBalloonShowSeconds)
        {
            try
            {

                if (notifyIcon1 != null)
                {
                    notifyIcon1.Dispose();
                }

                notifyIcon1 = new NotifyIcon
                {
                    Icon = new Icon(Application.StartupPath + @"\Icon.ico"),
                    Visible = true,
                    BalloonTipIcon = ToolTipIcon.None
                };
                notifyIcon1.BalloonTipClicked += NotifyIcon_BalloonTipClicked;

                if (title != null)
                {
                    notifyIcon1.BalloonTipTitle = title;
                }

                if (body != null)
                {
                    if (body.Trim().Length > 0)
                    {
                        notifyIcon1.BalloonTipText = body;
                    }
                    else
                    {
                        notifyIcon1.BalloonTipText = " ";
                    }
                }


                notifyIcon1.ShowBalloonTip(vBalloonShowSeconds * 1000);

                // This will let the balloon close after it's x second timeout
                // for demonstration purposes. Comment this out to see what happens
                // when dispose is called while a balloon is still visible.1
                //Thread.Sleep(10000);

                // The notification should be disposed when you don't need it anymore,
                // but doing so will immediately close the balloon if it's visible.
                //notifyIcon.Dispose();
            }
            catch (Exception ex)
            {
                //ProcessError(ex, ErrorMessageType.Balloon, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }

        }


        /// <summary>
        /// Check if all alerts are turned off, and show a message 
        /// </summary>
        private void checkAlerts()
        {
            if (cbShowBalloon.Checked == false && cbShowPopup.Checked == false && cbPlaySound.Checked == false)
            {
                MessageBox.Show("Warning: You do NOT have any alerts selected. \nPlease choose one.", "Detect Network Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Set the app the auto start when windows starts up
        /// </summary>
        internal void setStartAutomatically()
        {

            try
            {
                RegistryKey rkApp;
                rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                string appName = this.GetType().Assembly.GetName().Name.ToString();

                if (Properties.Settings.Default.AutoStart)
                {
                    // ADD KEY
                    rkApp.SetValue(appName, Application.ExecutablePath.ToString());
                }
                else
                {
                    if (isAppInRun())
                    {
                        // REMOVE KEY
                        rkApp.DeleteValue(appName);
                    }
                }

                rkApp.Close();
                //rkApp.Dispose();
            }
            catch (ArgumentNullException ex)
            {
                //ProcessError(ex, ErrorMessageType.Registry, ShowError.Show, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }
            catch (System.Security.SecurityException ex)
            {
                //ProcessError(ex, ErrorMessageType.Registry, ShowError.Show, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }

        }


        /// <summary>
        /// Check if the app is set to auto run in the windows startup
        /// </summary>
        /// <returns></returns>
        private Boolean isAppInRun()
        {
            Boolean output = false;

            try
            {
                RegistryKey rkApp;
                rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                string appName = this.GetType().Assembly.GetName().Name.ToString();

                if (rkApp.GetValue(appName) != null)
                {
                    output = true;
                }

                rkApp.Close();
                //rkApp.Dispose();
            }
            catch (ArgumentNullException ex)
            {
                //ProcessError(ex, ErrorMessageType.Registry, ShowError.Show, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }
            catch (System.Security.SecurityException ex)
            {
                //ProcessError(ex, ErrorMessageType.Registry, ShowError.Show, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }

            return output;
        }


        /// <summary>
        /// Set the values from Settings, on the main form
        /// </summary>
        private void setFormValues()
        {
            numCheckSecs.Value = Properties.Settings.Default.CheckSeconds;
            cbAutoStart.Checked = Properties.Settings.Default.AutoStart;
            cbStartMinimised.Checked = Properties.Settings.Default.StartMinimized;
            cbShowBalloon.Checked = Properties.Settings.Default.ShowBalloon;
            cbShowPopup.Checked = Properties.Settings.Default.ShowPopup;

            fillNetworkList(Properties.Settings.Default.NetworkToCheck, NetworkConnectivityLevels.All);
        }


        /// <summary>
        /// fill the network combo box list with a custom combo box item
        /// </summary>
        /// <param name="vSelectedNetworkName"></param>
        /// <param name="vConnectivity"></param>
        private void fillNetworkList(string vSelectedNetworkName, NetworkConnectivityLevels vConnectivity)
        {
            cbNetwork.Items.Clear();

            NetworkCollection netCollection = NetworkListManager.GetNetworks(vConnectivity); // NetworkConnectivityLevels.Connected);
            ComboboxItemCustom comboItem;

            var orderedList =
                    netCollection.OrderBy(x => x.Name);
            //.ThenByDescending(x => x.Name);

            foreach (Network n in orderedList)
            {
                {
                    comboItem = new ComboboxItemCustom(n.Name, n.NetworkId.ToString(), n.IsConnectedToInternet);
                    cbNetwork.Items.Add(comboItem);

                    if (vSelectedNetworkName == n.Name)
                    {
                        cbNetwork.SelectedItem = comboItem;
                    }
                }
            }

        }


        /// <summary>
        /// Update the display of the network info on the form
        /// </summary>
        private void updateCurrentNetworkInfo()
        {
            // display current data
            lblAdapterName.Text = String.IsNullOrEmpty(currentNS.AdapterName) ? "(none connected)" : currentNS.AdapterName;
            lblIPAddress.Text = String.IsNullOrEmpty(currentNS.IPAddress) ? "(none assigned)" : currentNS.IPAddress;
            lblNetName.Text = currentNS.NetworkName;
            lblConnected.Text = currentNS.IsConnected ? "Yes" : "No";
            lblConnectedToInternet.Text = currentNS.IsConnectedToInternet ? "Yes" : "No";
        }


        /// <summary>
        /// Update the info on when the check was last run
        /// </summary>
        private void updateLastChecked()
        {
            lblLastChecked.Text = "Last Checked: " + DateTime.Now.ToString("HH:mm:ss");
        }


        /// <summary>
        /// Quit the app and cleanup
        /// </summary>
        internal void Quit()
        {
            tmrMain.Stop();
            tmrMain.Enabled = false;
            tmrMain.Dispose();

            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();

            //https://stackoverflow.com/questions/12977924/how-to-properly-exit-a-c-sharp-application
            if (System.Windows.Forms.Application.MessageLoop)
            {
                // WinForms app
                Application.Exit();
            }
            else
            {
                // Console app
                System.Environment.Exit(1);
            }
        }



        #endregion



    }


}
