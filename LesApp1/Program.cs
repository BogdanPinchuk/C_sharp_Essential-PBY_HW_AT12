using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        

        static void Main()
        {
            // join unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення людини
            Human human = new Human();

            // Дія яка виконуватиметься при виклику події
            human.EventJumpE += human.Jump;

            // пускаємо на пробіжку
            Console.WriteLine($"\n\tБіжимо лише {human.Iteration} разів:\n");
            human.Move(Human.TypeOfMove.TenTimes);

            // пускаємо на іншу пробіжку
            Console.WriteLine($"\n\n\tБіжимо до {human.Count} стрибків:\n");
            human.Move(Human.TypeOfMove.ToFifeJump);

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
