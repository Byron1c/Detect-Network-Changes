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
using System.Reflection;

namespace DetectNetworkChanges
{
    public partial class frmMain : Form
    {

        /// <summary>
        /// Tells the rest of the app that the form is closing
        /// </summary>
        internal Boolean IsFormClosing = false;

        /// <summary>
        /// Flag when a problem is found - network difference found
        /// </summary>
        internal Boolean ProblemFound = false;

        /// <summary>
        /// Flag for when an event detects a network change
        /// </summary>
        internal Boolean NetworkChanged = false;

        /// <summary>
        /// The value found when checking the current network state
        /// </summary>
        NetworkSummary CurrentNS;

        /// <summary>
        /// The value stored when the app starts, or a different network is selected
        /// </summary>
        NetworkSummary CheckNS;



        public frmMain()
        {
            InitializeComponent();

            // upgrade settings if a new version of the app is run
            //https://stackoverflow.com/questions/534261/how-do-you-keep-user-config-settings-across-different-assembly-versions-in-net/534335#534335
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            Initialise();

        }



        private void frmMain_Load(object sender, EventArgs e)
        {
            // Do Nothing
        }
               

        /// <summary>
        /// Set initial values
        /// Used on startup and reset settings
        /// </summary>
        private void Initialise()
        {

            ProblemFound = false;

            CheckNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);
            CurrentNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);

            SetFormValues();
            UpdateCurrentNetworkInfo();
            updateLastChecked();

            doMainTimerTick(); // do first pass to set the screen

            tmrMain.Interval = Properties.Settings.Default.CheckSeconds * 1000;
            tmrMain.Start();

            NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;

            this.FormClosing += FrmMain_FormClosing;
            this.Resize += FrmMain_Resize;
            this.notifyIcon1.MouseClick += NotifyIcon1_MouseClick;
            this.numLinkSpeedMin.KeyUp += NumLinkSpeedMin_KeyUp;
            this.numCheckSecs.KeyUp += NumCheckSecs_KeyUp;
            this.notifyIcon1.BalloonTipClicked += NotifyIcon_BalloonTipClicked;

            if (Properties.Settings.Default.StartMinimized)
            {
                //this.WindowState = FormWindowState.Minimized;
                //this.Hide();
            }
        }






        #region Handlers

        private void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            NetworkChanged = true;
        }


        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            NetworkChanged = true;
        }


        private void FrmMain_Resize(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/7625421/minimize-app-to-system-tray
            if (FormWindowState.Minimized == this.WindowState)
            {
                ShowInTaskbar = false;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                ShowInTaskbar = true;
                this.BringToFront();
            }
        }


        private void tmrMain_Tick(object sender, EventArgs e)
        {
            doMainTimerTick();
        }
                       

        private void cbNetwork_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbNetwork.SelectedItem == null) return;

            if (Properties.Settings.Default.NetworkToCheck != cbNetwork.SelectedItem.ToString() && !String.IsNullOrEmpty(cbNetwork.SelectedItem.ToString()))
            {
                btnSetNetwork.Enabled = true;
                btnSetNetwork.Text = "Set Network Info";
                setNetwork();
            }
            else
            {
                btnSetNetwork.Enabled = false;
            }
        }


        private void btnSetNetwork_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.NetworkToCheck)) return;

            setNetwork();

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }


        private void NotifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }


        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //notifyIcon1.Visible = false;

            if (e.CloseReason == CloseReason.WindowsShutDown && IsFormClosing == false)
            {
                IsFormClosing = true;
                Quit();
                return;
            }
            else
            {
                if (IsFormClosing == false)
                {
                    IsFormClosing = true;

                    tmrMain.Stop();

                    if (MessageBox.Show("Are you sure you want to close Detect Network Changes?\n\nNote: To hide the main window, press the Minimize button on the top right.", "Close Application",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        e.Cancel = true;
                        IsFormClosing = false;

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
            CheckAlerts();
        }

        private void cbShowPopup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ShowPopup = cbShowPopup.Checked;
            Properties.Settings.Default.Save();
            CheckAlerts();
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Do Nothing
        }


        private void NotifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.BringToFront();
            }
        }


        private void cbAutoStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoStart = cbAutoStart.Checked;
            Properties.Settings.Default.Save();
            SetStartAutomatically();
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


        private void cbCheckLinkSpeed_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.LinkSpeedCheck = cbCheckLinkSpeed.Checked;
            Properties.Settings.Default.Save();
            SetLinkCheckControlState();
        }


        private void numLinkSpeedMin_ValueChanged(object sender, EventArgs e)
        {
            // Do Nothing
        }


        private void NumLinkSpeedMin_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean checkResult = int.TryParse(numLinkSpeedMin.Text, out int linkSpeedMin);

            if (checkResult)
            {
                Properties.Settings.Default.LinkSpeedMin = linkSpeedMin;
                Properties.Settings.Default.Save();
            }
        }


        private void numCheckSecs_ValueChanged(object sender, EventArgs e)
        {
            // Do Nothing
        }


        private void NumCheckSecs_KeyUp(object sender, KeyEventArgs e)
        {
            Boolean checkResult = int.TryParse(numCheckSecs.Text, out int checkSeconds);

            if (checkResult)
            {
                Properties.Settings.Default.CheckSeconds = checkSeconds;
                Properties.Settings.Default.Save();
                tmrMain.Interval = Properties.Settings.Default.CheckSeconds * 1000;
            }
        }


        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrMain.Stop();
            if (MessageBox.Show("Are you sure you want to RESET all settings?", "Reset Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.UpgradeRequired = false; // stop the upgrade / passing on of settings in the settings Upgrade process
                Properties.Settings.Default.Save();
                Initialise();
                return;
            }
            tmrMain.Start();
        }



        #endregion












        #region Functions


        /// <summary>
        /// Main timer function for checking and processing network checks
        /// </summary>
        private void doMainTimerTick()
        {
            updateLastChecked();

            // if no network is selected, dont bother processing
            if (string.IsNullOrEmpty(Properties.Settings.Default.NetworkToCheck)) return;

            // if the network change event is fired it sets this flag, update the network list here
            if (NetworkChanged)
            {
                NetworkChanged = false;
                FillNetworkList(Properties.Settings.Default.NetworkToCheck, NetworkConnectivityLevels.All);
            }

            try
            {
                CurrentNS = new NetworkSummary(Properties.Settings.Default.NetworkToCheck);
            }
            catch (Exception)
            {
                return;
            }

            // display current data
            UpdateCurrentNetworkInfo();
            
            // if a problem is found
            if (!CheckNS.Equals(CurrentNS) || !isLinkSpeedOK(CurrentNS))                
            {
                ProblemFound = true;
                tmrMain.Stop();

                if (Properties.Settings.Default.PlaySound) SystemSounds.Exclamation.Play();
                if (Properties.Settings.Default.ShowBalloon) ShowBalloon("Network Settings have Changed",
                    "Network " + Properties.Settings.Default.NetworkToCheck + " has Changed",
                    false, Properties.Settings.Default.CheckSeconds);
                if (Properties.Settings.Default.ShowPopup) MessageBox.Show("Network " + Properties.Settings.Default.NetworkToCheck + " has Changed", "Detect Network Changes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                notifyIcon1.Icon = new System.Drawing.Icon(Application.StartupPath + @"\Icon_Problem.ico");
                lblState.Text = "r"; // Webdings X / cross
                lblState.ForeColor = Color.OrangeRed;
                btnSetNetwork.Enabled = true;
                btnSetNetwork.Text = "Update Network Info";

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

                btnSetNetwork.Text = "Set Network Info";
            }
        }


        /// <summary>
        /// check if the speed is being checked, and if so check that its above the set minimum
        /// if the speed is NOT being checked, TRUE is returned
        /// </summary>
        /// <returns></returns>
        private Boolean isLinkSpeedOK(NetworkSummary vNS)
        {
            // if not checking link speed, then this is okay:
            if (!Properties.Settings.Default.LinkSpeedCheck) return true;
            // check link speed:
            if (vNS.LinkSpeed < Properties.Settings.Default.LinkSpeedMin) return false;

            return true;
        }


        /// <summary>
        /// Show a notification/balloon in Windows
        /// </summary>
        /// <param name="title"></param>
        /// <param name="body"></param>
        /// <param name="vTesting"></param>
        /// <param name="vBalloonShowSeconds"></param>
        private void ShowBalloon(string title, string body, Boolean vTesting, int vBalloonShowSeconds)
        {
            try
            {               

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
        private void CheckAlerts()
        {
            if (cbShowBalloon.Checked == false && cbShowPopup.Checked == false && cbPlaySound.Checked == false)
            {
                MessageBox.Show("Warning: You do NOT have any alerts selected. \nPlease choose one.", "Detect Network Changes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        /// <summary>
        /// Set the app the auto start when windows starts up
        /// </summary>
        internal void SetStartAutomatically()
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
                    if (IsAppInRun())
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
        private Boolean IsAppInRun()
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
        private void SetFormValues()
        {
            numCheckSecs.Value = Math.Min(Properties.Settings.Default.CheckSeconds, numCheckSecs.Maximum);
            cbAutoStart.Checked = Properties.Settings.Default.AutoStart;
            cbStartMinimised.Checked = Properties.Settings.Default.StartMinimized;
            cbShowBalloon.Checked = Properties.Settings.Default.ShowBalloon;
            cbShowPopup.Checked = Properties.Settings.Default.ShowPopup;
            cbPlaySound.Checked = Properties.Settings.Default.PlaySound;
            cbCheckLinkSpeed.Checked = Properties.Settings.Default.LinkSpeedCheck;
            numLinkSpeedMin.Value = Math .Min(Properties.Settings.Default.LinkSpeedMin, numLinkSpeedMin.Maximum);
            SetLinkCheckControlState();

            FillNetworkList(Properties.Settings.Default.NetworkToCheck, NetworkConnectivityLevels.All);
        }

        /// <summary>
        /// Set the controls for checking the link speed
        /// </summary>
        private void SetLinkCheckControlState()
        {
            lblWarn.Enabled = Properties.Settings.Default.LinkSpeedCheck;
            numLinkSpeedMin.Enabled = Properties.Settings.Default.LinkSpeedCheck;
            lblMbps.Enabled = Properties.Settings.Default.LinkSpeedCheck;
        }


        /// <summary>
        /// fill the network combo box list with a custom combo box item
        /// </summary>
        /// <param name="vSelectedNetworkName"></param>
        /// <param name="vConnectivity"></param>
        private void FillNetworkList(string vSelectedNetworkName, NetworkConnectivityLevels vConnectivity)
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

            if (String.IsNullOrEmpty(vSelectedNetworkName))
            {
                cbNetwork.Text = "(Select One)";
            }

        }


        /// <summary>
        /// Update the display of the network info on the form
        /// </summary>
        private void UpdateCurrentNetworkInfo()
        {
            // display current data
            lblAdapterName.Text = String.IsNullOrEmpty(CurrentNS.AdapterName) ? "(None Connected)" : CurrentNS.AdapterName;
            lblIPAddress.Text = String.IsNullOrEmpty(CurrentNS.IPAddress) ? "(None Assigned)" : CurrentNS.IPAddress;
            lblNetName.Text = String.IsNullOrEmpty(CurrentNS.NetworkName) ? "(None Selected)" : CurrentNS.NetworkName; 
            lblConnected.Text = CurrentNS.IsConnected ? "Yes" : "No";
            lblConnectedToInternet.Text = CurrentNS.IsConnectedToInternet ? "Yes" : "No";
            lblLinkSpeed.Text = (CurrentNS.LinkSpeed).ToString();
        }


        /// <summary>
        /// Update the info on when the check was last run
        /// </summary>
        private void updateLastChecked()
        {
            lblLastChecked.Text = "Last Checked: " + DateTime.Now.ToString("HH:mm:ss");
        }


        /// <summary>
        /// Set the selected network
        /// </summary>
        private void setNetwork()
        {
            Properties.Settings.Default.NetworkToCheck = cbNetwork.SelectedItem.ToString();
            Properties.Settings.Default.Save();

            btnSetNetwork.Text = "Working...";
            btnSetNetwork.Enabled = false;
            cbNetwork.Enabled = false;

            ComboboxItemCustom selectedItem = (ComboboxItemCustom)cbNetwork.SelectedItem;

            CheckNS = new NetworkSummary(Guid.Parse(selectedItem.Name));

            doMainTimerTick();

            cbNetwork.Enabled = true;
            btnSetNetwork.Text = "Set Network Info";

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
