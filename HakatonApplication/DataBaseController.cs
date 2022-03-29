using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HakatonApplication
{
    public class DataBaseController
    {
        #region Path
        //Переменные с путями для нахождения файла с данными (Необходимо будет изменить при загрузке на другой ПК) (Если не поменяете, то по идее не будет работать, но это не точно)
        public static string pathToPUDataBase = @"C:\\Users\Vladimir\source\repos\HakatonApplication\HakatonApplication\БД Хакатон\БД Блок питания.txt";
        public static string pathToGPUDataBase = @"C:\\Users\Vladimir\source\repos\HakatonApplication\HakatonApplication\БД Хакатон\БД видеокарты.txt";
        public static string pathToHDDDataBase = @"C:\\Users\Vladimir\source\repos\HakatonApplication\HakatonApplication\БД Хакатон\БД жекстий диск.txt";
        public static string pathToRAMDataBase = @"C:\\Users\Vladimir\source\repos\HakatonApplication\HakatonApplication\БД Хакатон\БД ОЗУ.txt";
        public static string pathToCPUDataBase = @"C:\\Users\Vladimir\source\repos\HakatonApplication\HakatonApplication\БД Хакатон\БД процессоры.txt";
        #endregion

        #region FileInfo
        //Нужны для проверки существования файла
        FileInfo filePUInf = new FileInfo(pathToPUDataBase); 
        FileInfo fileGPUInf = new FileInfo(pathToGPUDataBase);
        FileInfo fileHDDInf = new FileInfo(pathToHDDDataBase);
        FileInfo fileRAMInf = new FileInfo(pathToRAMDataBase);
        FileInfo fileCPUInf = new FileInfo(pathToCPUDataBase);
        #endregion

        #region PUDataBase
        public static string[] formattedList; //Массив с отсортированными данными из файла Блоков питания
        public Queue<String> PUNamesQueue = new Queue<String>(); //Очередь нужна для временного хранения названий блоков питания
        public static string[] PUNamesReady; //Готовый массив с именами блоков питания
        #endregion
        #region GPUDataBase
        public static string[] formattedGPUList; //Массив с отсортированными данными из файла Видеокарт
        public Queue<String> GPUNamesQueue = new Queue<String>(); //Очередь нужна для временного хранения названий видеокарт
        public static string[] GPUNamesReady; //Готовый массив с именами видеокарт
        #endregion
        #region HDDDataBase
        public static string[] formattedHDDList; //Массив с отсортированными данными из файла жестких дисков
        public Queue<String> HDDNamesQueue = new Queue<String>(); //Очередь нужна для временного хранения названий жестких дисков
        public static string[] HDDNamesReady; //Готовый массив с именами жестких дисков
        #endregion
        #region RAMDataBase
        public static string[] formattedRAMList; //Массив с отсортированными данными из файла Оперативной памяти
        public Queue<String> RAMNamesQueue = new Queue<String>(); //Очередь нужна для временного хранения названий оперативной памяти
        public static string[] RAMNamesReady; //Готовый массив с именами оперативной памяти
        #endregion
        #region CPUDataBase
        public static string[] formattedCPUList; //Массив с отсортированными данными из файла процессоров
        public Queue<String> CPUNamesQueue = new Queue<String>(); //Очередь нужна для временного хранения названий процессоров
        public static string[] CPUNamesReady; //Готовый массив с именами процессоров
        #endregion


        //Функиця для работы с блоками питания
        public void ShowPUDetails()
        {
            if (filePUInf.Exists)
            {
                StreamReader reader = new StreamReader(pathToPUDataBase); //Нужен для построчного чтения файла
                string compList = reader.ReadToEnd(); //Считывает файл
                formattedList = compList.Split( new char[] {',','\r','\n'}, StringSplitOptions.RemoveEmptyEntries ); //Форматирует массив, убирает из него пробелы между строк 
                
                foreach(var val in formattedList) //перебор отсортированного массива
                {
                    if(val.Length > 10) //условия для получения имен
                    {
                        PUNamesQueue.Enqueue(val); //Добавление имени в Очередь
                    }
                }

                PUNamesReady = PUNamesQueue.ToArray(); //Копирует очередь в массив с именами
                
                reader.Close(); //Завершает считывание файла
            }
        }


        //Функция для работы с видеокартами
        public void ShowGPUDetails()
        {
            if (fileGPUInf.Exists)
            {
                StreamReader reader = new StreamReader(pathToGPUDataBase); //Нужен для построчного чтения файла
                string compList = reader.ReadToEnd(); //Считывает файл
                formattedGPUList = compList.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); //Форматирует массив, убирает из него пробелы между строк 

                foreach (var val in formattedGPUList) //перебор отсортированного массива
                {
                    if (val.Length > 10) //условия для получения имен
                    {
                        GPUNamesQueue.Enqueue(val); //Добавление имени в Очередь
                    }
                }

                GPUNamesReady = GPUNamesQueue.ToArray(); //Копирует очередь в массив с именами

                reader.Close(); //Завершает считывание файла
            }
        }


        //Функция для работы с процессорами
        public void ShowСPUDetails()
        {
            if (fileCPUInf.Exists)
            {
                StreamReader reader = new StreamReader(pathToCPUDataBase); //Нужен для построчного чтения файла
                string compList = reader.ReadToEnd(); //Считывает файл
                formattedCPUList = compList.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); //Форматирует массив, убирает из него пробелы между строк 

                foreach (var val in formattedCPUList) //перебор отсортированного массива
                {
                    if (val.Length > 10) //условия для получения имен
                    {
                        CPUNamesQueue.Enqueue(val); //Добавление имени в Очередь
                    }
                }

                CPUNamesReady = CPUNamesQueue.ToArray(); //Копирует очередь в массив с именами

                reader.Close(); //Завершает считывание файла
            }
        }


        //Функция для работы с оперативной памятью
        public void ShowRAMDetails()
        {
            if (fileRAMInf.Exists)
            {
                StreamReader reader = new StreamReader(pathToRAMDataBase); //Нужен для построчного чтения файла
                string compList = reader.ReadToEnd(); //Считывает файл
                formattedRAMList = compList.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); //Форматирует массив, убирает из него пробелы между строк 

                foreach (var val in formattedRAMList) //перебор отсортированного массива
                {
                    if (val.Length > 10) //условия для получения имен
                    {
                        RAMNamesQueue.Enqueue(val); //Добавление имени в Очередь
                    }
                }

                RAMNamesReady = RAMNamesQueue.ToArray(); //Копирует очередь в массив с именами

                reader.Close(); //Завершает считывание файла
            }
        }


        //Функция для работы с жесткими дисками
        public void ShowHDDDetails()
        {
            if (fileHDDInf.Exists)
            {
                StreamReader reader = new StreamReader(pathToHDDDataBase); //Нужен для построчного чтения файла
                string compList = reader.ReadToEnd(); //Считывает файл
                formattedHDDList = compList.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries); //Форматирует массив, убирает из него пробелы между строк 

                foreach (var val in formattedHDDList) //перебор отсортированного массива
                {
                    if (val.Length > 10) //условия для получения имен
                    {
                        HDDNamesQueue.Enqueue(val); //Добавление имени в Очередь
                    }
                }

                HDDNamesReady = HDDNamesQueue.ToArray(); //Копирует очередь в массив с именами

                reader.Close(); //Завершает считывание файла
            }
        }
    }
}
