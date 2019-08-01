using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // join unicode
            Console.OutputEncoding = Encoding.Unicode;

            // рандом
            Random rnd = new Random();

            // створення рахунку
            Account account = new Account(rnd.Next(0, int.MaxValue));

            // info
            Console.WriteLine($"\n\tДепутатський каунт створено з сумою {account.Amount:N0} грн.");

            // додавання подій
            account.EventAdded += account.ShowMessage;
            account.EventWithdraw += account.ShowMessage;

            // ложимо гроші на рахунок
            account.Put(rnd.Next(1, ushort.MaxValue));

            // знімаємо гроші з рахунку
            account.Withdraw(rnd.Next(1, ushort.MaxValue));

            // результат рахунку
            Console.WriteLine($"\n\ttДепутатський акаунт має наступну суму {account.Amount:N0} грн.");

            // repeat
            DoExitOrRepeat();
        }

        /// <summary>
        /// Метод виходу або повторення методу Main()
        /// </summary>
        static void DoExitOrRepeat()
        {
            Console.WriteLine("\n\nСпробувати ще раз: [т, н]");
            Console.Write("\t");
            var button = Console.ReadKey(true);

            if ((button.KeyChar.ToString().ToLower() == "т") ||
                (button.KeyChar.ToString().ToLower() == "n")) // можливо забули переключити розкладку клавіатури
            {
                Console.Clear();
                Main();
                // без використання рекурсії
                //Process.Start(Assembly.GetExecutingAssembly().Location);
                //Environment.Exit(0);
            }
            else
            {
                // закриває консоль
                Environment.Exit(0);
            }
        }
    }
}
