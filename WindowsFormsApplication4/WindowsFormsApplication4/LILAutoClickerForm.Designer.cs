namespace LIL
{
    partial class LILAutoClickerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LILAutoClickerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Exitbutton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CountertextBox = new System.Windows.Forms.TextBox();
            this.Refreshbutton = new System.Windows.Forms.Button();
            this.DelaynumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RepeatnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.ProcessNameComboBox = new System.Windows.Forms.ComboBox();
            this.Stopbutton = new System.Windows.Forms.Button();
            this.Playbutton = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportConfigurationFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aBOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLILAutoClickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.RandomcheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DelaynumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatnumericUpDown)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Process name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Key:";
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Location = new System.Drawing.Point(95, 60);
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(160, 20);
            this.KeyTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Delay (ms):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Repeat for:";
            // 
            // Exitbutton
            // 
            this.Exitbutton.Image = global::LILAutoClicker.Properties.Resources.logout01;
            this.Exitbutton.Location = new System.Drawing.Point(180, 210);
            this.Exitbutton.Name = "Exitbutton";
            this.Exitbutton.Size = new System.Drawing.Size(75, 77);
            this.Exitbutton.TabIndex = 8;
            this.Exitbutton.UseVisualStyleBackColor = true;
            this.Exitbutton.Click += new System.EventHandler(this.Exitbutton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Counter:";
            // 
            // CountertextBox
            // 
            this.CountertextBox.Location = new System.Drawing.Point(95, 150);
            this.CountertextBox.Name = "CountertextBox";
            this.CountertextBox.ReadOnly = true;
            this.CountertextBox.Size = new System.Drawing.Size(122, 20);
            this.CountertextBox.TabIndex = 12;
            this.CountertextBox.TabStop = false;
            // 
            // Refreshbutton
            // 
            this.Refreshbutton.Font = new System.Drawing.Font("Segoe UI Black", 12F);
            this.Refreshbutton.Location = new System.Drawing.Point(225, 145);
            this.Refreshbutton.Name = "Refreshbutton";
            this.Refreshbutton.Size = new System.Drawing.Size(30, 30);
            this.Refreshbutton.TabIndex = 5;
            this.Refreshbutton.Text = "↻";
            this.Refreshbutton.UseVisualStyleBackColor = true;
            this.Refreshbutton.Click += new System.EventHandler(this.Refreshbutton_Click);
            // 
            // DelaynumericUpDown
            // 
            this.DelaynumericUpDown.Location = new System.Drawing.Point(95, 90);
            this.DelaynumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.DelaynumericUpDown.Name = "DelaynumericUpDown";
            this.DelaynumericUpDown.Size = new System.Drawing.Size(160, 20);
            this.DelaynumericUpDown.TabIndex = 3;
            // 
            // RepeatnumericUpDown
            // 
            this.RepeatnumericUpDown.Location = new System.Drawing.Point(95, 120);
            this.RepeatnumericUpDown.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.RepeatnumericUpDown.Name = "RepeatnumericUpDown";
            this.RepeatnumericUpDown.Size = new System.Drawing.Size(160, 20);
            this.RepeatnumericUpDown.TabIndex = 4;
            // 
            // ProcessNameComboBox
            // 
            this.ProcessNameComboBox.FormattingEnabled = true;
            this.ProcessNameComboBox.Location = new System.Drawing.Point(95, 30);
            this.ProcessNameComboBox.Name = "ProcessNameComboBox";
            this.ProcessNameComboBox.Size = new System.Drawing.Size(160, 21);
            this.ProcessNameComboBox.Sorted = true;
            this.ProcessNameComboBox.TabIndex = 1;
            this.ProcessNameComboBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProcessNameComboBox_MouseDown);
            // 
            // Stopbutton
            // 
            this.Stopbutton.Image = global::LILAutoClicker.Properties.Resources.iconfinder_button_black_stop_40711;
            this.Stopbutton.Location = new System.Drawing.Point(95, 210);
            this.Stopbutton.Name = "Stopbutton";
            this.Stopbutton.Size = new System.Drawing.Size(75, 77);
            this.Stopbutton.TabIndex = 7;
            this.Stopbutton.UseVisualStyleBackColor = true;
            this.Stopbutton.Click += new System.EventHandler(this.Stopbutton_Click);
            // 
            // Playbutton
            // 
            this.Playbutton.Image = global::LILAutoClicker.Properties.Resources.iconfinder_15_3049264;
            this.Playbutton.Location = new System.Drawing.Point(10, 210);
            this.Playbutton.Name = "Playbutton";
            this.Playbutton.Size = new System.Drawing.Size(75, 77);
            this.Playbutton.TabIndex = 6;
            this.Playbutton.UseVisualStyleBackColor = true;
            this.Playbutton.Click += new System.EventHandler(this.Playbutton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.LightGray;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aBOUTToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(265, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presetToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // presetToolStripMenuItem
            // 
            this.presetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportConfigurationToolStripMenuItem,
            this.ImportConfigurationFromFileToolStripMenuItem});
            this.presetToolStripMenuItem.Name = "presetToolStripMenuItem";
            this.presetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.presetToolStripMenuItem.Text = "Manage";
            // 
            // ExportConfigurationToolStripMenuItem
            // 
            this.ExportConfigurationToolStripMenuItem.Name = "ExportConfigurationToolStripMenuItem";
            this.ExportConfigurationToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.ExportConfigurationToolStripMenuItem.Text = "Export configuration to file...";
            this.ExportConfigurationToolStripMenuItem.Click += new System.EventHandler(this.ExportConfigurationToolStripMenuItem_Click);
            // 
            // ImportConfigurationFromFileToolStripMenuItem
            // 
            this.ImportConfigurationFromFileToolStripMenuItem.Name = "ImportConfigurationFromFileToolStripMenuItem";
            this.ImportConfigurationFromFileToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.ImportConfigurationFromFileToolStripMenuItem.Text = "Import configuration from file...";
            this.ImportConfigurationFromFileToolStripMenuItem.Click += new System.EventHandler(this.ImportConfigurationFromFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // aBOUTToolStripMenuItem
            // 
            this.aBOUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutLILAutoClickerToolStripMenuItem});
            this.aBOUTToolStripMenuItem.Name = "aBOUTToolStripMenuItem";
            this.aBOUTToolStripMenuItem.Size = new System.Drawing.Size(24, 20);
            this.aBOUTToolStripMenuItem.Text = "?";
            // 
            // aboutLILAutoClickerToolStripMenuItem
            // 
            this.aboutLILAutoClickerToolStripMenuItem.Name = "aboutLILAutoClickerToolStripMenuItem";
            this.aboutLILAutoClickerToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.aboutLILAutoClickerToolStripMenuItem.Text = "About LILAutoClicker";
            this.aboutLILAutoClickerToolStripMenuItem.Click += new System.EventHandler(this.AboutLILAutoClickerToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Randomize:";
            // 
            // RandomcheckBox
            // 
            this.RandomcheckBox.AutoSize = true;
            this.RandomcheckBox.Location = new System.Drawing.Point(95, 180);
            this.RandomcheckBox.Name = "RandomcheckBox";
            this.RandomcheckBox.Size = new System.Drawing.Size(15, 14);
            this.RandomcheckBox.TabIndex = 15;
            this.RandomcheckBox.UseVisualStyleBackColor = true;
            // 
            // LILAutoClickerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(190)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(265, 296);
            this.Controls.Add(this.RandomcheckBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ProcessNameComboBox);
            this.Controls.Add(this.RepeatnumericUpDown);
            this.Controls.Add(this.DelaynumericUpDown);
            this.Controls.Add(this.Refreshbutton);
            this.Controls.Add(this.CountertextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Exitbutton);
            this.Controls.Add(this.Stopbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Playbutton);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "LILAutoClickerForm";
            this.Text = "LILAutoClicker";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LILAutoClickerForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.DelaynumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatnumericUpDown)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Playbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Stopbutton;
        private System.Windows.Forms.Button Exitbutton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox CountertextBox;
        private System.Windows.Forms.Button Refreshbutton;
        private System.Windows.Forms.NumericUpDown DelaynumericUpDown;
        private System.Windows.Forms.NumericUpDown RepeatnumericUpDown;
        private System.Windows.Forms.ComboBox ProcessNameComboBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem aBOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutLILAutoClickerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExportConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox RandomcheckBox;
        private System.Windows.Forms.ToolStripMenuItem ImportConfigurationFromFileToolStripMenuItem;
    }
}

