namespace kamparmok
{
    partial class MainForm
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.fInput_table = new System.Windows.Forms.DataGridView();
            this.fResult_table = new System.Windows.Forms.DataGridView();
            this.fCalculation_button = new System.Windows.Forms.Button();
            this.fFile_tool_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fOpen_File = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fMain_menu = new System.Windows.Forms.MenuStrip();
            this.fCount_interval = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBoxAlpha = new System.Windows.Forms.CheckedListBox();
            this.labelForIntervals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fInput_table)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fResult_table)).BeginInit();
            this.fMain_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(78, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelForIntervals);
            this.splitContainer1.Panel2.Controls.Add(this.checkedListBoxAlpha);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.fCount_interval);
            this.splitContainer1.Panel2.Controls.Add(this.fCalculation_button);
            this.splitContainer1.Size = new System.Drawing.Size(629, 450);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.fInput_table);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.fResult_table);
            this.splitContainer2.Size = new System.Drawing.Size(629, 225);
            this.splitContainer2.SplitterDistance = 303;
            this.splitContainer2.TabIndex = 1;
            // 
            // fInput_table
            // 
            this.fInput_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fInput_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fInput_table.Location = new System.Drawing.Point(0, 0);
            this.fInput_table.Name = "fInput_table";
            this.fInput_table.Size = new System.Drawing.Size(303, 225);
            this.fInput_table.TabIndex = 0;
            // 
            // fResult_table
            // 
            this.fResult_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fResult_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fResult_table.Location = new System.Drawing.Point(0, 0);
            this.fResult_table.Name = "fResult_table";
            this.fResult_table.Size = new System.Drawing.Size(322, 225);
            this.fResult_table.TabIndex = 0;
            // 
            // fCalculation_button
            // 
            this.fCalculation_button.Location = new System.Drawing.Point(55, 3);
            this.fCalculation_button.Name = "fCalculation_button";
            this.fCalculation_button.Size = new System.Drawing.Size(141, 23);
            this.fCalculation_button.TabIndex = 0;
            this.fCalculation_button.Text = "Рассчитать";
            this.fCalculation_button.UseVisualStyleBackColor = true;
            this.fCalculation_button.Click += new System.EventHandler(this.fCalculation_button_Click);
            // 
            // fFile_tool_strip
            // 
            this.fFile_tool_strip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.fOpen_File,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.fFile_tool_strip.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fFile_tool_strip.Name = "fFile_tool_strip";
            this.fFile_tool_strip.Size = new System.Drawing.Size(59, 23);
            this.fFile_tool_strip.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.новыйToolStripMenuItem.Text = "Новый";
            // 
            // fOpen_File
            // 
            this.fOpen_File.Name = "fOpen_File";
            this.fOpen_File.Size = new System.Drawing.Size(193, 24);
            this.fOpen_File.Text = "Открыть";
            this.fOpen_File.Click += new System.EventHandler(this.fOpen_File_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(193, 24);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(59, 23);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // fMain_menu
            // 
            this.fMain_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.fMain_menu.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fMain_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fFile_tool_strip,
            this.выходToolStripMenuItem});
            this.fMain_menu.Location = new System.Drawing.Point(0, 0);
            this.fMain_menu.Name = "fMain_menu";
            this.fMain_menu.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.fMain_menu.Size = new System.Drawing.Size(78, 450);
            this.fMain_menu.TabIndex = 0;
            this.fMain_menu.Text = "main_menu";
            // 
            // fCount_interval
            // 
            this.fCount_interval.Location = new System.Drawing.Point(33, 51);
            this.fCount_interval.Name = "fCount_interval";
            this.fCount_interval.Size = new System.Drawing.Size(184, 27);
            this.fCount_interval.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество интервалов";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Уровень значимости ";
            // 
            // checkedListBoxAlpha
            // 
            this.checkedListBoxAlpha.FormattingEnabled = true;
            this.checkedListBoxAlpha.Items.AddRange(new object[] {
            "0,01",
            "0,025",
            "0,05",
            "0,095",
            "0,0975",
            "0,099"});
            this.checkedListBoxAlpha.Location = new System.Drawing.Point(255, 29);
            this.checkedListBoxAlpha.Name = "checkedListBoxAlpha";
            this.checkedListBoxAlpha.Size = new System.Drawing.Size(99, 136);
            this.checkedListBoxAlpha.TabIndex = 12;
            // 
            // labelForIntervals
            // 
            this.labelForIntervals.AutoSize = true;
            this.labelForIntervals.Location = new System.Drawing.Point(427, 12);
            this.labelForIntervals.Name = "labelForIntervals";
            this.labelForIntervals.Size = new System.Drawing.Size(0, 19);
            this.labelForIntervals.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.fMain_menu);
            this.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.fMain_menu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "RefactoringForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fInput_table)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fResult_table)).EndInit();
            this.fMain_menu.ResumeLayout(false);
            this.fMain_menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button fCalculation_button;
        private System.Windows.Forms.ToolStripMenuItem fFile_tool_strip;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fOpen_File;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.MenuStrip fMain_menu;
        private System.Windows.Forms.DataGridView fInput_table;
        private System.Windows.Forms.DataGridView fResult_table;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fCount_interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBoxAlpha;
        private System.Windows.Forms.Label labelForIntervals;
    }
}