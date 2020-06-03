namespace kamparmok
{
    partial class TableForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.calculate = new System.Windows.Forms.Button();
            this.labelForIntervals = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewIntervals = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.checkedListBoxAlpha = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntervals)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.createToolStripMenuItem.Text = "Создать";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "Сохранить как";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.AllowUserToOrderColumns = true;
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(12, 27);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.Size = new System.Drawing.Size(763, 411);
            this.dataGridViewTable.TabIndex = 1;
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(784, 183);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 2;
            this.calculate.Text = "Рассчитать";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.Calculate_Button_Click);
            // 
            // labelForIntervals
            // 
            this.labelForIntervals.AutoSize = true;
            this.labelForIntervals.Location = new System.Drawing.Point(781, 467);
            this.labelForIntervals.Name = "labelForIntervals";
            this.labelForIntervals.Size = new System.Drawing.Size(0, 13);
            this.labelForIntervals.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(784, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(781, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите количество интервалов:";
            // 
            // dataGridViewIntervals
            // 
            this.dataGridViewIntervals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIntervals.Location = new System.Drawing.Point(12, 467);
            this.dataGridViewIntervals.Name = "dataGridViewIntervals";
            this.dataGridViewIntervals.Size = new System.Drawing.Size(763, 241);
            this.dataGridViewIntervals.TabIndex = 7;
            this.dataGridViewIntervals.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 451);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Интервалы и частоты";
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.Location = new System.Drawing.Point(781, 67);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(189, 13);
            this.labelAlpha.TabIndex = 9;
            this.labelAlpha.Text = "Введите уровень значимости Alpha:";
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
            this.checkedListBoxAlpha.Location = new System.Drawing.Point(784, 83);
            this.checkedListBoxAlpha.Name = "checkedListBoxAlpha";
            this.checkedListBoxAlpha.Size = new System.Drawing.Size(61, 94);
            this.checkedListBoxAlpha.TabIndex = 11;
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 782);
            this.Controls.Add(this.checkedListBoxAlpha);
            this.Controls.Add(this.labelAlpha);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewIntervals);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelForIntervals);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIntervals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewTable;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Label labelForIntervals;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewIntervals;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.CheckedListBox checkedListBoxAlpha;
    }
}