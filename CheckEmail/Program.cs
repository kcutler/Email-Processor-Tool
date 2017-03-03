using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Collections;

namespace CheckEmail
{
    public class Data
    {
        public List<Outlook.MailItem> emails = new List<Outlook.MailItem>();
        public List<KeyValuePair<Outlook.MailItem, string>> emailandAcct = new List<KeyValuePair<Outlook.MailItem,string>>();

        public Data()
        {
            GetEmails();
            FindAccts(emails);
        }
        
        public void GetEmails()
        {
            //MessageBox.Show("In GetEmails");
            Outlook.MAPIFolder inbox = null;
            Outlook.NameSpace ns = null;
            Outlook.Items items = null;
            Outlook.MailItem mailItem = null;
            string subjectName = string.Empty;
            DateTime lastrunDate = Convert.ToDateTime(File.ReadLines("log.txt").Last());
            string subjectFilter = "[Subject] = 'Cutler / (1) DEFICIT EXECUTIONS'";
            string subjectFilter2 = "[Subject] = 'STOCK LOAN EXECUTION'";
            string subjectFilter3 = "[Subject] = 'CUTLER/ (1) DEFICIT EXECUTIONS'";
            List<string> subjectFilters = new List<string>();
            subjectFilters.Add(subjectFilter);
            subjectFilters.Add(subjectFilter2);
            subjectFilters.Add(subjectFilter3);
              
            try
            {
                if (Process.GetProcessesByName("OUTLOOK").Count() > 0)
                {
                    //Check if Outlook is open.
                    //MessageBox.Show("Outlook Is Open");
                    Outlook.Application applic = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
                    inbox = applic.ActiveExplorer().Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                }
                else
                {
                    //Open Outlook if closed. 
                    //MessageBox.Show("Outlook is Closed...Opening an instance of Outlook");
                    Outlook.Application app = new Outlook.Application();
                    ns = app.GetNamespace("MAPI");
                    inbox = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
                    ns = null;
                }

                foreach (string subject in subjectFilters)
                {
                    object folderItem;
                    items = inbox.Items;
                    folderItem = items.Find(subject);
                    //MessageBox.Show("Checking for Emails since " + lastrunDate + " with subject " + subject);

                    while (folderItem != null)
                    {
                        mailItem = folderItem as Outlook.MailItem;
                        //Check if email rcvd after last run date.
                        if (mailItem != null && Convert.ToDateTime(mailItem.ReceivedTime) > lastrunDate)
                        {
                            emails.Add(mailItem);
                            subjectName += "\n" + mailItem.Subject + mailItem.SenderEmailAddress + mailItem.SentOn;
                        }
                        folderItem = items.FindNext();
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("{0} Exception caught.", e.Message);
            }
            finally
            {
                 if (items != null)
                 {
                     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(items);
                 }
                 if (inbox != null)
                 {
                     System.Runtime.InteropServices.Marshal.FinalReleaseComObject(inbox);
                 }
            }
            if (emails.Count == 0)
            {
                MessageBox.Show("No Emails Found");
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Found " + emails.Count + " Emails");
            }             
            return;
        }

        public void FindAccts(List<Outlook.MailItem> emailObjects)
        {
            //MessageBox.Show("In FindAccts");
            foreach (Outlook.MailItem emailObject in emailObjects)
            {
                List<string> findAcctsList = emailObject.Body.Substring(emailObject.Body.IndexOf("ACCOUNT"), (emailObject.Body.IndexOf("Regards,") - emailObject.Body.IndexOf("ACCOUNT"))).Split(' ').ToList();
                string acctNum;

                foreach (string elem in findAcctsList)
                {
                    if (elem.Trim().StartsWith("424"))
                    {
                        acctNum = emailObject.Body.Substring(emailObject.Body.IndexOf(elem), 10);
                        //MessageBox.Show("Found Account Number " + acctNum);
                        emailandAcct.Add(new KeyValuePair<Outlook.MailItem, string>(emailObject, acctNum));
                    }
                }
            }
            return;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Data emails = new Data();

            //MessageBox.Show("In MAIN");

            foreach (var item in emails.emailandAcct)
            {
                //MessageBox.Show("Creating Form for " + item);
                Application.Run(new CNS_Proccessor(item.Key, item.Value));
            }
            using (StreamWriter writer = File.AppendText("log.txt"))
            {
                writer.WriteLine(DateTime.Now);
            }
         }
    }   
}
