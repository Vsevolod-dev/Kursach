using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//inlcude library
using System.IO;
using System.Text.RegularExpressions;
using System.Numerics;

namespace kamparmok
{
    public partial class MainForm : Form
    {
        const char separator = ';'; // разделитель в csv файле. Меняешь здесь добавь в possible_char
        private string file_name;// имя файла
        string[] all_rows; // все строки в файле
        int count_all_rows; // количество строк
        int count_all_collumn; // количество столбцов
        //Таблица Пирсона
        double[,] PirsonTable = new double[6, 10] { { 6.6, 9.2, 11.3, 13.3, 15.1, 16.8, 18.5, 20.1, 21.7, 23.2 }, //0.01
                                                        { 5.0, 7.4, 9.4, 11.1, 12.8, 14.4, 16.0, 17.5, 19.0, 20.5 }, //0.025
                                                        { 3.8, 6.0, 7.8, 9.5, 11.1, 12.6, 14.1, 15.5, 16.9, 18.3 }, //0.05
                                                        { 0.0039, 0.103, 0.352, 0.711, 1.15, 1.64, 2.17, 2.73, 3.33, 3.94 }, //0.095 
                                                        { 0.00098, 0.051, 0.216, 0.484, 0.831, 1.24, 1.69, 2.18, 2.70, 3.25 }, //0.0975
                                                        { 0.00016, 0.020, 0.115, 0.297, 0.554, 0.872, 1.24, 1.65, 2.09, 2.56 } }; //0.099
        double min, max; //минимум и максимум
        double rangeOfVariation; //размах вариации
        int numberOfIntervals; //количество интервалов
        double step; //длина интервала
        double leftBorder, rightBorder; //границы интервалов
        double middleValue = 0; //среднее значение
        int frequencyCount; //счётчик частот
        int frequencySum = 0; //сумма частот
        double sumHelp = 0;
        double sumTheorFrequencies = 0; //сумма теоретических частот
        double Xemp = 0; //Х^2 эмпирический
        double Xtheor = 0; //Х^2 теоретический

        public MainForm()
        {
            InitializeComponent();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////ФУНКЦИИ////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //функция для подсчета факториала
        BigInteger factorial(int value) 
        {
            BigInteger result = new BigInteger(1);
            if (value == 1 || value == 0) return result;
            for (int i = 1; i < value; i++)
            {
                result += result * i;
            }
            return result;
        }

        //критери Пирсона
        double Pirson(int k) 
        {
            double[] t01 = new double[] {2.706,4.605,6.251,7.779,9.236,10.645,12.017,13.362,14.684,15.987,17.275,18.549,19.812,21.064,22.307,23.542,24.769,25.989,27.204,
                                            28.412,29.615,30.813,32.007,33.196,34.382,35.563,36.741,37.916,39.087,40.256 };
            return t01[k - 1];
        }

        // Очистка таблиц
        private void clear_table(bool clear_result_table = true, bool clear_input_table = true) 
        {
            if (clear_input_table)
            {
                fInput_table.Rows.Clear();
                fInput_table.Columns.Clear();
            }
            if (clear_result_table)
            {
                fResult_table.Rows.Clear();
                fResult_table.Columns.Clear();
            }
        }

        // Функция проверки строки на лишние символы
        private bool check_row(ref string row)
        {
            // Допустимые символы в файле
            char[] possible_char = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '.', ';' };
            // Удалим лишние символы которые могут мешать работе и меняем запятые на точки
            row = row.Replace(",", ".");
            row = row.Replace(" ", "");

            for (int i = 0; i < row.Length; i++)
            {
                bool find_symbol = false;
                foreach (char symbol in possible_char)
                {
                    if (row[i] == symbol)
                    {
                        // Для разделителя нужно проверить наличие идущих двух подряд ; и если ; стоит на первом месте
                        if (row[i] == separator)
                        {
                            if ((i != row.Length - 1) && (row[i + 1] == separator) || i == 0)
                            {
                                return false;
                            }
                        }
                        find_symbol = true;
                        break;
                    }
                }
                if (!find_symbol)
                    return false;
            }
            return true;
        }

        //функция для поиска различных вспомогательных данных
        void Calculate_main()
        {
            clear_table(true, false);
            max = Convert.ToDouble(fInput_table[0, 0].Value); //минимальное значение в таблице
            min = Convert.ToDouble(fInput_table[0, 0].Value); //максимальное значение в таблице

            for (int i = 0; i < count_all_rows; ++i) //поиск мниимального и максимального значения
            {
                for (int j = 0; j < count_all_collumn; ++j)
                {
                    if (Convert.ToDouble(fInput_table[i, j].Value) >= max) //максимум
                    {
                        max = Convert.ToDouble(fInput_table[i, j].Value);
                    }
                    if (Convert.ToDouble(fInput_table[i, j].Value) <= min) //минимум
                    {
                        min = Convert.ToDouble(fInput_table[i, j].Value);
                    }
                }
            }

            rangeOfVariation = max - min; //размах вариации
            numberOfIntervals = Convert.ToInt32(fCount_interval.Text); //количество интервалов
            step = rangeOfVariation / numberOfIntervals; //длина интервала

            fResult_table.Columns.Add("", "Интервал"); //левый интервал [0, i]
            fResult_table.Columns.Add("", "Интервал"); //правый интервал [1, i]
            for (int i = 0; i < numberOfIntervals; ++i) //рассчёт интервалов
            {
                fResult_table.Rows.Add(min, Math.Round(min + step, 2));
                min = Convert.ToDouble(fResult_table[1, i].Value);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////КОНЕЦ ФУНКЦИЙ//////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        private void fOpen_File_Click(object sender, EventArgs e)
        {
            try
            {
                clear_table();
                // диалог открытия файла
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = ".CSV файлы (*.csv)|*.csv|All files(*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    file_name = openFileDialog.FileName;
                    this.Text = "Файл: " + file_name;

                    FileStream file = new FileStream(file_name, FileMode.OpenOrCreate, FileAccess.Read); //переменная для чтения и записи

                    StreamReader StreamReader = new StreamReader(file);
                    string full_text = StreamReader.ReadToEnd();


                    Regex reg = new Regex(";"); //разделитель между ячейками (регулярные выражения)
                    MatchCollection count = reg.Matches(full_text); //поиск reg(;) в full_text и записывает их кол-во в переменную
                    int columnReg = Convert.ToInt32(count.Count.ToString()); //перевод count в int'овый вариант

                    all_rows = File.ReadAllLines(file_name);
                    count_all_rows = all_rows.Length;
                    count_all_collumn = columnReg / count_all_rows + 1;

                    // Создание стобцов
                    for (int i = 0; i < count_all_collumn; ++i)
                    {
                        fInput_table.Columns.Add("", "");
                    }

                    //построчное создание и заполнение строк с разделителями
                    for (int i = 0; i < count_all_rows; ++i)
                    {
                        if (check_row(ref all_rows[i]))
                        {
                            fInput_table.Rows.Add(all_rows[i].Split(separator));
                        }
                    }
                    StreamReader.Close();
                }
                openFileDialog.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при открытии файла"+ ex.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chartIntervals_Click(object sender, EventArgs e)
        {

        }

        //биноминальное распределение
        private void fBinominal_button_Click(object sender, EventArgs e)
        {
            double M = 0;
            int CountOfCell = count_all_collumn * count_all_rows;

            for (int i = 0; i < count_all_rows; ++i) 
            {
                for (int j = 0; j < count_all_collumn; ++j)
                {
                    M = M + Convert.ToInt32(fInput_table[i, j].Value);
                }
            }

            M = Math.Round(M / CountOfCell, 5);
            double p = M / CountOfCell;
            double q = 1 - p;
            double P = 0;
            BigInteger P1 = 0;

            for (int i = 0; i < numberOfIntervals; i++)
            {
                P1 = factorial(CountOfCell) / (factorial(i) * factorial(CountOfCell - i));
                P = (double)(P1) * Math.Pow(p, i) * Math.Pow(q, CountOfCell - i);
                fResult_table[3, i].Value = Math.Round(P, 4);
            }

            for (int i = 0; i < numberOfIntervals; i++)
            {
                fResult_table[4, i].Value = Convert.ToDouble(fResult_table[3, i].Value) * CountOfCell;
                fResult_table[5, i].Value = Math.Round((Convert.ToDouble(fResult_table[2, i].Value) - Convert.ToDouble(fResult_table[4, i].Value)) * (Convert.ToDouble(fResult_table[2, i].Value) - Convert.ToDouble(fResult_table[4, i].Value)) / Convert.ToDouble(fResult_table[4, i].Value), 4);
            }

            for (int i = 0; i < numberOfIntervals; i++)
            {
                Xemp = Xemp + Convert.ToDouble(fResult_table[5, i].Value);
            }

            label1.Text = Xemp.ToString();
            int k = numberOfIntervals - 2 - 1;
            double Xtheor = Pirson(k);

            if (Xemp <= Xtheor)
            {
                labelForIntervals.Text += "\nВыборка подчиняется нормальному\n закону распределения!";
            }
            else
            {
                labelForIntervals.Text += "\nОшибка! Выборка не подчиняется нормальному\n закону распределения!";
            }
        }

        //раномерное распределение
        private void buttonUniform_Click_1(object sender, EventArgs e)
        {
            try
            {
                Calculate_main();
                fResult_table.Columns.Add("", "ss");
                fResult_table.Columns.Add("", "sss");
                fResult_table.Columns.Add("", "ssss");
                double P = 1 / Convert.ToDouble(numberOfIntervals);
                for (int i = 0; i < numberOfIntervals; ++i)
                {
                    fResult_table[2, i].Value = Math.Round(P, 4);
                    fResult_table[3, i].Value = Convert.ToDouble(fResult_table[2, i].Value) * (count_all_collumn * count_all_rows);
                    fResult_table[4, i].Value = Math.Round((Convert.ToDouble(fResult_table[1, i].Value) - Convert.ToDouble(fResult_table[3, i].Value))
                    * (Convert.ToDouble(fResult_table[1, i].Value) - Convert.ToDouble(fResult_table[3, i].Value)) / Convert.ToDouble(fResult_table[3, i].Value), 4);
                }
                for (int i = 0; i < numberOfIntervals; ++i)
                {
                    Xemp += Xemp + Convert.ToDouble(fResult_table[4, i].Value);
                }
                double Xtheor = 0;
                int indexAlpha = checkedListBoxAlpha.SelectedIndex; //берёт индекс последнего нажатого варианта из листа
                int degressFreedom = numberOfIntervals - 0/*количество расчетов, у нас их нет*/ - 1/*просто -1*/; //число степеней свободы
                Xtheor = PirsonTable[indexAlpha, degressFreedom];
                labelForIntervals.Text = "\n\n\nemp " + Xemp + "theor " + Xtheor;
                if (Xemp <= Xtheor)
                {
                    labelForIntervals.Text += "\nВыборка подчиняется нормальному\n закону распределения!";
                }
                else
                {
                    labelForIntervals.Text += "\nОшибка! Выборка не подчиняется нормальному\n закону распределения!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при рассчетах \n" + ex.Message);
            }
            
        }

        //нормальное распределение
        private void fCalculation_button_Click(object sender, EventArgs e)
        {
            try
            {
                Calculate_main();
                fResult_table.Columns.Add("", "Частоты"); //третий столбец для частот [2, i]
                fResult_table.Columns.Add("", "Середины интервалов"); //четвертый столбец для середин интервалов [3, i]
                double[] normDistr = new double[numberOfIntervals]; //нормальное распределение
                double[] middleIntervals = new double[numberOfIntervals]; //середины интервалов
                double[] frequency = new double[numberOfIntervals]; //частоты


                for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
                {
                    frequencyCount = 0; //частота
                    leftBorder = Convert.ToDouble(fResult_table[0, i].Value); //берём левый столбик
                    rightBorder = Convert.ToDouble(fResult_table[1, i].Value); //берём правый столбик
                    for (int k = 0; k < count_all_rows; ++k)
                    {
                        for (int j = 0; j < count_all_collumn; ++j)
                        {   //проверяем по каждому символу входит ли в наш диапозон
                            if (Convert.ToDouble(fInput_table[k, j].Value) >= leftBorder && Convert.ToDouble(fInput_table[k, j].Value) <= rightBorder)
                            {
                                frequencyCount++;
                                frequencySum++;
                            }
                        }
                    }
                    middleIntervals[i] = (rightBorder + leftBorder) / 2; //рассчёт середин
                    fResult_table[3, i].Value = middleIntervals[i]; //вывод середин в таблицу
                    frequency[i] = frequencyCount; // рассчёт эмперических частот
                    fResult_table[2, i].Value = frequency[i]; //вывод
                    middleValue += middleIntervals[i] * frequency[i]; //расчёт среднего значения
                }

                middleValue /= frequencySum;

                fResult_table.Columns.Add("", "Вспомогательный столбец"); //четвертый столбец для середин интервалов [4, i]

                for (int i = 0; i < numberOfIntervals; ++i) //рассчёт частот
                {
                    fResult_table[4, i].Value = Math.Pow(middleIntervals[i] - middleValue, 2) * frequency[i];
                    sumHelp += Convert.ToDouble(fResult_table[4, i].Value); //вспомогательная для числителя
                }
                double[] theorFrequencies = new double[numberOfIntervals]; //теоретические частоты

                double stdDev = Math.Sqrt(sumHelp / (count_all_rows * count_all_collumn)); //стандартное отклонение
                fResult_table.Columns.Add("", "Частоты теоретические"); //создание столбца нормальное распределение
                for (int i = 0; i < numberOfIntervals; ++i) //расчет норм расп
                {
                    normDistr[i] = (1 / (Math.Sqrt(2 * 3.14159265) * stdDev)) *
                        Math.Pow(2.71828, (-Math.Pow(middleIntervals[i] - stdDev, 2)) / (2 * Math.Pow(stdDev, 2))); //формула норм распределения
                    theorFrequencies[i] = normDistr[i] * (count_all_collumn * count_all_rows) * step; //нахождение теоретической частоты
                    fResult_table[5, i].Value = theorFrequencies[i];
                    sumTheorFrequencies += theorFrequencies[i]; //сумма теоретической частоты
                    Xemp += Math.Pow(frequency[i] - theorFrequencies[i], 2) / theorFrequencies[i]; //рассчёт Хи эмперической
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
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при рассчетах \n" + ex.Message);
            }
        }

        //построение графика
        private void buttonChart_Click_1(object sender, EventArgs e)
        {
            Calculate_main();
            if (fResult_table[0, 0].Value != null)
            {
                for (int i = 0; i < numberOfIntervals; ++i)
                {
                    chartIntervals.Series[0].Points.AddXY((Convert.ToDouble(fResult_table[1, i].Value) + Convert.ToDouble(fResult_table[0, i].Value)) / 2, i);
                    //chartIntervals.Series[1].Points.AddXY((Convert.ToDouble(fResult_table[1, i].Value) + Convert.ToDouble(fResult_table[0, i].Value)) / 2, i);
                }
            }
        }
    }
}