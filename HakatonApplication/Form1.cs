using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using NLog;

namespace HakatonApplication
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Переменные для часовых доходов/расходов
        public double ProfitRUB = 0;
        public double ProfitTNG = 0;
        public double ProfitUSD = 0;
        public double EnergyTNG = 0;
        public double EnergyUSD = 0;
        public double EnergyRUB = 0;


        //Функции для расчета дохода/расхода за час/день/месяц/год
        private void Calculations()
        {
            double deviceCount = Convert.ToDouble(numericUpDown1.Value);
            //Функция, которая вычисляет доход/расходы за час для каждого типа устройств отдельно
            if (DataBaseController.formattedList.Contains(comboBox2.Text))
            {
                int index = Array.IndexOf(DataBaseController.formattedList, comboBox2.Text);
                double PUEnergy = Convert.ToDouble(DataBaseController.formattedList[index + 1]);
                double PUProfit = Convert.ToDouble(DataBaseController.formattedList[index + 2]);
                ProfitUSD = PUProfit * deviceCount;
                ProfitTNG = ProfitUSD * 500 * deviceCount;
                ProfitRUB = ProfitUSD * 100 * deviceCount;
                EnergyTNG = PUEnergy * 6.5 * deviceCount;
                EnergyRUB = EnergyTNG / 5 * deviceCount;
                EnergyUSD = EnergyTNG / 500 * deviceCount;
                Console.WriteLine("Energy {0}. Profit {1}",EnergyTNG, ProfitTNG);
                
            }
            else if (DataBaseController.formattedCPUList.Contains(comboBox2.Text))
            {
                int index = Array.IndexOf(DataBaseController.formattedCPUList, comboBox2.Text);
                double CPUEnergy = Convert.ToDouble(DataBaseController.formattedCPUList[index + 1]);
                double CPUProfit = Convert.ToDouble(DataBaseController.formattedCPUList[index + 2]);
                ProfitUSD = CPUProfit * deviceCount;
                ProfitTNG = ProfitUSD * 500 * deviceCount;
                ProfitRUB = ProfitUSD * 100 * deviceCount;
                EnergyTNG = CPUEnergy * 6.5 * deviceCount;
                EnergyRUB = EnergyTNG / 5 * deviceCount;
                EnergyUSD = EnergyTNG / 500 * deviceCount;
                Console.WriteLine("Energy {0}. Profit {1}", EnergyTNG, ProfitTNG);
            }
            else if (DataBaseController.formattedGPUList.Contains(comboBox2.Text))
            {
                int index = Array.IndexOf(DataBaseController.formattedGPUList, comboBox2.Text);
                double GPUEnergy = Convert.ToDouble(DataBaseController.formattedGPUList[index + 1]);
                double GPUProfit = Convert.ToDouble(DataBaseController.formattedGPUList[index + 2]);
                ProfitUSD = GPUProfit * deviceCount;
                ProfitTNG = ProfitUSD * 500 * deviceCount;
                ProfitRUB = ProfitUSD * 100 * deviceCount;
                EnergyTNG = GPUEnergy * 6.5 * deviceCount;
                EnergyRUB = EnergyTNG / 5 * deviceCount;
                EnergyUSD = EnergyTNG / 500 * deviceCount;
                Console.WriteLine("Energy {0}. Profit {1}", EnergyTNG, ProfitTNG);
            }
            else if (DataBaseController.formattedRAMList.Contains(comboBox2.Text))
            {
                int index = Array.IndexOf(DataBaseController.formattedRAMList, comboBox2.Text);
                double RAMEnergy = Convert.ToDouble(DataBaseController.formattedRAMList[index + 1]);
                double RAMProfit = Convert.ToDouble(DataBaseController.formattedRAMList[index + 2]);
                ProfitUSD = RAMProfit * deviceCount;
                ProfitTNG = ProfitUSD * 500 * deviceCount;
                ProfitRUB = ProfitUSD * 100 * deviceCount;
                EnergyTNG = RAMEnergy * 6.5 * deviceCount;
                EnergyRUB = EnergyTNG / 5 * deviceCount;
                EnergyUSD = EnergyTNG / 500 * deviceCount;
                Console.WriteLine("Energy {0}. Profit {1}", EnergyTNG, ProfitTNG);
            }
            else if (DataBaseController.formattedHDDList.Contains(comboBox2.Text))
            {
                int index = Array.IndexOf(DataBaseController.formattedHDDList, comboBox2.Text);
                double HDDEnergy = Convert.ToDouble(DataBaseController.formattedHDDList[index + 1]);
                double HDDProfit = Convert.ToDouble(DataBaseController.formattedHDDList[index + 2]);
                ProfitUSD = HDDProfit;
                ProfitTNG = ProfitUSD * 500;
                ProfitRUB = ProfitUSD * 100;
                EnergyTNG = HDDEnergy * 6.5;
                EnergyRUB = EnergyTNG / 5;
                EnergyUSD = EnergyTNG / 500;
                Console.WriteLine("Energy {0}. Profit {1}", EnergyTNG, ProfitTNG);
            }
            MessageBox.Show("Доход с данного устройства в час: " +
                "\n" + $"В рублях: {ProfitRUB} " +
                "\n" + $"В тенге: {ProfitTNG} " +
                "\n" + $"В долларах: {ProfitUSD} " + "\n" +
                "\n" + "Расходы на энергию с данного устройства в час: " +
                "\n" + $"В рублях: {EnergyRUB}" +
                "\n" + $"В тенге: {EnergyTNG}" +
                "\n" + $"В долларах: {EnergyUSD}" + "\n" +
                "\n" + "Чистая прибыль: " +
                "\n" + $"В рублях: {ProfitRUB - EnergyRUB}" +
                "\n" + $"В тенге: {ProfitTNG - EnergyTNG}" +
                "\n" + $"В долларах: {ProfitUSD - EnergyUSD}");
        }


        private void CalculationDay()
        {
            double deviceCount = Convert.ToDouble(numericUpDown1.Value);
            double DayProfitRUB = ProfitRUB * 24 * deviceCount;
            double DayProfitTNG = ProfitTNG * 24 * deviceCount;
            double DayProfitUSD = ProfitUSD * 24 * deviceCount;
            double DayEnergyTNG = EnergyTNG * 24 * deviceCount;
            double DayEnergyUSD = EnergyUSD * 24 * deviceCount;
            double DayEnergyRUB = EnergyRUB * 24 * deviceCount;
            MessageBox.Show("Доход с данного устройства в день: " +
                "\n" + $"В рублях: {DayProfitRUB} " +
                "\n" + $"В тенге: {DayProfitTNG} " +
                "\n" + $"В долларах: {DayProfitUSD} " + "\n" +
                "\n" + "Расходы на энергию с данного устройства в день: " + 
                "\n" + $"В рублях: {DayEnergyRUB}" + 
                "\n" + $"В тенге: {DayEnergyTNG}" + 
                "\n" + $"В долларах: {DayEnergyUSD}" + "\n" +
                "\n" + "Чистая прибыль: " + 
                "\n" + $"В рублях: {DayProfitRUB-DayEnergyRUB}" +
                "\n" + $"В тенге: {DayProfitTNG-DayEnergyTNG}" + 
                "\n" + $"В долларах: {DayProfitUSD-DayEnergyUSD}");
        }


        private void CalculationMonth()
        {
            double deviceCount = Convert.ToDouble(numericUpDown1.Value);
            double MonthProfitRUB = ProfitRUB * 730 * deviceCount;
            double MonthProfitTNG = ProfitTNG * 730 * deviceCount;
            double MonthProfitUSD = ProfitUSD * 730 * deviceCount;
            double MonthEnergyTNG = EnergyTNG * 730 * deviceCount;
            double MonthEnergyUSD = EnergyUSD * 730 * deviceCount;
            double MonthEnergyRUB = EnergyRUB * 730 * deviceCount;
            MessageBox.Show("Доход с данного устройства в месяц: " +
                "\n" + $"В рублях: {MonthProfitRUB} " +
                "\n" + $"В тенге: {MonthProfitTNG} " +
                "\n" + $"В долларах: {MonthProfitUSD} " + "\n" +
                "\n" + "Расходы на энергию с данного устройства в месяц: " +
                "\n" + $"В рублях: {MonthEnergyRUB}" +
                "\n" + $"В тенге: {MonthEnergyTNG}" +
                "\n" + $"В долларах: {MonthEnergyUSD}" + "\n" + 
                "\n" + "Чистая прибыль: " +
                "\n" + $"В рублях: {MonthProfitRUB - MonthEnergyRUB}" +
                "\n" + $"В тенге: {MonthProfitTNG - MonthEnergyTNG}" +
                "\n" + $"В долларах: {MonthProfitUSD - MonthEnergyUSD}");
        }


        private void CalculationYear()
        {
            double deviceCount = Convert.ToDouble(numericUpDown1.Value);
            double YearProfitRUB = ProfitRUB * 8760 * deviceCount;
            double YearProfitTNG = ProfitTNG * 8760 * deviceCount;
            double YearProfitUSD = ProfitUSD * 8760 * deviceCount;
            double YearEnergyTNG = EnergyTNG * 8760 * deviceCount;
            double YearEnergyUSD = EnergyUSD * 8760 * deviceCount;
            double YearEnergyRUB = EnergyRUB * 8760 * deviceCount;
            MessageBox.Show("Доход с данного устройства в год: " +
                "\n" + $"В рублях: {YearProfitRUB} " +
                "\n" + $"В тенге: {YearProfitTNG} " +
                "\n" + $"В долларах: {YearProfitUSD} " + "\n" + 
                "\n" + "Расходы на энергию с данного устройства в год: " +
                "\n" + $"В рублях: {YearEnergyRUB}" +
                "\n" + $"В тенге: {YearEnergyTNG}" +
                "\n" + $"В долларах: {YearEnergyUSD}" + "\n" + 
                "\n" + "Чистая прибыль: " +
                "\n" + $"В рублях: {YearProfitRUB - YearEnergyRUB}" +
                "\n" + $"В тенге: {YearProfitTNG - YearEnergyTNG}" +
                "\n" + $"В долларах: {YearProfitUSD - YearEnergyUSD}");
        }


        public Form1()
        {
            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            comboBox1.Items.AddRange(new string[] { "us USD - $", "ru RUB - " + "\x20BD", "kz TNG - \x20B8" });
            comboBox3.Items.AddRange(new string[] { "Блоки питания", "Видеокарты", "Жесткие диски",
                "Оперативная память", "Процессоры"});
            logger.Debug("Валюты, типы устройств были загружены");
        }

        //Событие загрузки формы
        private void Form1_Load(object sender, EventArgs e)
        {
            logger.Debug("Была запущена форма");
            DataBaseController DBController = new DataBaseController();
            DBController.ShowPUDetails();
            DBController.ShowGPUDetails();
            DBController.ShowСPUDetails();
            DBController.ShowRAMDetails();
            DBController.ShowHDDDetails();
        }

        //Событие изменения текста в боксе "Валюта"
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox1.Text = EnergyUSD + "              " + "USD/kWH";
                    textBox2.Text = ProfitUSD + "              " + "USD";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    textBox1.Text = EnergyRUB + "             " + "RUB/kWH";
                    textBox2.Text = ProfitRUB + "           " + "RUB";
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    textBox1.Text = EnergyTNG + "             " + "TNG/kWH";
                    textBox2.Text = ProfitTNG + "           " + "TNG";
                }
                logger.Debug("Валюта была изменена пользователем");
            }
        }

        //Кнопка для расчета
        private void button1_Click(object sender, EventArgs e)
        {
            Calculations();
            CalculationDay();
            CalculationMonth();
            CalculationYear();
            logger.Debug("Пользователь нажал на кнопку расчета");
        }

        //Событие изменения текста в боксе "Выберите тип устройства"
        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text != null)
            {
                //Проверки на тип выбранного устройства
                if (comboBox3.Text == "Блоки питания")
                {
                    comboBox2.Items.Clear();
                    foreach(var item in DataBaseController.PUNamesReady)
                    {
                        comboBox2.Items.Add(item);
                    }
                    logger.Debug("Пользователь выбрал тип устройства: Блоки питания");
                }
                else if (comboBox3.Text == "Видеокарты")
                {
                    comboBox2.Items.Clear();
                    foreach (var item in DataBaseController.GPUNamesReady)
                    {
                        comboBox2.Items.Add(item);
                    }
                    logger.Debug("Пользователь выбрал тип устройства: Видеокарты");
                }
                else if (comboBox3.Text == "Жесткие диски")
                {
                    comboBox2.Items.Clear();
                    foreach (var item in DataBaseController.HDDNamesReady)
                    {
                        comboBox2.Items.Add(item);
                    }
                    logger.Debug("Пользователь выбрал тип устройства: Жесткие диски");
                }
                else if (comboBox3.Text == "Оперативная память")
                {
                    comboBox2.Items.Clear();
                    foreach (var item in DataBaseController.RAMNamesReady)
                    {
                        comboBox2.Items.Add(item);
                    }
                    logger.Debug("Пользователь выбрал тип устройства: Оперативная память");
                }
                else if (comboBox3.Text == "Процессоры")
                {
                    comboBox2.Items.Clear();
                    foreach (var item in DataBaseController.CPUNamesReady)
                    {
                        comboBox2.Items.Add(item);
                    }
                    logger.Debug("Пользователь выбрал тип устройства: Процессоры");
                }
            }
        }

        //Постоянное обновление формы
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    textBox1.Text = EnergyUSD + "              " + "USD/kWH";
                    textBox2.Text = ProfitUSD + "              " + "USD";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    textBox1.Text = EnergyRUB + "             " + "RUB/kWH";
                    textBox2.Text = ProfitRUB + "           " + "RUB";
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    textBox1.Text = EnergyTNG + "             " + "TNG/kWH";
                    textBox2.Text = ProfitTNG + "           " + "TNG";
                }
            }
        }
    }
}
