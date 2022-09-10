using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using System.ComponentModel.Composition;

namespace TestTasks
{
    public interface ITest0
    {
        /// <summary>
        /// Проверить, является ли число четным
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsEven(int value);

        /// <summary>
        /// Определить, сколько секунд между двумя моментами времени
        /// </summary>
        /// <param name="dt1"></param>
        /// <param name="dt2"></param>
        /// <returns></returns>
        int GetSecondsBetweenDates(DateTime dt1, DateTime dt2);

        /// <summary>
        /// Есть строка полного имени человека в формате "Фамилия Имя Отчество"
        /// Требуется вернуть Имя
        /// </summary>
        /// <param name="fullName">ФИО</param>
        /// <returns></returns>
        string ExtractFirstName(string fullName);

        /// <summary>
        /// Вернуть массив байт с элементами, расположенными в обратном порядке 
        /// </summary>
        /// <param name="value">Исходный массив байт</param>
        /// <returns></returns>
        byte[] Reverse(byte[] value);

        /// <summary>
        /// Сохранить строку в файл
        /// </summary>
        /// <param name="textToSave"></param>
        /// <param name="fileName"></param>
        void WriteText(string textToSave, string fileName);

        /// <summary>
        /// Прочитать содержимое текстового файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        string ReadText(string fileName);

        /// <summary>
        /// Проверить, является ли массив пустым
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool IsArrayEmpty(int[] value);
    }
    [Export(typeof(IComponent))]
    [ExportMetadata("DoneMethods", 7)]

    public class ITestZero : IComponent
    {
        public string Description
        {
            get { return "Тест на базовые знания C#. Этот интерфейс обязателен к реализации!"; }
        }

        public bool IsEven(int value)
        {
            return ((value & 1) == 0);
        }
        public int GetSecondsBetweenDates(DateTime dt1, DateTime dt2)
        {
            int a;
            double x;
            x = (dt2 - dt1).TotalSeconds;
            a = (int)x;
            return a;
        }
        public string ExtractFirstName(string fullName)
        {
            var partsName = fullName.Split(' ');
            return partsName[1];
        }
        public byte[] Reverse(byte[] value)
        {
            byte[] myArray = value;
            for(int i = 0; i < myArray.Length; i++)
            {
                myArray[i] += myArray[myArray.Length - 1 - i];
            }
            return myArray;
        }
        public void WriteText(string textToSave, string fileName)
        {
            File.WriteAllText(fileName, textToSave, Encoding.Default);
        }
        public string ReadText(string fileName)
        {
            string readText;
            readText = File.ReadAllText(fileName);
            return readText;
        }
        public bool IsArrayEmpty(int[] value)
        {
            if (value.Length == 0) return true;
            else return false;
        }
    }
}
