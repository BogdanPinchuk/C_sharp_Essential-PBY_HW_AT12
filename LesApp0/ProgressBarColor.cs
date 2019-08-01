using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// info from http://qaru.site/questions/75867/how-to-change-the-color-of-progressbar-in-c-net-35
// виклик: ProgressBarColor.SetState(progressBar1, 2);

namespace LesApp0
{
    /// <summary>
    /// Кольоровий прогрес-бар
    /// </summary>
    public static class ProgressBarColor
    {
        public enum Color
        {
            None,
            Green,
            Red,
            Yellow
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        /// <summary>
        /// метод зміни кольору
        /// </summary>
        /// <param name="pBar">progress bar</param>
        /// <param name="state">1 - green, 2 - red, 3 - yellow</param>
        public static void SetState(this ProgressBar pBar, Color color)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)(int)color, IntPtr.Zero);
        }
    }
}
