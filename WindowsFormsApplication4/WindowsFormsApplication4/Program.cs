using System;
using System.Windows.Forms;

namespace LIL
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(defaultValue: false);
            Application.Run(new LILAutoClickerForm());
        }
    }
}
