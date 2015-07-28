using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            //    D();

            //     for (int i = 0; i < 30000; i++)
            //     {
            //      Console.WriteLine("XXXXXXXXXXXX ");
            //      }
            // E();

            Console.WriteLine("call method (select letter):");
           var strRead = Console.ReadKey().Key.ToString();

            Console.WriteLine();
            Console.WriteLine($" method called is: {strRead}()");
            MethodInfo callMethod = typeof(Program).GetMethod(strRead);
            object result = callMethod.Invoke(null, null);

            Console.ReadKey();

        }
        public string First { get; } = "Jane";
        //call direct 
        public static async void F() => Console.WriteLine("Lambda method call");
        

        //async task stuff
        public static async void D()
        {
            long q = await DoStuff();
            string a = "Alex B";
            string b = "nanaaa";
            var s = $"{a} is {b}";
            //  First = "LOL";

            WriteLine($"RESULT: {q} string: {s}");
            //  string x = null;
            //   if (x == null) throw new ArgumentNullException(nameof(x));

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["Steaua"] = "aaa";

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
    }

    public class Account : IDisposable
{
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string> Roles { get; set; }

        ~Account()
        {

        }

        public void Dispose()
        {
        }
}
}
