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
using System.Globalization;

namespace kamparmok
{
    public partial class TableForm : Form
    {
        string file_name;
        string[] rows;
        int rowsCount;
        int columnReg;
        int colCount;

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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ".CSV файлы (*.csv)|*.csv|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                file_name = openFileDialog.FileName;
                this.Text = "Файл: " + file_name;
                FileStream file = new FileStream(file_name, FileMode.OpenOrCreate, FileAccess.Read); //переменная для чтения и записи

                StreamReader StreamReader = new StreamReader(file); //переменная для посимвольного считывания

                Regex reg = new Regex(";"); //разделитель между ячейками (регулярные выражения)

                string full_text = StreamReader.ReadToEnd(); //считывание всех символов в файле и записаль в в переменную

                MatchCollection count = reg.Matches(full_text); //поиск reg(;) в full_text и записывает их кол-во в переменную

                columnReg = Convert.ToInt32(count.Count.ToString()); //перевод count в int'овый вариант

                rows = File.ReadAllLines(file_name); //запись строк

                rowsCount = rows.Length; // кол-во строк

                colCount = columnReg / rowsCount + 1; // кол-во столбцов
                for (int i = 0; i < colCount; ++i) //создание столбцов
                {
                    dataGridViewTable.Columns.Add("", "");
                }

                //когда мы начинаем заполнять файл, это происходит построчно

                for (int i = 0; i < rowsCount; ++i) //создание строк ( с разделителем???? ) цикл работает 5 раз?
                {
                    dataGridViewTable.Rows.Add(rows[i].Split(';'));
                }
                StreamReader.Close();
            }
            else
            {

            }
        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            double max = Convert.ToDouble(dataGridViewTable[0, 0].Value);
            double min = Convert.ToDouble(dataGridViewTable[0, 0].Value);

            for (int i = 0; i < rowsCount; ++i) //поиск мниимального и максимального значения
            {
                for (int j = 0; j <colCount; ++j)
                {
                    if (Convert.ToDouble(dataGridViewTable[i, j].Value) >= max) //максимум
                    {
                        max = Convert.ToDouble(dataGridViewTable[i, j].Value);
                    }
                    if (Convert.ToDouble(dataGridViewTable[i, j].Value) <= min) //минимум
                    {
                        min = Convert.ToDouble(dataGridViewTable[i, j].Value);
                    }
                }
            }

            label1.Text = dataGridViewTable[2, 2].Value.ToString() + min + "\n" + max;

            double rangeOfVariation = max - min; //размах вариации

            int numberOfIntervals = Convert.ToInt32(textBox1.Text); //количество интервалов

            double step = rangeOfVariation / numberOfIntervals; //длина интервала

            dataGridViewIntervals.Columns.Add("", "");
            dataGridViewIntervals.Columns.Add("", "");

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт интервалов
            {
                dataGridViewIntervals.Rows.Add(min, Math.Round(min + step, 2));
                min = Convert.ToDouble(dataGridViewIntervals[1, i].Value);
            }

            dataGridViewIntervals.Columns.Add("", "Частоты"); //третий столбец для частот [2, i]
            dataGridViewIntervals.Columns.Add("", "Середины интервалов"); //четвертый столбец для середин интервалов [3, i]

            double leftBorder, rightBorder; //границы интервалов
            double middleValue = 0; //среднее значение
            int frequencyCount;

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
            {
                frequencyCount = 0; //частота
                leftBorder = Convert.ToDouble(dataGridViewIntervals[0, i].Value); 
                rightBorder = Convert.ToDouble(dataGridViewIntervals[1, i].Value);
                for (int k = 0; k < rowsCount; ++k)
                {
                    for (int j = 0; j < colCount; ++j)
                    {
                        if (Convert.ToDouble(dataGridViewTable[k, j].Value) >= leftBorder && Convert.ToDouble(dataGridViewTable[k, j].Value) <= rightBorder)
                        {
                            frequencyCount++;
                        }
                    }
                }
                dataGridViewIntervals[3, i].Value = (rightBorder + leftBorder) / 2;
                dataGridViewIntervals[2, i].Value = frequencyCount;
                middleValue += Convert.ToDouble(dataGridViewIntervals[3, i].Value) * Convert.ToDouble(dataGridViewIntervals[2, i].Value);
            }

            middleValue /= 100;
            label1.Text += " " + middleValue;

            double sumHelp = 0;

            dataGridViewIntervals.Columns.Add("", "Вспомогательный столбец"); //четвертый столбец для середин интервалов [4, i]

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
            {
                for (int k = 0; k < rowsCount; ++k)
                {
                    for (int j = 0; j < colCount; ++j)
                    {
                        dataGridViewIntervals[4, i].Value = Math.Pow(Convert.ToDouble(dataGridViewIntervals[3, i].Value) - middleValue, 2) * Convert.ToDouble(dataGridViewIntervals[2, i].Value);
                        
                    }
                }
                sumHelp += Convert.ToDouble(dataGridViewIntervals[4, i].Value);
            }

            double stdDev = Math.Sqrt(sumHelp / (rowsCount * colCount));
            }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
