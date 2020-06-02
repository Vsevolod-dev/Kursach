using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace kamparmok
{
    public partial class TableForm : Form
    {
        string file_name;
        public TableForm()
        {
            InitializeComponent();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Нажатие кнопки Открыть
        public void Open_Click(Object sender, EventArgs e)
        {
            //Чистим таблицу
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            for (int i = 0; i < 100; i++)
            {
                dataGridViewTable.Columns.Add("", "");
                dataGridViewTable.Rows.Add();
            }
            //Открываем OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".CSV файлы (*.csv)|*.csv|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    file_name = openFileDialog.FileName;
                    this.Text = "Файл: " + file_name;
                    FileStream fileStream = new FileStream(file_name, FileMode.OpenOrCreate, FileAccess.Read);
                    StreamReader streamReader = new StreamReader(fileStream);
                    Regex regex = new Regex(";");
                    //string s = streamReader.ReadToEnd();
                    //MatchCollection aa = regex.Matches(s);
                    //string a = aa.Count.ToString();
                    //int aint = Convert.ToInt32(a);
                    string[] rows = File.ReadAllLines(openFileDialog.FileName);
                    //int art = rows.Length, art1 = rows.Length - Convert.ToInt32(rows[art - 1]) - Convert.ToInt32(rows[art - 2]) - 2;
                    //int x = aint / art1;
                    //for (int i = 0; i < x; i++)
                    //{
                    //    dataGridViewTable.Columns.Add("", "");
                    //}
                    //for (int i = 0; i < art1 - 1; i++)
                    //{
                    //    dataGridViewTable.Rows.Add(rows[i].Split(';'));
                    //}

                    //for (int i = 0; i < Convert.ToInt32(rows[art - 1]); i++)
                    //{
                    //    dataGridViewTable.Columns[i].HeaderText = rows[i + Convert.ToInt32(rows[art - 2])];

                    //}
                    //for (int i = 0; i < Convert.ToInt32(rows[art - 2]); i++)
                    //{
                    //    dataGridViewTable.Rows[i].HeaderCell.Value = rows[i + Convert.ToInt32(rows[art - 1]) + Convert.ToInt32(rows[art - 2])];

                    //}
                    streamReader.Close();
                }
                catch (Exception Situation) 
                { 
                    MessageBox.Show(Situation.Message, "Error", MessageBoxButtons.OK); 
                }
            }
            else
            {

            }
        }
    }
}
