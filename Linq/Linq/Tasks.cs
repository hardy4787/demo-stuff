using System;
using System.Collections.Generic;
using System.Linq;
using Linq.Comparers;
using Linq.Objects;

namespace Linq
{
    public static class Tasks
    {
        //The implementation of your tasks should look like this:
        public static string TaskExample(IEnumerable<string> stringList)
        {
            return stringList.Aggregate<string>((x, y) => x + y);
        }

        #region Low
        // Заданы символ С последовательность непустых строк stringList.
        // Получить новую последовательность строк из stringList с длиной более одного символа,
        // начинающихся и заканчивающихся символом C.
        public static IEnumerable<string> Task1(char c, IEnumerable<string> stringList)
        {
            return stringList.Where(s => s.Length > 1 && s[0] == c && s[s.Length - 1] == c);
        }

        // Задана последовательность непустых строк stringList.
        // Получить последовательность отсортированных по возрастанию целых значений,
        // равных длинам строк, входящих в последовательность stringList.
        public static IEnumerable<int> Task2(IEnumerable<string> stringList)
        {
            return stringList.Select(s => s.Length).OrderBy(s => s);
        }

        // Задана последовательность непустых строк stringList.
        // Получить новую последовательность строк, где каждая строка состоит из первого
        // и последнего символов соответствующей строки последовательности stringList.
        public static IEnumerable<string> Task3(IEnumerable<string> stringList)
        {
            return stringList.Select(s => $"{s[0]}{s[^1]}");
        }

        // Задано целое положительное значение K и последовательность непустых строк
        // stringList. Строки последовательности содержат только цифры и заглавные
        // буквы латинского алфавита. Получить из stringList все строки длины K,
        // оканчивающиеся цифрой, и отсортировать их по возрастанию.
        public static IEnumerable<string> Task4(int k, IEnumerable<string> stringList)
        {
            return stringList.Where((s, i) => s.Length == k && Char.IsDigit(s[^1])).OrderBy(s => s);
        }

        // Задана последовательность положительных целых значений integerList.
        // Получить последовательность строковых представлений только нечетных
        // значений integerList и отсортировать по возрастанию
        public static IEnumerable<string> Task5(IEnumerable<int> integerList)
        {
            return integerList.Where(x => x % 2 != 0).OrderBy(s => s).Select(x => x.ToString());
        }

        #endregion

        #region Middle
        // Заданы последовательность положительных значений numbers
        // и последовательность строк stringList.
        // Получить новую последовательность строк по следующему правилу:
        // для каждого значения n из последовательности numbers выбрать
        // строку из последовательности stringList, начинающуюся с цифры
        // и имеющую длину n.Если требуемых строк в последовательности
        // stringList несколько - вернуть первую, если их нет, то вернуть
        // строку «Not found» (Для обработки ситуации, связанной с отсутствием требуемых строк,
        // использовать операцию ??)
        public static IEnumerable<string> Task6(IEnumerable<int> numbers, IEnumerable<string> stringList)
        {
            return numbers.GroupJoin(
                        stringList,
                        x => x, y => y.Length,
                        (requiredLength, words) =>
                            words.FirstOrDefault(
                                word => word.Length == requiredLength && Char.IsDigit(word[0]))
                                ?? "Not found"
                );
            //return from number in numbers
            //       join word in stringList
            //       on number equals word.Length into result
            //       select result.FirstOrDefault(r => Char.IsDigit(r[0])) ?? "Not found";
        }

        //        Задано целое положительное значение K и последовательность целых значений
        //integerList.
        //Вычислить разность двух подмножеств целых значений: первое подмножество - все
        //четные значения integerList, второе подмножество - это значения integerList,
        //исключая первые К элементов. В полученной разности заменить порядок на обратный
        public static IEnumerable<int> Task7(int k, IEnumerable<int> integerList)
        {
            //return integerList
            //    .Where(x => x % 2 == 0).Except(integerList.Skip(k)).Reverse();
            return (from integer in integerList
                    where integer % 2 == 0
                    select integer).Except((from integer2 in integerList select integer2).Skip(k)).Reverse();
        }

        //        Задано целое положительное значение K, целое значение D и последовательность
        //целых значений integerList.
        //Вычислить объединение двух подмножеств целых значений: первое подмножество -
        //все значения integerList до первого элемента, больше чем D (не включая его) , второе
        //подмножество - это значения integerList, начиная с элемента с порядковым номером К
        //включительно(нумерация элементов integerList начинается с 0) . Полученную
        //последовательность отсортировать по убыванию
        public static IEnumerable<int> Task8(int k, int d, IEnumerable<int> integerList)
        {
            return integerList.TakeWhile(x => x <= d).Union(integerList.Skip(k)).OrderByDescending(s => s);
        }

        //        Задана последовательность непустых строк stringList, содержащих только заглавные
        //буквы латинского алфавита.
        //Для всех строк, начинающихся с одной и той же буквы, определить их суммарную
        //длину и получить последовательность строк вида «S-C», где S — суммарная длина
        //всех строк из stringList, которые начинаются с символа С.Полученную
        //последовательность упорядочить по убыванию числовых значений сумм, а при равных
        //значениях сумм — по возрастанию кодов символов C.
        public static IEnumerable<string> Task9(IEnumerable<string> stringList)
        {
            return stringList.GroupBy(s => s[0]).OrderByDescending(x => x.Sum(y => y.Length)).ThenBy(x => x.Key).Select((x) => $"{x.Sum(y => y.Length)}-{x.Key}");
        }

        // Задана последовательность непустых строк символов латинского алфавита stringList.
        // Среди всех строк одинаковой длины, отсортированных по возрастанию, выбрать у
        // каждой строки последний символ, переведя его в верхний регистр, и из полученных
        // символов составить строку. Полученную последовательность строк упорядочить по
        // убыванию их длин
        public static IEnumerable<string> Task10(IEnumerable<string> stringList)
        {
            return stringList.OrderBy(x => x).GroupBy(s => s.Length).Select(x => String.Concat(x.Select(y => y[y.Length - 1].ToString().ToUpper()))).OrderByDescending(x => x.Length).ToList();


        }

        #endregion

        #region Advance

        public static IEnumerable<YearSchoolStat> Task11(IEnumerable<Entrant> nameList)
        {
            return nameList.Distinct(new EntrantComparer()).GroupBy(n => n.Year).Select(x => new YearSchoolStat { Year = x.Key, NumberOfSchools = x.Count() }).OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year).ToList();
        }

        public static IEnumerable<NumberPair> Task12(IEnumerable<int> integerList1, IEnumerable<int> integerList2)
        {
            return integerList1.Select(x => x.ToString()).Join(integerList2.Select(x => x.ToString()), x => x[x.Length - 1], y => y[y.Length - 1], (x, y) => new NumberPair { Item1 = int.Parse(x), Item2 = int.Parse(y) }).OrderBy(x => x.Item1).ThenBy(x => x.Item2);
        }

        public static IEnumerable<YearSchoolStat> Task13(IEnumerable<Entrant> nameList, IEnumerable<int> yearList)
        {
            return yearList.GroupJoin(nameList.Distinct(new EntrantComparer()), x => x, y => y.Year, (x, y) => new YearSchoolStat { Year = x, NumberOfSchools = y.Count() }).OrderBy(x => x.NumberOfSchools).ThenBy(x => x.Year);
        }

        public static IEnumerable<MaxDiscountOwner> Task14(IEnumerable<Supplier> supplierList,
                IEnumerable<SupplierDiscount> supplierDiscountList)
        {
            return supplierDiscountList
                .GroupBy(sd => sd.ShopName)
                .Select(group => group.Where(sd => sd.Discount == group.Max(s => s.Discount)))
                .Select(group => group.FirstOrDefault(sd => sd.SupplierId == group.Min(s => s.SupplierId)))
                .Select(group => new MaxDiscountOwner
                {
                    Discount = group.Discount,
                    ShopName = group.ShopName,
                    Owner = supplierList.FirstOrDefault(s => group.SupplierId == s.Id)
                })
                .OrderBy(x => x.ShopName);
        }

        public static IEnumerable<CountryStat> Task15(IEnumerable<Good> goodList,
            IEnumerable<StorePrice> storePriceList)
        {
            return goodList
                .GroupBy(g => g.Country)
                .Select(x => new
                {
                    country = x.Key,
                    goods = x.Join(
                            storePriceList,
                            a => a.Id,
                            b => b.GoodId,
                            (a, b) => b)
                }
                )
                .Select((y) =>
                    new CountryStat
                    {
                        Country = y.country,
                        StoresNumber = y.goods.Select(p => p.Shop).Distinct().Count(),
                        MinPrice = y.goods.Count() == 0 ? 0 : y.goods.Min(x => x.Price)
                    }
                )
                .OrderBy(x => x.Country)
                .ToList();
        }
        #endregion
    }
}
