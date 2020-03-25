using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            EventTry eventTry = new EventTry();
            eventTry.OnChange += () => Console.WriteLine("Sub 1");
            eventTry.OnChange += () => Console.WriteLine("Sub 2");
            
            eventTry.RaiseExcept();

            PrimeNumbers prime1 = new PrimeNumbers();
            Console.WriteLine(prime1.GetPrimeMethod1(10));

            PrimeNumbers prime2 = new PrimeNumbers();
            Console.WriteLine(prime2.GetPrimeMethod2(10));

            Thread thread1 = new Thread(() => {
                Console.WriteLine($"Start fir: {Thread.CurrentThread.Name} {DateTime.Now.ToString("hh:mm:s:ms")}");

            int[] array = new int[] { 1, 3, 5, 7, 9 }; 
            foreach (int el in array)
                Console.WriteLine($"{el} => {prime1.GetPrimeMethod1(10)}");
            });
            thread1.Name = "primul thread";
            thread1.Start();
            Console.ReadLine();

            Console.ReadLine();
        }
    }

    public class EventTry
    {
        public event Action OnChange = delegate { };
        public void RaiseExcept()
        {
                OnChange();
        }
    }

    public class PrimeNumbers
    {
        public int GetPrimeMethod1 (int number)
        {
            int result = number - 1;
            int j;

            for (int i = 2; i <= number; i++)
            {
                for (j = 2; j <= i; j++)
                    if (i % j == 0)
                        break;
                if (j == i)
                    result = i;
            }

            return result;
        }

        public int GetPrimeMethod2 (int number)
        {
            int result = number - 1;
            int j;

            for (int i = number - 1; i >= 2; i--)
            {
                
                for (j = 2; j <= i; j++)
                {
                    if (i % j == 0)
                        break;
                }


                if (i == j)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }
    }
}
