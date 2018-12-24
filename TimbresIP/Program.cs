using System;
using System.Windows.Forms;
using TimbresIP.Controller;

namespace TimbresIP
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            log.Info("App started!");
            MainController mainController = new MainController();
            mainController.init();
            Console.ReadKey();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

        }
    }
}
