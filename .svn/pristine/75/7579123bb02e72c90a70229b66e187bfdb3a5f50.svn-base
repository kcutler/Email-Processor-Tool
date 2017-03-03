using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections;


namespace CheckEmail
{
    public partial class CNS_Proccessor : Form
    {
        public CNS_Proccessor(Outlook.MailItem email, string acct)
        {
            InitializeComponent();
            FillForm(email, acct);
        }

        private void FillForm(Outlook.MailItem emailObject, string acct)
        {
            //MessageBox.Show("In fill form");
            string bodyString = emailObject.Body.Remove((emailObject.Body.IndexOf(")") + 1), (emailObject.Body.IndexOf("@") - emailObject.Body.IndexOf(")")));
            string bodyIntro = bodyString.Substring(bodyString.IndexOf("PLEASE"), bodyString.IndexOf("ACCOUNT") + 3); 
            string acctNumLine = Environment.NewLine + bodyString.Substring(bodyString.IndexOf(acct), 28).Replace("\n\r", " ").TrimStart(); // +Environment.NewLine;
            string bodySignature = Environment.NewLine + bodyString.Substring(bodyString.IndexOf("Regards,"));

            ToBox.Text = FindAcctEmail(acct);
            FromBox.Text = emailObject.ReceivedByName.ToString();
            CCBox.Text = "Katrina.Stephenson@cutlergrouplp.com, Doug.Patterson@cutlergrouplp.com, Johannav@cutlergrouplp.com, chicagoclerks@cutlergouplp.com";
            SubjectBox.Text = "CUTLER DEFICIT EXECUTIONS";
            BodyBox.Text = bodyIntro + acctNumLine +Environment.NewLine + bodySignature;
        }

        private string FindAcctEmail(string acct)
        {
            //MessageBox.Show("In Find Acct Email");
            //Finds EMail.txt file in Current Directory.
            string path = Path.Combine(Environment.CurrentDirectory, "EMail.txt"); 
            string email = string.Empty;
            string data = string.Empty;
            StreamReader sr = File.OpenText(path);

            while ((data = sr.ReadLine()) != null)
            {
                if (data.Trim().StartsWith(acct.Trim()))
                {
                    email = data.Substring(8);
                }
            }
            return email;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendEmail();
        }

        public void SendEmail()
        {
            //MessageBox.Show("In Send Email");
            Microsoft.Office.Interop.Outlook.Application app = null;
            Microsoft.Office.Interop.Outlook.MailItem mailItem = null;

            try
            {
                //var emailTo = "Kristen.Cutler@cutlergrouplp.com";
                //mailItem.To = emailTo;
                app = new Outlook.Application();
                mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
                mailItem.To = ToBox.Text.ToString();
                mailItem.Subject = SubjectBox.Text.ToString();
                mailItem.Body = BodyBox.Text.ToString();

                List<string> CC = CCBox.Text.Split(',').ToList();
                Outlook.Recipients recips = (Outlook.Recipients)mailItem.Recipients;
                foreach (string email in CC)
                {
                       Outlook.Recipient recip = (Outlook.Recipient)recips.Add(email);
                       recip.Type = (int)Outlook.OlMailRecipientType.olCC;
                }
                string log = "Email sent to " + mailItem.To.ToString();
                ((Outlook._MailItem)mailItem).Send();
                MessageBox.Show(log);
            }
            finally
            {
                if (app != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(app);
                }
                if (mailItem != null)
                {
                    System.Runtime.InteropServices.Marshal.FinalReleaseComObject(mailItem);
                }
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CCBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

