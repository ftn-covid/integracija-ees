using System;
using System.IO;
using System.Windows.Forms;
using FTN.ESI.SIMES.CIM.Model;
using FTN.ESI.SIMES.CIM.Parser;

namespace FTN.ESI.SIMES.CIM.CIMProfileLoader
{
    public partial class CIMProfileLoaderForm : Form
    {
        private Profile profile = null;

        public CIMProfileLoaderForm()
        {
            InitializeComponent();

            RefreshControls();
        }


        private void RefreshControls()
        {
            bool isCIMProfileSelected = !string.IsNullOrWhiteSpace(textBoxCIMProfile.Text);
            buttonLoad.Enabled = isCIMProfileSelected;
            buttonSave.Enabled = (profile != null);
        }


		#region Opeartions
		private void ShowOpenCIMRDFSFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open CIM Profile File..";
            openFileDialog.Filter = "CIM-RDFS Files|*.rdfs;*.legacy-rdfs|All Files|*.*";
            openFileDialog.RestoreDirectory = true;

            DialogResult dialogResponse = openFileDialog.ShowDialog(this);
            if (dialogResponse == DialogResult.OK)
            {
                textBoxCIMProfile.Text = openFileDialog.FileName;
                toolTipService.SetToolTip(textBoxCIMProfile, openFileDialog.FileName);
            }
            RefreshControls();
        }

        private void LoadCIMRDFSFile()
        {
            ////LOAD RDFS AND MAKE A PROFILE
            try
            {
                profile = null;
                using (FileStream fs = File.Open(textBoxCIMProfile.Text, FileMode.Open))
                {
                    ProfileLoader rdfParser = new ProfileLoader();
                    profile = rdfParser.LoadProfileDocument(fs, textBoxCIMProfile.Text);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An error occurred.\n\n{0}", e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PrintProfile();
            RefreshControls();
        }

        private void PrintProfile()
        {
            richTextBoxProfile.Clear();
            if (profile != null)
            {
                richTextBoxProfile.Text = profile.ToString();
            }
        }

        private void SaveToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save CIM Profile report to file..";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "TXT Files|*.txt|All Files|*.*";
            saveFileDialog.FileName = "CIM-profile-print.txt";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                using (StreamWriter writeTo = new StreamWriter(saveFileDialog.FileName, false))
                {
                    writeTo.WriteLine(richTextBoxProfile.Text);
                    writeTo.Flush();
                }
            }
        }
		#endregion Opeartions


		#region Event Handlers:
		private void buttonBrowse_Click(object sender, EventArgs e)
        {
            ShowOpenCIMRDFSFileDialog();
        }

        private void textBoxCIMProfile_DoubleClick(object sender, EventArgs e)
        {
            ShowOpenCIMRDFSFileDialog();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadCIMRDFSFile();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }
        #endregion Event Handlers

    }
}
