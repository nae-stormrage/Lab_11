using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;

namespace Lab_11
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader f_in = new StreamReader("lr11_10.csv");

#if !DEBUG
            TextWriter save_out = Console.Out;
            var new_out = new StreamWriter(@"lr11_10_output.txt");
            Console.SetOut(new_out);
#endif

            List<Person> all = new List<Person>();
            try
            {
                String line = f_in.ReadLine();
                while ((line = f_in.ReadLine()) != null)
                {
                    all.Add(Person.Create(line));
                }
            } catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Всего клиентов банка: {0}", all.Count);

            Console.WriteLine("\n*****Задача 1*****");
            float client_otricatel_balance = (from p in all where p.Plus - p.Minus < 0 select p).Count();
            Console.WriteLine("Кол-во клиентов с отрицательным балансом счета: {0}", client_otricatel_balance);

            Console.WriteLine("\n*****Задача 2*****");
            float average_tax = (from p in all select p.Tax).Sum()/all.Count;
            Console.WriteLine("Средний налог по всем клиентам: {0}", average_tax);

            Console.WriteLine("\n*****Задача 3*****");
            float max_minus = (from p in all select p.Minus).Max();
            Person client_max_minus = (from p in all where (p.Minus == max_minus) select p).First();
            Console.WriteLine("Клиент с максимальным расходом:\n{0}", client_max_minus);

            Console.WriteLine("\n*****Задача 4*****");
            float average_plus_without_email = (from p in all where p.email == "" select p.Plus).Sum() / (from p in all where p.email == "" select p).Count();
            Console.WriteLine("Средний доход клиентов без email: {0}", average_plus_without_email);

#if !DEBUG
            Console.SetOut(save_out);
            new_out.Close();
#else
            Console.ReadKey();
#endif
        }
    }
}