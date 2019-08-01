using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    delegate void Delegate();

    /// <summary>
    /// Людина
    /// </summary>
    class Human
    {
        /// <summary>
        /// Вид руху
        /// </summary>
        public enum TypeOfMove
        {
            /// <summary>
            /// пробіжка 10 разів
            /// </summary>
            TenTimes,
            /// <summary>
            /// бігати до тих пір доки 5 разі не пригне
            /// </summary>
            ToFifeJump
        }

        /// <summary>
        /// Рандом, для того щоб були випадкові числа і без повтрень,
        /// необхідно його створювати зовні
        /// </summary>
        private Random rnd = new Random();

        /// <summary>
        /// Кількість пробіжок
        /// </summary>
        public int Iteration { get; private set; } = 10;
        /// <summary>
        /// Кількість стрибків
        /// </summary>
        public int Count { get; private set; } = 5;

        private event Delegate eJumpE;
        public event Delegate EventJumpE
        {
            add { eJumpE += value; }
            remove { eJumpE -= value; }
        }

        /// <summary>
        /// Двигай =)
        /// </summary>
        public void Move(TypeOfMove type)
        {
            switch (type)
            {
                case TypeOfMove.TenTimes:
                    for (int i = 0; i < Iteration; i++)
                    {
                        if (i == rnd.Next(0, Iteration))
                        {
                            eJumpE();
                        }
                        else
                        {
                            Console.Write("Move ");
                        }
                    }
                    break;
                case TypeOfMove.ToFifeJump:
                    for (int i = 0, j = 0; j < Count; i++)
                    {
                        if (i == rnd.Next(0, Iteration))
                        {
                            eJumpE();
                            j++;
                        }
                        else
                        {
                            Console.Write("Move ");
                        }

                        // захист від зациклення
                        if (i == Iteration - 1)
                        {
                            i = 0;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Пригай
        /// </summary>
        public void Jump()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Jump ");
            Console.ResetColor();
        }
    }
}
