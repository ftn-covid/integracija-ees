namespace ModelLabsApp
{
	partial class ModelLabsAppForm
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
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelCIMXMLFile = new System.Windows.Forms.Label();
            this.textBoxCIMFile = new System.Windows.Forms.TextBox();
            this.buttonBrowseLocation = new System.Windows.Forms.Button();
            this.buttonLoadCIM = new System.Windows.Forms.Button();
            this.toolTipControl = new System.Windows.Forms.ToolTip(this.components);
            this.resultTbx = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelMain.ColumnCount = 4;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMain.Controls.Add(this.labelCIMXMLFile, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.textBoxCIMFile, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonBrowseLocation, 3, 0);
            this.tableLayoutPanelMain.Controls.Add(this.buttonLoadCIM, 3, 1);
            this.tableLayoutPanelMain.Controls.Add(this.resultTbx, 1, 2);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(579, 451);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelCIMXMLFile
            // 
            this.labelCIMXMLFile.AutoSize = true;
            this.labelCIMXMLFile.Location = new System.Drawing.Point(5, 13);
            this.labelCIMXMLFile.Margin = new System.Windows.Forms.Padding(5, 13, 3, 3);
            this.labelCIMXMLFile.Name = "labelCIMXMLFile";
            this.labelCIMXMLFile.Size = new System.Drawing.Size(75, 13);
            this.labelCIMXMLFile.TabIndex = 1;
            this.labelCIMXMLFile.Text = "CIM/XML file :";
            // 
            // textBoxCIMFile
            // 
            this.textBoxCIMFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCIMFile.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanelMain.SetColumnSpan(this.textBoxCIMFile, 2);
            this.textBoxCIMFile.Location = new System.Drawing.Point(86, 10);
            this.textBoxCIMFile.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.textBoxCIMFile.Name = "textBoxCIMFile";
            this.textBoxCIMFile.ReadOnly = true;
            this.textBoxCIMFile.Size = new System.Drawing.Size(406, 20);
            this.textBoxCIMFile.TabIndex = 9;
            this.textBoxCIMFile.DoubleClick += new System.EventHandler(this.textBoxCIMFile_DoubleClick);
            // 
            // buttonBrowseLocation
            // 
            this.buttonBrowseLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseLocation.Location = new System.Drawing.Point(498, 10);
            this.buttonBrowseLocation.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.buttonBrowseLocation.Name = "buttonBrowseLocation";
            this.buttonBrowseLocation.Size = new System.Drawing.Size(78, 23);
            this.buttonBrowseLocation.TabIndex = 10;
            this.buttonBrowseLocation.Text = "Browse..";
            this.buttonBrowseLocation.UseVisualStyleBackColor = true;
            this.buttonBrowseLocation.Click += new System.EventHandler(this.buttonBrowseLocation_Click);
            // 
            // buttonLoadCIM
            // 
            this.buttonLoadCIM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadCIM.Location = new System.Drawing.Point(498, 46);
            this.buttonLoadCIM.Name = "buttonLoadCIM";
            this.buttonLoadCIM.Size = new System.Drawing.Size(78, 23);
            this.buttonLoadCIM.TabIndex = 11;
            this.buttonLoadCIM.Text = "Load CIM";
            this.buttonLoadCIM.UseVisualStyleBackColor = true;
            this.buttonLoadCIM.Click += new System.EventHandler(this.buttonLoadCIM_Click);
            // 
            // resultTbx
            // 
            this.resultTbx.Location = new System.Drawing.Point(86, 75);
            this.resultTbx.Name = "resultTbx";
            this.resultTbx.Size = new System.Drawing.Size(406, 343);
            this.resultTbx.TabIndex = 12;
            this.resultTbx.Text = "";
            // 
            // ModelLabsAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 451);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "ModelLabsAppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Labs App";
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
		private System.Windows.Forms.Label labelCIMXMLFile;
		private System.Windows.Forms.TextBox textBoxCIMFile;
		private System.Windows.Forms.Button buttonBrowseLocation;
		private System.Windows.Forms.Button buttonLoadCIM;
		private System.Windows.Forms.ToolTip toolTipControl;
        private System.Windows.Forms.RichTextBox resultTbx;
	}
}

