using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("call method (select letter):");
           var strRead = Console.ReadKey().Key.ToString();

            Console.WriteLine();
            Console.WriteLine($" method called is: {strRead}()");

           
            MethodInfo callMethod = typeof(General).GetMethod(strRead);
            if (callMethod == null)
            {
            callMethod = typeof(Parallel).GetMethod(strRead);
            }


            object result = callMethod.Invoke(null, null);

            Console.ReadKey();

        }
     
        

    }

    public class Account : IDisposable
{
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedDate { get; set; }
    public IList<string> Roles { get; set; }

        public string GetSomeStringMethod() => "some string";

        ~Account()
        {

        }

        public void Dispose()
        {
        }
}
}
