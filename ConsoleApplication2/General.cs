using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace ConsoleApplication2
{
    class General
    {
        //c# 6
        public string First { get; } = "Jane";

        //async task stuff + c# 6 string formatting
        public static async void D()
        {
            long q = await DoStuff();
            string a = "InsertedString1";
            string b = "nanaaa";
            var s = $"{a} is {b}";

            WriteLine($"RESULT: {q} string: {s}");
        }

        static async Task<long> DoStuff()
        {
            long q = 0;

            await Task.Run(() =>
            {
                for (int i = 0; i < 30000; i++)
                {
                    q += i;
                    Console.WriteLine("-------------------");
                }

            });
            return q;

        }

        //serialization/deserialization
        static public void E()
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string>
            {
            "User",
           "Admin"
            }
            };

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);

            Account account2 = JsonConvert.DeserializeObject<Account>(json);

            Console.WriteLine($"serialized json {json}");
            Console.WriteLine($"deserialized data in converted json {account2.Email}");
        }

        //c#6 call direct (lambda)
        public static void F() => Console.WriteLine("Lambda method call");

        //c#6 Null-Conditional Operator ('optional' values, a la Swift)
        static Account testAcc = null;
        public static void G()
        {
            Console.WriteLine("Starting...");
            //crashes //   Console.WriteLine(testAcc.GetSomeStringMethod());
            Console.WriteLine(testAcc?.GetSomeStringMethod()); //doesn't print anyting
            string testStr = testAcc?.GetSomeStringMethod() ?? "INITed String"; // if not, then ( cond ? action : reaction)
            testAcc = new Account();
            Console.WriteLine(testAcc?.GetSomeStringMethod());
        }
    }
}
