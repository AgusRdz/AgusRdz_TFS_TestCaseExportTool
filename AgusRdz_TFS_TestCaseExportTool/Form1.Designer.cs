namespace AgusRdz_TFS_TestCaseExportTool
{
    partial class frmMain
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
            this.gbExport = new System.Windows.Forms.GroupBox();
            this.NoSubSuite = new System.Windows.Forms.CheckBox();
            this.ExportResults = new System.Windows.Forms.CheckBox();
            this.SeparateSheets = new System.Windows.Forms.CheckBox();
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbTarget = new System.Windows.Forms.GroupBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnFolderBrowse = new System.Windows.Forms.Button();
            this.txtSaveFolder = new System.Windows.Forms.TextBox();
            this.lblDestination = new System.Windows.Forms.Label();
            this.gbSource = new System.Windows.Forms.GroupBox();
            this.comBoxTestPlan = new System.Windows.Forms.ComboBox();
            this.lblTestSuite = new System.Windows.Forms.Label();
            this.treeView_suite = new System.Windows.Forms.TreeView();
            this.lblTestPlan = new System.Windows.Forms.Label();
            this.btnTeamProject = new System.Windows.Forms.Button();
            this.txtTeamProject = new System.Windows.Forms.TextBox();
            this.lblTeamProject = new System.Windows.Forms.Label();
            this.gbExport.SuspendLayout();
            this.gbTarget.SuspendLayout();
            this.gbSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbExport
            // 
            this.gbExport.Controls.Add(this.NoSubSuite);
            this.gbExport.Controls.Add(this.ExportResults);
            this.gbExport.Controls.Add(this.SeparateSheets);
            this.gbExport.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbExport.Location = new System.Drawing.Point(274, 171);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new System.Drawing.Size(378, 174);
            this.gbExport.TabIndex = 19;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "Opciones de exportación:";
            // 
            // NoSubSuite
            // 
            this.NoSubSuite.AutoSize = true;
            this.NoSubSuite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoSubSuite.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.NoSubSuite.Location = new System.Drawing.Point(11, 40);
            this.NoSubSuite.Name = "NoSubSuite";
            this.NoSubSuite.Size = new System.Drawing.Size(315, 34);
            this.NoSubSuite.TabIndex = 14;
            this.NoSubSuite.Text = "Export the selected suite.\r\n(The test cases of the sub suites will not be exporte" +
    "d)";
            this.NoSubSuite.UseVisualStyleBackColor = true;
            // 
            // ExportResults
            // 
            this.ExportResults.AutoSize = true;
            this.ExportResults.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExportResults.Location = new System.Drawing.Point(11, 137);
            this.ExportResults.Name = "ExportResults";
            this.ExportResults.Size = new System.Drawing.Size(134, 19);
            this.ExportResults.TabIndex = 13;
            this.ExportResults.Text = "Export tests results.";
            this.ExportResults.UseVisualStyleBackColor = true;
            // 
            // SeparateSheets
            // 
            this.SeparateSheets.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SeparateSheets.Location = new System.Drawing.Point(11, 89);
            this.SeparateSheets.Name = "SeparateSheets";
            this.SeparateSheets.Size = new System.Drawing.Size(323, 42);
            this.SeparateSheets.TabIndex = 0;
            this.SeparateSheets.Text = "Export each set of tests on separate sheets.";
            this.SeparateSheets.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(274, 365);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(88, 25);
            this.btnHelp.TabIndex = 20;
            this.btnHelp.Text = "About...";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(469, 365);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(82, 25);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Start";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(570, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 25);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbTarget
            // 
            this.gbTarget.Controls.Add(this.txtFileName);
            this.gbTarget.Controls.Add(this.lblFileName);
            this.gbTarget.Controls.Add(this.btnFolderBrowse);
            this.gbTarget.Controls.Add(this.txtSaveFolder);
            this.gbTarget.Controls.Add(this.lblDestination);
            this.gbTarget.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTarget.Location = new System.Drawing.Point(274, 21);
            this.gbTarget.Name = "gbTarget";
            this.gbTarget.Size = new System.Drawing.Size(378, 144);
            this.gbTarget.TabIndex = 15;
            this.gbTarget.TabStop = false;
            this.gbTarget.Text = "Target:";
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.White;
            this.txtFileName.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(11, 98);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(323, 24);
            this.txtFileName.TabIndex = 5;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.Location = new System.Drawing.Point(8, 75);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(115, 15);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "Exported File Name:";
            // 
            // btnFolderBrowse
            // 
            this.btnFolderBrowse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFolderBrowse.Location = new System.Drawing.Point(253, 40);
            this.btnFolderBrowse.Name = "btnFolderBrowse";
            this.btnFolderBrowse.Size = new System.Drawing.Size(81, 28);
            this.btnFolderBrowse.TabIndex = 4;
            this.btnFolderBrowse.Text = "Browse...";
            this.btnFolderBrowse.UseVisualStyleBackColor = true;
            // 
            // txtSaveFolder
            // 
            this.txtSaveFolder.BackColor = System.Drawing.Color.White;
            this.txtSaveFolder.Enabled = false;
            this.txtSaveFolder.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaveFolder.ForeColor = System.Drawing.Color.Black;
            this.txtSaveFolder.Location = new System.Drawing.Point(11, 42);
            this.txtSaveFolder.Name = "txtSaveFolder";
            this.txtSaveFolder.ReadOnly = true;
            this.txtSaveFolder.Size = new System.Drawing.Size(236, 24);
            this.txtSaveFolder.TabIndex = 7;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestination.Location = new System.Drawing.Point(8, 19);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(130, 15);
            this.lblDestination.TabIndex = 0;
            this.lblDestination.Text = "File location to export:";
            // 
            // gbSource
            // 
            this.gbSource.Controls.Add(this.comBoxTestPlan);
            this.gbSource.Controls.Add(this.lblTestSuite);
            this.gbSource.Controls.Add(this.treeView_suite);
            this.gbSource.Controls.Add(this.lblTestPlan);
            this.gbSource.Controls.Add(this.btnTeamProject);
            this.gbSource.Controls.Add(this.txtTeamProject);
            this.gbSource.Controls.Add(this.lblTeamProject);
            this.gbSource.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSource.Location = new System.Drawing.Point(24, 21);
            this.gbSource.Name = "gbSource";
            this.gbSource.Size = new System.Drawing.Size(244, 369);
            this.gbSource.TabIndex = 16;
            this.gbSource.TabStop = false;
            this.gbSource.Text = "Origen";
            this.gbSource.Enter += new System.EventHandler(this.gbSource_Enter);
            // 
            // comBoxTestPlan
            // 
            this.comBoxTestPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comBoxTestPlan.DropDownWidth = 200;
            this.comBoxTestPlan.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comBoxTestPlan.FormattingEnabled = true;
            this.comBoxTestPlan.Location = new System.Drawing.Point(11, 98);
            this.comBoxTestPlan.Name = "comBoxTestPlan";
            this.comBoxTestPlan.Size = new System.Drawing.Size(215, 23);
            this.comBoxTestPlan.TabIndex = 2;
            // 
            // lblTestSuite
            // 
            this.lblTestSuite.AutoSize = true;
            this.lblTestSuite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestSuite.Location = new System.Drawing.Point(8, 139);
            this.lblTestSuite.Name = "lblTestSuite";
            this.lblTestSuite.Size = new System.Drawing.Size(61, 15);
            this.lblTestSuite.TabIndex = 12;
            this.lblTestSuite.Text = "Test Suite:";
            // 
            // treeView_suite
            // 
            this.treeView_suite.AllowDrop = true;
            this.treeView_suite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_suite.HideSelection = false;
            this.treeView_suite.Location = new System.Drawing.Point(11, 160);
            this.treeView_suite.Name = "treeView_suite";
            this.treeView_suite.Size = new System.Drawing.Size(217, 200);
            this.treeView_suite.TabIndex = 9;
            // 
            // lblTestPlan
            // 
            this.lblTestPlan.AutoSize = true;
            this.lblTestPlan.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestPlan.Location = new System.Drawing.Point(8, 75);
            this.lblTestPlan.Name = "lblTestPlan";
            this.lblTestPlan.Size = new System.Drawing.Size(59, 15);
            this.lblTestPlan.TabIndex = 0;
            this.lblTestPlan.Text = "Test Plan:";
            // 
            // btnTeamProject
            // 
            this.btnTeamProject.Location = new System.Drawing.Point(191, 43);
            this.btnTeamProject.Name = "btnTeamProject";
            this.btnTeamProject.Size = new System.Drawing.Size(35, 23);
            this.btnTeamProject.TabIndex = 1;
            this.btnTeamProject.Text = "...";
            this.btnTeamProject.UseVisualStyleBackColor = true;
            // 
            // txtTeamProject
            // 
            this.txtTeamProject.BackColor = System.Drawing.Color.White;
            this.txtTeamProject.Enabled = false;
            this.txtTeamProject.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamProject.ForeColor = System.Drawing.Color.Black;
            this.txtTeamProject.Location = new System.Drawing.Point(11, 42);
            this.txtTeamProject.Name = "txtTeamProject";
            this.txtTeamProject.ReadOnly = true;
            this.txtTeamProject.Size = new System.Drawing.Size(172, 24);
            this.txtTeamProject.TabIndex = 0;
            // 
            // lblTeamProject
            // 
            this.lblTeamProject.AutoSize = true;
            this.lblTeamProject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamProject.Location = new System.Drawing.Point(8, 21);
            this.lblTeamProject.Name = "lblTeamProject";
            this.lblTeamProject.Size = new System.Drawing.Size(147, 15);
            this.lblTeamProject.TabIndex = 0;
            this.lblTeamProject.Text = "Visual Studio Connection:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 411);
            this.Controls.Add(this.gbExport);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbTarget);
            this.Controls.Add(this.gbSource);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TFS Test Case Export Tool";
            this.gbExport.ResumeLayout(false);
            this.gbExport.PerformLayout();
            this.gbTarget.ResumeLayout(false);
            this.gbTarget.PerformLayout();
            this.gbSource.ResumeLayout(false);
            this.gbSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbExport;
        private System.Windows.Forms.CheckBox NoSubSuite;
        private System.Windows.Forms.CheckBox ExportResults;
        private System.Windows.Forms.CheckBox SeparateSheets;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbTarget;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnFolderBrowse;
        private System.Windows.Forms.TextBox txtSaveFolder;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.GroupBox gbSource;
        private System.Windows.Forms.ComboBox comBoxTestPlan;
        private System.Windows.Forms.Label lblTestSuite;
        private System.Windows.Forms.TreeView treeView_suite;
        private System.Windows.Forms.Label lblTestPlan;
        private System.Windows.Forms.Button btnTeamProject;
        private System.Windows.Forms.TextBox txtTeamProject;
        private System.Windows.Forms.Label lblTeamProject;
    }
}

