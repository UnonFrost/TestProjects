using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Contracts;
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace CommonTypes
{
    public interface ITest1
    {
        /// <summary>
        /// Вернуть коллекцию строк в виде одной строки с разделителем
        /// </summary>
        /// <param name="largeStringCollection">Коллекция строк. Учесть, что она может быть внушительной.</param>
        /// <param name="delimiter">Разделитель</param>
        /// <returns></returns>
        string ToOneString(IEnumerable<string> largeStringCollection, string delimiter);

        /// <summary>
        /// Вернуть массив чисел, исключив все дубли (повторяющиеся значения) из исходного массива
        /// </summary>
        /// <param name="intArr"></param>
        /// <returns></returns>
        int[] RemoveDuplcates(int[] intArr);

        /// <summary>
        /// Вернуть все дни (дата со значение времени 00:00:00) между переданными датами
        /// </summary>
        /// <param name="lowDt">Нижняя граница времени</param>
        /// <param name="highDt">Верхняя граница времени</param>
        /// <returns></returns>
        IEnumerable<DateTime> EnumDaysBetween(DateTime lowDt, DateTime highDt);

        /// <summary>
        /// Вернуть количество элементов массива со значением, превышающим указанное
        /// </summary>
        /// <param name="sourceArray">Коллекция чисел</param>
        /// <param name="value">Пороговое значение</param>
        /// <returns></returns>
        int GetCountLargerThanValue(int[] sourceArray, int value);

        /// <summary>
        /// Вернуть сумму всех элементов
        /// </summary>
        /// <param name="sourceArray">Массив чисел, сумму которых требуется вычислить</param>
        /// <returns></returns>
        int CalculateSumm(int[] sourceArray);

        /// <summary>
        /// Получить массив элементов только нужного типа из исходной разнотипной коллекции
        /// </summary>
        /// <typeparam name="T">Тип интересующих элементов</typeparam>
        /// <param name="manyObjectsCollection">Коллекция элементов разных типов</param>
        /// <returns></returns>
        T[] ExtractOnlyWantedType<T>(object[] manyObjectsCollection);

        /// <summary>
        /// Получить число отфильтрованных внешним фильтром элементов
        /// </summary>
        /// <typeparam name="T">Тип элементов коллекции</typeparam>
        /// <param name="collection">Коллекция элементов</param>
        /// <param name="filter">Внешняя финкция-фильтр элементов, возвращает true, если элемент участвует в вычислении,
        /// false - элемент выкидывыется из анализа</param>
        /// <returns></returns>
        int GetFilteredCount<T>(IEnumerable<T> collection, Func<T, bool> filter);

        /// <summary>
        /// Вернуть коллекцию всех чисел из диапазона ulong.MinValue до ulong.MaxValue
        /// </summary>
        /// <returns></returns>
        IEnumerable<ulong> EnumAllValues(ulong MinValue, ulong MaxValue);
    }
    [Export(typeof(IComponent))]
    [ExportMetadata("DoneMethods", 8)]

    public class ITestOne : IComponent
    {
        public string Description
        {
            get { return "Тест на расширенные знания C#. Этот интерфейс обязателен к реализации!"; }
        }
        public string ToOneString(IEnumerable<string> largeStringCollection, string delimiter)
        {
            string concat = largeStringCollection.Aggregate((x, y) => x + delimiter + y);
            return concat;
        }
        public int[] RemoveDuplcates(int[] intArr)
        {
            int[] q = intArr.Distinct().ToArray();
            return q;
        }
        public IEnumerable<DateTime> EnumDaysBetween(DateTime lowDt, DateTime highDt)
        {
            for (var day = lowDt.Date; day.Date <= highDt.Date; day = day.AddDays(1))
                yield return day;
        }
        public int GetCountLargerThanValue(int[] sourceArray, int value)
        {
            int count = 0;
            foreach (int i in sourceArray) if (i > value) count++;
            return count;
        }
        public int CalculateSumm(int[] sourceArray)
        {
            int rez = sourceArray.Sum();
            return rez;
        }
        public IEnumerable<T> ExtractOnlyWantedType<T>(object[] manyObjectsCollection)
        {
            foreach (object o in manyObjectsCollection)
                if (o is T t)
                yield return t;
        }
        public int GetFilteredCount<T>(IEnumerable<T> collection, Func<T, bool> filter)
        {
            T[] filtered = collection.Where(filter).ToArray();
            return filtered.Length;
        }
        public IEnumerable<ulong> EnumAllValues(ulong MinValue, ulong MaxValue)
        {
            ulong step = 1UL;

            if (MinValue <= MaxValue)
            {
                for (ulong ul = MinValue; ul <= MaxValue; ul += step) yield return ul;
            }
            else
            {
                for (ulong ul = MinValue; ul >= MaxValue; ul -= step) yield return ul;
            }
        }
    }
}
