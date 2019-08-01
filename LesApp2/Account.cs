using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Рахунок в банку
    /// </summary>
    class Account
    {
        /// <summary>
        /// Обробник стану рахунку
        /// </summary>
        /// <param name="str"></param>
        public delegate void AccountStateHandler(string str);

        /// <summary>
        /// Сума в банку
        /// </summary>
        public int Amount { get; private set; }

        private event AccountStateHandler eWithdraw = null;
        private event AccountStateHandler eAdded = null;

        /// <summary>
        /// Зняття грошей з рахунку
        /// </summary>
        public event AccountStateHandler EventWithdraw
        {
            add { eWithdraw += value; }
            remove { eWithdraw -= value; }
        }
        /// <summary>
        /// Додавання грошей на рахунок
        /// </summary>
        public event AccountStateHandler EventAdded
        {
            add { eAdded += value; }
            remove { eAdded -= value; }
        }

        /// <summary>
        /// конструктор користувача
        /// </summary>
        /// <param name="amount"></param>
        public Account(int amount)
        {
            this.Amount = amount;
        }

        /// <summary>
        /// Кладіння на рахунок
        /// </summary>
        /// <param name="money"></param>
        public void Put(int money)
        {
            Amount += money;
            eAdded($"\n\tНа рахунок поступила наступна сума в розмірі {money:N0} грн.");
        }

        /// <summary>
        /// Зняття з рахунку
        /// </summary>
        /// <param name="money"></param>
        public void Withdraw(int money)
        {
            Amount -= money;
            eWithdraw($"\n\tЗ рахунку знята наступна сума в розмірі {money:N0} грн.");
        }

        /// <summary>
        /// Вивід на екран повідомлення
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

    }
}
