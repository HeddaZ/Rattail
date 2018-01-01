using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Rattail
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 重复启动

            bool allowStart;
            var mutex = new System.Threading.Mutex(true, "Rattail", out allowStart); //单实例互斥
            if (!allowStart)
            {
                return;
            }

            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Rattail());
        }
    }
}
