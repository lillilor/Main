
namespace LABELREPLACER
{
    partial class LabelReplacerReadExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelReplacerReadExcel));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LabelFilePath = new System.Windows.Forms.TextBox();
            this.LabelFilePathChoose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GeneratePreviewButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.PreviewDataGrid = new System.Windows.Forms.DataGridView();
            this.LineNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LABELID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OLDTXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NEWTXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportExcelFileButton = new System.Windows.Forms.Button();
            this.ExcelGotHeaderLb = new System.Windows.Forms.Label();
            this.ExcelGotHeader = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ExcelParametersGroup = new System.Windows.Forms.GroupBox();
            this.LoadExcelLabelInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.ExcelParametersGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line});
            this.dataGridView.Location = new System.Drawing.Point(5, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(928, 207);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);
            // 
            // Line
            // 
            this.Line.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Line.HeaderText = "LINE";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.Width = 50;
            // 
            // LabelFilePath
            // 
            this.LabelFilePath.Location = new System.Drawing.Point(115, 21);
            this.LabelFilePath.Name = "LabelFilePath";
            this.LabelFilePath.Size = new System.Drawing.Size(765, 20);
            this.LabelFilePath.TabIndex = 3;
            // 
            // LabelFilePathChoose
            // 
            this.LabelFilePathChoose.Location = new System.Drawing.Point(899, 25);
            this.LabelFilePathChoose.Name = "LabelFilePathChoose";
            this.LabelFilePathChoose.Size = new System.Drawing.Size(26, 20);
            this.LabelFilePathChoose.TabIndex = 4;
            this.LabelFilePathChoose.Text = "...";
            this.LabelFilePathChoose.UseVisualStyleBackColor = true;
            this.LabelFilePathChoose.Click += new System.EventHandler(this.LabelFilePathChoose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Label File path";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GeneratePreviewButton);
            this.groupBox1.Controls.Add(this.dataGridView);
            this.groupBox1.Location = new System.Drawing.Point(12, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 261);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA";
            // 
            // GeneratePreviewButton
            // 
            this.GeneratePreviewButton.Location = new System.Drawing.Point(826, 232);
            this.GeneratePreviewButton.Name = "GeneratePreviewButton";
            this.GeneratePreviewButton.Size = new System.Drawing.Size(107, 23);
            this.GeneratePreviewButton.TabIndex = 2;
            this.GeneratePreviewButton.Text = "Generate Preview";
            this.GeneratePreviewButton.UseVisualStyleBackColor = true;
            this.GeneratePreviewButton.Click += new System.EventHandler(this.GeneratePreviewButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ApplyButton);
            this.groupBox2.Controls.Add(this.PreviewDataGrid);
            this.groupBox2.Location = new System.Drawing.Point(12, 440);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(939, 288);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PREVIEW";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(821, 258);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(112, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // PreviewDataGrid
            // 
            this.PreviewDataGrid.AllowUserToOrderColumns = true;
            this.PreviewDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PreviewDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreviewDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LineNum,
            this.LABELID,
            this.OLDTXT,
            this.NEWTXT,
            this.Status});
            this.PreviewDataGrid.Location = new System.Drawing.Point(5, 20);
            this.PreviewDataGrid.Name = "PreviewDataGrid";
            this.PreviewDataGrid.Size = new System.Drawing.Size(928, 232);
            this.PreviewDataGrid.TabIndex = 0;
            // 
            // LineNum
            // 
            this.LineNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LineNum.HeaderText = "LINE";
            this.LineNum.Name = "LineNum";
            this.LineNum.ReadOnly = true;
            this.LineNum.Width = 50;
            // 
            // LABELID
            // 
            this.LABELID.HeaderText = "LABELID";
            this.LABELID.Name = "LABELID";
            this.LABELID.ReadOnly = true;
            // 
            // OLDTXT
            // 
            this.OLDTXT.HeaderText = "OLDTXT";
            this.OLDTXT.Name = "OLDTXT";
            this.OLDTXT.ReadOnly = true;
            // 
            // NEWTXT
            // 
            this.NEWTXT.HeaderText = "NEWTXT";
            this.NEWTXT.Name = "NEWTXT";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Status.HeaderText = "STATUS";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 60;
            // 
            // ImportExcelFileButton
            // 
            this.ImportExcelFileButton.Location = new System.Drawing.Point(5, 52);
            this.ImportExcelFileButton.Name = "ImportExcelFileButton";
            this.ImportExcelFileButton.Size = new System.Drawing.Size(104, 23);
            this.ImportExcelFileButton.TabIndex = 9;
            this.ImportExcelFileButton.Text = "Load excel...";
            this.ImportExcelFileButton.UseVisualStyleBackColor = true;
            this.ImportExcelFileButton.Click += new System.EventHandler(this.ImportExcelFileButton_Click);
            // 
            // ExcelGotHeaderLb
            // 
            this.ExcelGotHeaderLb.AutoSize = true;
            this.ExcelGotHeaderLb.Location = new System.Drawing.Point(6, 20);
            this.ExcelGotHeaderLb.Name = "ExcelGotHeaderLb";
            this.ExcelGotHeaderLb.Size = new System.Drawing.Size(103, 13);
            this.ExcelGotHeaderLb.TabIndex = 10;
            this.ExcelGotHeaderLb.Text = "My excel got header";
            // 
            // ExcelGotHeader
            // 
            this.ExcelGotHeader.AutoSize = true;
            this.ExcelGotHeader.Location = new System.Drawing.Point(115, 19);
            this.ExcelGotHeader.Name = "ExcelGotHeader";
            this.ExcelGotHeader.Size = new System.Drawing.Size(15, 14);
            this.ExcelGotHeader.TabIndex = 11;
            this.ExcelGotHeader.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.LabelFilePath);
            this.groupBox3.Controls.Add(this.LabelFilePathChoose);
            this.groupBox3.Location = new System.Drawing.Point(12, 99);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(939, 68);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "LABEL FILE";
            // 
            // ExcelParametersGroup
            // 
            this.ExcelParametersGroup.Controls.Add(this.LoadExcelLabelInfo);
            this.ExcelParametersGroup.Controls.Add(this.ImportExcelFileButton);
            this.ExcelParametersGroup.Controls.Add(this.ExcelGotHeader);
            this.ExcelParametersGroup.Controls.Add(this.ExcelGotHeaderLb);
            this.ExcelParametersGroup.Location = new System.Drawing.Point(12, 12);
            this.ExcelParametersGroup.Name = "ExcelParametersGroup";
            this.ExcelParametersGroup.Size = new System.Drawing.Size(939, 81);
            this.ExcelParametersGroup.TabIndex = 13;
            this.ExcelParametersGroup.TabStop = false;
            this.ExcelParametersGroup.Text = "EXCEL PARAMETERS";
            this.ExcelParametersGroup.Enter += new System.EventHandler(this.ExcelParametersGroup_Enter);
            // 
            // LoadExcelLabelInfo
            // 
            this.LoadExcelLabelInfo.AutoSize = true;
            this.LoadExcelLabelInfo.Location = new System.Drawing.Point(191, 11);
            this.LoadExcelLabelInfo.Name = "LoadExcelLabelInfo";
            this.LoadExcelLabelInfo.Size = new System.Drawing.Size(28, 13);
            this.LoadExcelLabelInfo.TabIndex = 12;
            this.LoadExcelLabelInfo.Text = "Text";
            this.LoadExcelLabelInfo.Click += new System.EventHandler(this.label2_Click);
            // 
            // LabelReplacerReadExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 740);
            this.Controls.Add(this.ExcelParametersGroup);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LabelReplacerReadExcel";
            this.Text = "LABELREPLACER";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewDataGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ExcelParametersGroup.ResumeLayout(false);
            this.ExcelParametersGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox LabelFilePath;
        private System.Windows.Forms.Button LabelFilePathChoose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView PreviewDataGrid;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button GeneratePreviewButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn LABELID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OLDTXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NEWTXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button ImportExcelFileButton;
        private System.Windows.Forms.Label ExcelGotHeaderLb;
        private System.Windows.Forms.CheckBox ExcelGotHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox ExcelParametersGroup;
        private System.Windows.Forms.Label LoadExcelLabelInfo;
    }
}