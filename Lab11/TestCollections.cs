using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintEditionLibrary;
using System.Diagnostics;
using System.Threading;
namespace Lab11
{
    class TestCollections
    {
        List<PrintEdition> myList = new List<PrintEdition>();
        List<string> myListString = new List<string>();
        Dictionary<PrintEdition, book> myDictionary = new Dictionary<PrintEdition, book>();
        Dictionary<string, book> myDictionaryString = new Dictionary<string, book>();
        public TestCollections(int size)
        {
            for(int i = 0; i < size; i++)
            {
                book t = new book();
                myList.Add(t.ReturnBase);
                myListString.Add(t.ReturnBase.ToString());
                myDictionary.Add(myList.Last(), t);
                myDictionaryString.Add(myListString.Last(), t);
                Thread.Sleep(20);
            }
        }
        public void MyListTimeTest()
        {
            PrintEdition first, middle, last, nonexistant;
            first = myList.First();
            long[] testtimes = new long[4];
            int index = 0;
            for (int i = 0; i < myList.Count / 2; i++)
            {
                index++;
            }
            middle = myList[index];
            last = myList.Last();
            nonexistant = new PrintEdition(2220, -1);
            Stopwatch tt = new Stopwatch();
            tt.Start();
            if (myList.Contains(first))
            {
                tt.Stop();
            }
            testtimes[0] = tt.ElapsedTicks;
            tt.Restart();
            if (myList.Contains(middle))
            {
                tt.Stop();
            }
            testtimes[1] = tt.ElapsedTicks;
            tt.Restart();
            if (myList.Contains(last))
            {
                tt.Stop();
            }
            testtimes[2] = tt.ElapsedTicks;
            if (!myList.Contains(nonexistant))
            {
                tt.Stop();
            }
            testtimes[3] = tt.ElapsedTicks;
            Console.WriteLine("Время поиска в List<PrintEdition>\n\nВремя поиска первого элемента: " + testtimes[0] + "\nВремя поиска центрального элемента: " + testtimes[1] +
                "\nВремя поиска последнего элемента: " + testtimes[2] + "\nВремя поиска не существующего элемента: " + testtimes[3]);

        }
        public void myListStringTest()
        {
            string first, middle, last, nonexistant;
            first = myListString.First();
            long[] testtimes = new long[4];
            int index = 0;
            for (int i = 0; i < myList.Count / 2; i++)
            {
                index++;
            }
            middle = myListString[index];
            last = myListString.Last();
            nonexistant = "не существует";
            Stopwatch tt = new Stopwatch();
            tt.Start();
            if (myListString.Contains(first))
            {
                tt.Stop();
            }
            testtimes[0] = tt.ElapsedTicks;
            tt.Restart();
            if (myListString.Contains(middle))
            {
                tt.Stop();
            }
            testtimes[1] = tt.ElapsedTicks;
            tt.Restart();
            if (myListString.Contains(last))
            {
                tt.Stop();
            }

            testtimes[2] = tt.ElapsedTicks;
            if (!myListString.Contains(nonexistant))
            {
                tt.Stop();
            }
            testtimes[3] = tt.ElapsedTicks;
            Console.WriteLine("Время поиска в List<String>\n\nВремя поиска первого элемента: " + testtimes[0] + "\nВремя поиска центрального элемента: " + testtimes[1] +
                "\nВремя поиска последнего элемента: " + testtimes[2] + "\nВремя поиска не существующего элемента: " + testtimes[3]);
        }
        public void MyDictionaryTest()
        {
            PrintEdition first = new PrintEdition(), middle = new PrintEdition(), last = new PrintEdition(), nonexistant = new PrintEdition(2222,-1);
            long[] testtimes = new long[4];
            int index = 0;
            foreach (var item in myDictionary)
            {
                if (index == 0)
                {
                    first = item.Key;
                }
                if (index == myDictionary.Count / 2 - 1)
                {
                    middle = item.Key;
                }
                if (index == myDictionary.Count - 1)
                {
                    last = item.Key;
                }
                index++;
            }
            nonexistant = new PrintEdition(2220, -1);
            Stopwatch tt = new Stopwatch();
            tt.Start();
            if (myDictionary.ContainsKey(first))
            {
                tt.Stop();
            }
            testtimes[0] = tt.ElapsedTicks;
            tt.Restart();
            if (myDictionary.ContainsKey(middle))
            {
                tt.Stop();
            }
            testtimes[1] = tt.ElapsedTicks;
            tt.Restart();
            if (myDictionary.ContainsKey(last))
            {
                tt.Stop();
            }
            testtimes[2] = tt.ElapsedTicks;
            if (!myDictionary.ContainsKey(nonexistant))
            {
                tt.Stop();
            }
            testtimes[3] = tt.ElapsedTicks;
            Console.WriteLine("Время поиска по ключу в Dictionary<PrintEdition,book>\n\nВремя поиска первого элемента: " + testtimes[0] + "\nВремя поиска центрального элемента: " + testtimes[1] +
                "\nВремя поиска последнего элемента: " + testtimes[2] + "\nВремя поиска не существующего элемента: " + testtimes[3]);
        }
        public void MyDictionaryStringTest()
        {
            book first = new book(),middle = new book(), last = new book(), nonexistant = new book(2222,-1,"","");
            long[] testtimes = new long[4];
            int index = 0;
            foreach (var item in myDictionaryString)
            {
                if (index == 0)
                {
                    first = item.Value;
                }
                if (index == myDictionary.Count / 2 - 1)
                {
                    middle = item.Value;
                }
                if (index == myDictionary.Count - 1)
                {
                    last = item.Value;
                }
                index++;
            }
            Stopwatch tt = new Stopwatch();
            tt.Start();
            if (myDictionaryString.ContainsValue(first))
            {
                tt.Stop();
            }
            testtimes[0] = tt.ElapsedTicks;
            tt.Restart();
            if (myDictionaryString.ContainsValue(middle))
            {
                tt.Stop();
            }
            testtimes[1] = tt.ElapsedTicks;
            tt.Restart();
            if (myDictionaryString.ContainsValue(last))
            {
                tt.Stop();
            }
            testtimes[2] = tt.ElapsedTicks;
            if (!myDictionaryString.ContainsValue(nonexistant))
            {
                tt.Stop();
            }
            testtimes[3] = tt.ElapsedTicks;
            Console.WriteLine("Время поиска по значению в Dictionary<string,book>\n\nВремя поиска первого элемента: " + testtimes[0] + "\nВремя поиска центрального элемента: " + testtimes[1] +
                "\nВремя поиска последнего элемента: " + testtimes[2] + "\nВремя поиска не существующего элемента: " + testtimes[3]);
        }
        public void ShowItems()
        {
           foreach ( KeyValuePair<PrintEdition, book> keyValue in myDictionary)
            {
                keyValue.Value.Show();
            }
        }
    }

}
