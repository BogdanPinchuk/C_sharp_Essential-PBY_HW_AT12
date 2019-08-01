using System;
using System.Windows.Forms;

// Завдення - реалізувати миттєву зупинку Progress Bar
// Примітка. Використання інкремента і декремента для реалізації
// швидкої зупинки - займає більше часу - і падає продуктиність
// а знаючи максимум (не 100, так як користувач може не ставити 100)
// його встановлювати і тоді відкочуватися до необхідного значення
// ще один недолік інк/декремента в тому, що для установки на 100%
// необхідно задати 101 і відколитися назад, а при більше 100 виникає помилка
// щоб її уникнути потрібно написати оператор if(...) який кожен раз
// перевірятиме чи не дійщли 99 і останні 2% робити по старому методу і 
// на них не буде миттєвої зупинки, а оператор if(...) - це додатковий час
// і затрачені ресурси

namespace LesApp0
{
    public partial class Form1 : Form
    {
        private int counter = default;

        public Form1()
        {
            InitializeComponent();

            // Установка параметров Таймера.
            InitializeTimer();
        }


        // Обработчик события Тиков Таймера
        private void Timer_Tick(object sender, EventArgs e)
        {
            counter++;
            #region old
            /*
                if (progressBar1.Value < 100)
                    progressBar1.Value++;

                if (progressBar2.Value < 100)
                    progressBar2.Value++;
                */
            #endregion

            ChangeValue(progressBar1);
            ChangeValue(progressBar2);

            void ChangeValue(ProgressBar pb)
            {
                if (pb.Value < pb.Maximum)
                {
                    pb.Value = pb.Maximum;
                    pb.Value = counter;
                }
            }
        }

        private void InitializeTimer()
        {
            // 1 second = 1000 mlsec.
            // 1000 mlsec. - 1 тик в секунду. 100 mlsec. - 10 тиков в секунду.
            // 10 mlsec. - 100 тиков в секунду. 1 mlsec. - 1000 тиков в секунду.
            // Интервал генерации события Таймера.
            timer.Interval = 10;

            // Запуск Таймера.
            timer.Start();

            // Статус Таймера.
            timer.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer.Enabled = false;
        }

        /// <summary>
        /// Скидання прогрес-бару
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
            counter = 0;
            progressBar1.Value = progressBar1.Minimum;
            progressBar2.Value = progressBar2.Minimum;
        }
    }
}
