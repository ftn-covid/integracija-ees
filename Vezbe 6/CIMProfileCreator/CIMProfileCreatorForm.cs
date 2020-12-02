using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TelventDMS.Integration.CIM.Parser;
using TelventDMS.Integration.CIM.Model;
using CIMProfileCreator.Utilities;
using System.Text.RegularExpressions;

namespace CIMProfileCreator
{
	public partial class CIMProfileCreatorForm : Form
	{
		public CIMProfileCreatorForm()
		{
			InitializeComponent();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog fdlg = new OpenFileDialog();
			fdlg.Title = "Open File";
			fdlg.InitialDirectory = string.IsNullOrEmpty(tbProfilePath.Text) ? (@"c:\") : (tbProfilePath.Text);

			fdlg.Filter = "RDFS(*.legacy-rdfs)|*.legacy-rdfs";

			fdlg.RestoreDirectory = true;
			fdlg.Multiselect = false;
			if (fdlg.ShowDialog() == DialogResult.OK)
			{
				tbProfilePath.Text = fdlg.FileName;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (File.Exists(tbProfilePath.Text))
			{
				//if (CheckVersion())//match regex
				{
					if (!string.IsNullOrWhiteSpace(tbNamespace.Text))
					{
						//do generate
						FileStream fs = File.Open(tbProfilePath.Text, FileMode.Open);
						MakeAssembly(fs, tbNamespace.Text, tbFileName.Text, tbProductName.Text);
						fs.Close();
					}
					else
					{
						MessageBox.Show("Namespace can not be empty. Please fill the text box with appropriate namespace name", "Error in namespace string!", MessageBoxButtons.OK);
					}
				}
				//else
			//	{
			//		MessageBox.Show("Version format is not valid. Please enter new version.", "Invalid version",MessageBoxButtons.OK);
			//	}
			}
			else
			{
				MessageBox.Show("Selected profile path does not contain a proper legacy-rdfs profile.", "File does not exist!", MessageBoxButtons.OK);
			}
		}

		public bool CheckVersion()
		{
			bool retVal = false;

			string pattern = @"\d{1,4}\.\d{1,4}\.\d{1,6}\.\d{1,6}";

			Regex reg = new Regex(pattern);

			if(reg.IsMatch(tb_Version.Text.Trim().ToString()))
			{
				retVal = true;
			}

			return retVal;
		}

		public void MakeAssembly(Stream fs, string namespc, string fileName, string productName)
		{
			TimeSpan time = new TimeSpan(0);
			DateTime begin = DateTime.Now;

			ProfileCreator pc = new ProfileCreator();
			StringBuilder sb = pc.CreateProfile(fs, namespc, fileName, productName, chbCreatePackageCore.Checked, tb_Version.Text.Trim());
			tbConsole.Text = sb.ToString();

			DateTime end = DateTime.Now;
			time = end - begin;
			tbConsole.AppendText("\r\nDuration of making DLL file:" + time);
		}
	}
}
