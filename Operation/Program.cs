using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Operation
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Operation.DataAnalysis.DA_Opponent());
            //Application.Run(new PDD());
            Application.Run(new MainForm());
            //Application.Run(new Test.MySqlTest());
            //Application.Run(new Login_TaoBao());
            //Application.Run(new Operation.DataAnalysis.CanMou_KeysHelper());


        }
    }
}
