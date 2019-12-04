using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PrintEditionLibrary;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();

        }
        public static void AutoFill(ArrayList a, int size)
        {
            Random rand = new Random();
            while (a.Count < size)
            {
                Thread.Sleep(20);
                int r = rand.Next(1, 4);
                switch (r)
                {
                    case 1:
                        book koob = new book();
                        a.Add(koob);
                        break;
                    case 2:
                        Textbook uchebnik = new Textbook();
                        a.Add(uchebnik);
                        break;
                    case 3:
                        Magazine jurnal = new Magazine();
                        a.Add(jurnal);
                        break;
                }
            }
        }
        public static void ShowBookWithMaxPages(ArrayList a)
        {
            int max = 0;
            int index = -1;
            int count = 0;
            book f;
            foreach (PrintEdition item in a)
            {
                f = item as book;
                if (f != null)
                {
                    if (f.AmountOfPages > max)
                    {
                        max = f.AmountOfPages;
                        index = count;
                    }
                }
                count++;
            }
            if (index >= 0)
            {
                Console.WriteLine("Книга с максимальным количеством страниц: \n");
                book b = a[index] as book;
                b.Show();
            }
            else
            {
                Console.WriteLine("В коллекции нет книг");
            }
        }
        public static void ShowAmountOfProgrammingMagazines(ArrayList a)
        {
            int count = 0;
            Magazine p;
            foreach (PrintEdition item in a)
            {
                p = item as Magazine;
                if (p != null && p.Theme == "Программирование")
                {
                    count++;
                }
            }
            Console.WriteLine("Количество журналов по программированию: " + count);
        }
        public static void ShowEverythingYoungerThan(ArrayList a, int ye)
        {
            Console.WriteLine("Все печатные издания новее, чем " + ye + ":\n");
            int count = 0;
            foreach (PrintEdition item in a)
            {
                if (item.Year > ye)
                {
                    item.Show();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Таких книг нет\n");
            }

        }
        public static void ShowItems(ArrayList a)
        {
            Console.WriteLine("Все элементы коллекции: \n");
            foreach (PrintEdition item in a)
            {
                item.Show();
            }
        }
        public static void Task1()
        {
            ArrayList a = new ArrayList();
            AutoFill(a, 5);
            ShowBookWithMaxPages(a);
            a.Sort();
            ShowItems(a);
            Console.ReadKey();
            Console.Clear();
            ArrayList aClone = (ArrayList)a.Clone();
            ShowItems(aClone);
            Console.ReadKey();
            Console.Clear();
            book forSearch = new book(1869, 500, "Поиск элемента в коллекции", "Я");
            a.Add(forSearch);
            a.Sort();
            ShowItems(a);
            Console.ReadKey();
            Console.Clear();
            a.Sort();
            int removeBook = a.BinarySearch(forSearch);
            a.RemoveAt(removeBook);
            ShowItems(a);
            Console.ReadKey();
            Console.Clear();
        }
        public static void AutoFillDictionary(Dictionary<int, PrintEdition> a, int size)
        {
            Random rand = new Random();
            while (a.Count < size)
            {
                Thread.Sleep(20);
                int r = rand.Next(1, 4);
                switch (r)
                {
                    case 1:
                        book koob = new book();
                        a.Add(a.Count + 1, koob);
                        break;
                    case 2:
                        Textbook uchebnik = new Textbook();
                        a.Add(a.Count + 1, uchebnik);
                        break;
                    case 3:
                        Magazine jurnal = new Magazine();
                        a.Add(a.Count + 1, jurnal);
                        break;
                }
            }
        }
        public static void ShowDictionaryItems(Dictionary<int, PrintEdition> a)
        {
            foreach (KeyValuePair<int, PrintEdition> keyValue in a)
            {
                Console.WriteLine(keyValue.Key + "\n");
                keyValue.Value.Show();
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void SEYTInDictionary(Dictionary<int, PrintEdition> a, int ye)
        {
            Console.WriteLine("Все печатные издания новее, чем " + ye + ":\n");
            int count = 0;
            foreach (KeyValuePair<int, PrintEdition> keyValue in a)
            {
                if (keyValue.Value.Year > ye)
                {
                    keyValue.Value.Show();
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Таких книг нет\n");
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void ShowDictionarySorted(Dictionary<int, PrintEdition> a)
        {
            var sortedDict = new SortedDictionary<int, PrintEdition>(a);
            foreach (var kvp in sortedDict)
            {
                Console.WriteLine(kvp.Key + "\n");
                kvp.Value.Show();
            }
            Console.ReadKey();
            Console.Clear();
        }
        public static void SearchByKey(Dictionary<int, PrintEdition> a,int key)
        {
            PrintEdition print;
            a.TryGetValue(key,out print);
            if (print != null)
            {
                Console.WriteLine("Найденный объект: \n" );
                print.Show();
            }
            else
            {
                Console.WriteLine("Объект не найден");
            }
        }
        public static void Task2()
        {
            Dictionary<int, PrintEdition> library = new Dictionary<int, PrintEdition>();
            AutoFillDictionary(library, 5);
            ShowDictionaryItems(library);
            SEYTInDictionary(library, 1500);
            Dictionary<int, PrintEdition> newLibrary = new Dictionary<int, PrintEdition>(library);
            Magazine journal = new Magazine(2019, 100, 12, "Журнал");
            newLibrary.Add(-5, journal);
            ShowDictionarySorted(newLibrary);
            SearchByKey(newLibrary, 1);
        }
        public static void Task3()
        {
            TestCollections a = new TestCollections(10);
            a.MyListTimeTest();
            Console.ReadKey();
            Console.Clear();
            a.myListStringTest();
            Console.ReadKey();
            Console.Clear();
            a.MyDictionaryTest();
            Console.ReadKey();
            Console.Clear();
            a.MyDictionaryStringTest();
        }

    }
}
