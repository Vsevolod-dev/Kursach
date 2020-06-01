using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kamparmok
{
    public partial class MDIparent : Form
    {
        public MDIparent()
        {
            InitializeComponent();
        }
        //Открыть в MenuStrip
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            TableForm tableForm = new TableForm();
            tableForm.MdiParent = this;
            tableForm.Show();
            tableForm.Open_Click(this, null); //метод на TableForm
        }
        //Создать в MenuStrip
        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Сохранить в MenuStrip
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Сохранить как.. в MenuStrip
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Выход в MenuStrip
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
