using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;

namespace ConsoleApplication2
{
    class Parallel
    {

        public static void H2()
        {
            string[] values = new string[10000000];
            string findValue = " 9000000.";

            Console.WriteLine("Building initial array of {0} length...", values.Length);

            for (int j = 0; j < values.Length; j++)
            {
                values[j] = string.Format("This Is My Value: {0}.", j.ToString());
            }

            start:

            Console.WriteLine("Searching for '{0}'...", findValue);

            Console.WriteLine("Running parallel search...");

            DateTime start = DateTime.Now;

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 4;

            System.Threading.Tasks.Parallel.For(0, values.Length, options, (i) =>
            {
                if (values[i].Contains(findValue))
                {
                    Console.WriteLine("Found {0}", values[i]);
                    Console.WriteLine("Search completed in: {0}", DateTime.Now - start);
                }
            });

            Console.WriteLine("Parallel for completed in : {0}", DateTime.Now - start);

            Console.WriteLine("Running linear search...");

            start = DateTime.Now;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains(findValue))
                {
                    Console.WriteLine("Found {0}", values[i]);
                    Console.WriteLine("Search completed in: {0}", DateTime.Now - start);
                }
            }

            Console.WriteLine("Linear for completed in : {0}", DateTime.Now - start);

            Console.WriteLine("Press any key to exit or press 'Z' to do it again...");

            if (Console.ReadKey().Key == ConsoleKey.Z)
            {
                Console.WriteLine("");
                goto start;
            }
        }
       

        public static void H()
        {
            Console.WriteLine("loading..");

            //init some stuff
            List<string> list = new List<string>();
            //  Stopwatch sw = new Stopwatch();
            Random r = new Random();
            double sum = 0;
            DateTime dt;
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(r.Next(0, 999999).ToString());
            }

            //non parallel time
            Console.WriteLine("starting");

            dt = DateTime.Now;
            foreach (string f in list)
            {
                MD5(f);
            }
            Console.WriteLine($"non parallel time: {(DateTime.Now - dt).Seconds} seconds");

            //parallel 
            sum = 0;
            dt = DateTime.Now;

           list.AsParallel().ForAll(str => MD5(str));

            Console.WriteLine($"parallel time:{ (DateTime.Now - dt).Seconds} seconds");

            Console.WriteLine("end");
        }

        static string MD5(string password)
        {
            // byte array representation of that string
            byte[] encodedPassword = new UTF8Encoding().GetBytes(password);

            // need MD5 to calculate the hash
            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            // string representation (similar to UNIX format)
            string encoded = BitConverter.ToString(hash)
               // without dashes
               .Replace("-", string.Empty)
               // make lowercase
               .ToLower();
            return encoded;
        }
    }
}
