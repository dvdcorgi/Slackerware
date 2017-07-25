using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Slackware.ServiceReferenceSlack;

namespace Slackware
{
    public partial class FormWCFCrud : Form
    {
        ServiceFuncClient servClient = new ServiceFuncClient();

        public FormWCFCrud()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                tblEntry tEntry = new tblEntry();
                tEntry.Code = Convert.ToInt32(txtCode.Text);
                tEntry.DateAdded = DateTime.Now;
                tEntry.Description = txtDesc.Text;
                tEntry.Genre = txtGenre.Text;
                tEntry.Title = txtTitle.Text;
                tEntry.Type = txtType.Text;
                tEntry.URL = txtURL.Text;
                tEntry.Year = Convert.ToInt32(txtYear.Text);

                servClient.AddEntry(tEntry);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in saving entry: " + ex.Message);
            }
        }

        private void ClearItems()
        {
            txtDesc.Text = "";
            txtCode.Text = "";
            txtGenre.Text = "";
            txtTitle.Text = "";
            txtType.Text = "";
            txtURL.Text = "";
            txtYear.Text = "";
        }
    }
}
