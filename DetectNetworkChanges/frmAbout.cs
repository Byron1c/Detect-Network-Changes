using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectNetworkChanges
{
    public partial class frmAbout : Form
    {

        public frmAbout()
        {
            InitializeComponent();
        }


        private void frmAbout_Load(object sender, EventArgs e)
        {
            getAppInfo();
        }

        private void llName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAppURL();
        }

        private void llCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenAppURL();
        }

        private void btnSupportEmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "mailto:tgrowden@gmail.com?subject=DetectNetworkChanges Feedback/Support/Question&body=I have a Question / some Feedback / a Support Issue (**please say which one**)\n\n";
            proc.Start();
        }
                     
        private void pbDonate_Click(object sender, EventArgs e)
        {
            OpenDonateURL();
        }

        private void pbDonateQRCode_Click(object sender, EventArgs e)
        {
            OpenDonateURL();
        }
        
        
        private void getAppInfo()
        {
            try
            {
                string company = ((AssemblyCompanyAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute), false)).Company;
                string Title = ((AssemblyTitleAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyTitleAttribute), false)).Title;

                var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);

                llName.Text = Title;

                //this.lblProductName.Text = Title; //this.GetType().Assembly.GetName().FullName.ToString();  //this.GetType().Assembly.GetCustom.GetName().Name.ToString();
                this.lblVersion.Text = "Version " + this.GetType().Assembly.GetName().Version.ToString();
                this.llCompany.Text = company; //"Strangetimez";
                this.lblCopyright.Text = versionInfo.LegalCopyright.ToString();

                var descriptionAttribute = this.GetType().Assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                    .OfType<AssemblyDescriptionAttribute>()
                    .FirstOrDefault();

                if (descriptionAttribute != null) this.txtDescription.Text = descriptionAttribute.Description;

                //var copmpanyAttribute = this.GetType().Assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                //                .OfType<AssemblyCompanyAttribute>()
                //                .FirstOrDefault();

                //if (copmpanyAttribute != null) this.lblCompany.Text = copmpanyAttribute.Company;
            }
            catch (ArgumentException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetValue, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }
            catch (AmbiguousMatchException ex)
            {
                //ProcessError(ex, ErrorMessageType.GetValue, ShowError.NoShow, ThrowError.NoThrow, String.Format(CultureInfo.InvariantCulture, ""), FileFunctions.GetErrorLogFullPath());
            }



        }

        internal static void OpenDonateURL()
        {
            //TODO: change this to RRR, not LAWC
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=ZY9EW2SVJ84NU&item_name=DetectNetworkChanges&currency_code=AUD&source=url");
        }


        internal static void OpenAppURL()
        {
            System.Diagnostics.Process.Start("https://www.strangetimez.com/Blog/detect-network-changes-application/"); //TODO: create a blog page and put the link here
        }
    }
}
