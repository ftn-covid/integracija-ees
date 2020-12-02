namespace CIMProfileCreator
{
    partial class CIMProfileCreatorForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tb_Version = new System.Windows.Forms.TextBox();
            this.chbCreatePackageCore = new System.Windows.Forms.CheckBox();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNamespaceString = new System.Windows.Forms.Label();
            this.tbNamespace = new System.Windows.Forms.TextBox();
            this.tbProfilePath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.tbConsole = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tb_Version);
            this.splitContainer1.Panel1.Controls.Add(this.chbCreatePackageCore);
            this.splitContainer1.Panel1.Controls.Add(this.tbProductName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.tbFileName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.lblNamespaceString);
            this.splitContainer1.Panel1.Controls.Add(this.tbNamespace);
            this.splitContainer1.Panel1.Controls.Add(this.tbProfilePath);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbConsole);
            this.splitContainer1.Size = new System.Drawing.Size(667, 556);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 3;
            // 
            // tb_Version
            // 
            this.tb_Version.Location = new System.Drawing.Point(505, 10);
            this.tb_Version.Name = "tb_Version";
            this.tb_Version.Size = new System.Drawing.Size(150, 20);
            this.tb_Version.TabIndex = 13;
            this.tb_Version.Text = "1.0.0";
            // 
            // chbCreatePackageCore
            // 
            this.chbCreatePackageCore.AutoSize = true;
            this.chbCreatePackageCore.Location = new System.Drawing.Point(411, 44);
            this.chbCreatePackageCore.Name = "chbCreatePackageCore";
            this.chbCreatePackageCore.Size = new System.Drawing.Size(131, 17);
            this.chbCreatePackageCore.TabIndex = 12;
            this.chbCreatePackageCore.Text = "Create Package_Core";
            this.chbCreatePackageCore.UseVisualStyleBackColor = true;
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(355, 41);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(40, 20);
            this.tbProductName.TabIndex = 11;
            this.tbProductName.Text = "Labs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Product name:";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(190, 42);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(77, 20);
            this.tbFileName.TabIndex = 9;
            this.tbFileName.Text = "PowerTransformer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "File name:";
            // 
            // lblNamespaceString
            // 
            this.lblNamespaceString.AutoSize = true;
            this.lblNamespaceString.Location = new System.Drawing.Point(12, 44);
            this.lblNamespaceString.Name = "lblNamespaceString";
            this.lblNamespaceString.Size = new System.Drawing.Size(67, 13);
            this.lblNamespaceString.TabIndex = 7;
            this.lblNamespaceString.Text = "Namespace:";
            // 
            // tbNamespace
            // 
            this.tbNamespace.Location = new System.Drawing.Point(85, 41);
            this.tbNamespace.Name = "tbNamespace";
            this.tbNamespace.Size = new System.Drawing.Size(38, 20);
            this.tbNamespace.TabIndex = 6;
            this.tbNamespace.Text = "FTN";
            // 
            // tbProfilePath
            // 
            this.tbProfilePath.Location = new System.Drawing.Point(93, 12);
            this.tbProfilePath.Name = "tbProfilePath";
            this.tbProfilePath.Size = new System.Drawing.Size(383, 20);
            this.tbProfilePath.TabIndex = 5;
            this.tbProfilePath.Text = @"D:\SSELENA\ALL Work\Work\MyTools\ESI\ModelLabs\DMS_FTN\Profiles\PowerTransformer.legacy-rdfs-augmented";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(548, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Generate Model Definition";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "Open Profile";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tbConsole
            // 
            this.tbConsole.BackColor = System.Drawing.Color.LightGray;
            this.tbConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbConsole.Location = new System.Drawing.Point(0, 0);
            this.tbConsole.Multiline = true;
            this.tbConsole.Name = "tbConsole";
            this.tbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbConsole.Size = new System.Drawing.Size(667, 476);
            this.tbConsole.TabIndex = 0;
            // 
            // CIMProfileCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 556);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CIMProfileCreatorForm";
            this.Text = "CIMProfileCreatorForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label lblNamespaceString;
        private System.Windows.Forms.TextBox tbNamespace;
        private System.Windows.Forms.TextBox tbProfilePath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox tbConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFileName;
		private System.Windows.Forms.TextBox tbProductName;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbCreatePackageCore;
		private System.Windows.Forms.TextBox tb_Version;
    }
}