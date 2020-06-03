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
            double max = Convert.ToDouble(dataGridViewTable[0, 0].Value); //минимальное значение в таблице
            double min = Convert.ToDouble(dataGridViewTable[0, 0].Value); //максимальное значение в таблице

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

            double rangeOfVariation = max - min; //размах вариации

            int numberOfIntervals = Convert.ToInt32(textBox1.Text); //количество интервалов

            double step = rangeOfVariation / numberOfIntervals; //длина интервала

            dataGridViewIntervals.Columns.Add("", "Интервал"); //левый интервал [0, i]
            dataGridViewIntervals.Columns.Add("", "Интервал"); //правый интервал [1, i]
            dataGridViewIntervals.Columns.Add("", "Частоты"); //третий столбец для частот [2, i]
            dataGridViewIntervals.Columns.Add("", "Середины интервалов"); //четвертый столбец для середин интервалов [3, i]

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт интервалов
            {
                dataGridViewIntervals.Rows.Add(min, Math.Round(min + step, 2));
                min = Convert.ToDouble(dataGridViewIntervals[1, i].Value);
            }

            double leftBorder, rightBorder; //границы интервалов
            double middleValue = 0; //среднее значение
            int frequencyCount; //счётчик частот
            int frequencySum = 0; //сумма частот
            double[] normDistr = new double [numberOfIntervals]; //нормальное распределение
            double[] middleIntervals = new double[numberOfIntervals]; //середины интервалов
            double[] frequency = new double[numberOfIntervals]; //частоты
            double sumHelp = 0;

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
            {
                frequencyCount = 0; //частота
                leftBorder = Convert.ToDouble(dataGridViewIntervals[0, i].Value); //берём левый столбик
                rightBorder = Convert.ToDouble(dataGridViewIntervals[1, i].Value); //берём правый столбик
                for (int k = 0; k < rowsCount; ++k)
                {
                    for (int j = 0; j < colCount; ++j)
                    {   //проверяем по каждому символу входит ли в наш диапозон
                        if (Convert.ToDouble(dataGridViewTable[k, j].Value) >= leftBorder && Convert.ToDouble(dataGridViewTable[k, j].Value) <= rightBorder) 
                        {
                            frequencyCount++;
                            frequencySum++;
                        }
                    }
                }
                middleIntervals[i] = (rightBorder + leftBorder) / 2; //рассчёт середин
                dataGridViewIntervals[3, i].Value = middleIntervals[i]; //вывод середин в таблицу
                frequency[i] = frequencyCount; // рассчёт эмперических частот
                dataGridViewIntervals[2, i].Value = frequency[i]; //вывод
                middleValue += middleIntervals[i] * frequency[i]; //расчёт среднего значения
            }

            middleValue /= frequencySum;

            dataGridViewIntervals.Columns.Add("", "Вспомогательный столбец"); //четвертый столбец для середин интервалов [4, i]

            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
            {
                dataGridViewIntervals[4, i].Value = Math.Pow(middleIntervals[i] - middleValue, 2) * frequency[i];
                sumHelp += Convert.ToDouble(dataGridViewIntervals[4, i].Value); //вспомогательная для числителя
            }
            double[] theorFrequencies = new double[numberOfIntervals]; //теоретические частоты
            double sumTheorFrequencies = 0; //сумма теоретических частот
            double Xemp = 0; //Х^2 эмпирический            1   2     3     4     5     6     7     8     9     10
            double[,] PirsonTable = new double[6, 10] { { 6.6, 9.2, 11.3, 13.3, 15.1, 16.8, 18.5, 20.1, 21.7, 23.2 }, //0.01
                                                        { 5.0, 7.4, 9.4, 11.1, 12.8, 14.4, 16.0, 17.5, 19.0, 20.5 }, //0.025
                                                        { 3.8, 6.0, 7.8, 9.5, 11.1, 12.6, 14.1, 15.5, 16.9, 18.3 }, //0.05
                                                        { 0.0039, 0.103, 0.352, 0.711, 1.15, 1.64, 2.17, 2.73, 3.33, 3.94 }, //0.095 
                                                        { 0.00098, 0.051, 0.216, 0.484, 0.831, 1.24, 1.69, 2.18, 2.70, 3.25 }, //0.0975
                                                        { 0.00016, 0.020, 0.115, 0.297, 0.554, 0.872, 1.24, 1.65, 2.09, 2.56 } }; //0.099
            
            double Xtheor = 0; //Х^2 теоретический
            double stdDev = Math.Sqrt(sumHelp / (rowsCount * colCount)); //стандартное отклонение
            dataGridViewIntervals.Columns.Add("", "Частоты теоретические"); //создание столбца нормальное распределение
            for (int i = 0; i < numberOfIntervals; ++i) //расчет норм расп
            {
                normDistr[i] = (1 / (Math.Sqrt(2 * 3.14159265) * stdDev)) * 
                    Math.Pow(2.71828, (-Math.Pow(middleIntervals[i]-stdDev,2))/(2*Math.Pow(stdDev,2))); //формула норм распределения
                theorFrequencies[i] = normDistr[i] * (colCount * rowsCount) * step; //нахождение теоретической частоты
                dataGridViewIntervals[5, i].Value = theorFrequencies[i];
                sumTheorFrequencies += theorFrequencies[i]; //сумма теоретической частоты
                Xemp += Math.Pow(frequency[i] - theorFrequencies[i],2)/ theorFrequencies[i]; //рассчёт Хи эмперической
            }
            
            int indexAlpha = checkedListBoxAlpha.SelectedIndex; //берёт индекс последнего нажатого варианта из листа
            int degressFreedom = numberOfIntervals - 2/*количество расчетов, у нас Ср. знач. и Станд. откл.*/ - 1/*просто -1*/; //число степеней свободы
            Xtheor = PirsonTable[indexAlpha, degressFreedom]; //рассчёт Хи теоритической
            labelForIntervals.Text = "Количество частот: " + frequencySum +
                                     "\nСреднее значение середин интервалов: " + middleValue +
                                     "\nСтандартное отклонение: " + stdDev +
                                     "\nШаг: " + step +
                                     "\nСумма теор. частот: " + sumTheorFrequencies +
                                     "\nЧисло степеней свободы: " + degressFreedom +
                                     "\nЧисло Alpha: " + indexAlpha +
                                     "\nХ^2 эмперическая: " + Xemp +
                                     "\nХ^2 теоретическая: " + Xtheor;
            if (Xemp <= Xtheor) 
            {
                labelForIntervals.Text += "\nВыборка подчиняется нормальному\n закону распределения!";
            }
            else
            {
                labelForIntervals.Text += "\nОшибка! Выборка не подчиняется нормальному\n закону распределения!";
            }
        }
        



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
