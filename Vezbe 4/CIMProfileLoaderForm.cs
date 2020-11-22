using System;
using System.Windows.Forms;
using FTN.ESI.SIMES.CIM.Parser;
using FTN.ESI.SIMES.CIM.Model;
using System.IO;

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
            int cntClasses = -1;
            int cntProps = -1;
            int cntComments = -1;
            try
            {
                profile = null;
                using (FileStream fs = File.Open(textBoxCIMProfile.Text, FileMode.Open))
                {
                    ProfileLoader rdfParser = new ProfileLoader();
                    profile = rdfParser.LoadProfileDocument(fs, textBoxCIMProfile.Text);
                    cntClasses = rdfParser.cntClasses;
                    cntProps = rdfParser.cntProps;
                    cntComments = rdfParser.cntComments;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format("An error occurred.\n\n{0}", e.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            PrintProfile(cntClasses, cntProps, cntComments);
            RefreshControls();
        }

        private void PrintProfile(int cntClasses, int cntProps, int cntComments)
        {
            richTextBoxProfile.Clear();
            if (profile != null)
            {
                richTextBoxProfile.Text = profile.ToString();
            }
            counterValues.Clear();
            counterValues.Text = $"Classes count {cntClasses}\n" +
                $"Props count {cntProps}\n" +
                $"Comments count {cntComments}\n";
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

        #endregion Event Handlers:

        private void richTextBoxProfile_TextChanged(object sender, EventArgs e)
        {
        }
    }
}