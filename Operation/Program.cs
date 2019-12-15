using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace excel_operation
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
            //Application.Run(new excel_operation.DataAnalysis.DA_Opponent());
            //Application.Run(new PDD());
            Application.Run(new MainForm());
            //Application.Run(new Test.test_async());
            //Application.Run(new Login_TaoBao());
            //Application.Run(new excel_operation.DataAnalysis.CanMou_KeysHelper());


        }
    }
}
