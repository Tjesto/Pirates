using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pirates.Windows;

namespace Pirates
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            runApplicaiton();
            //Application.Run(new MainWindow());
        }

        private static void runApplicaiton()
        {
            Form startForm = null;
            switch (Utils.ACCESS_MODE)
            {
                case AccessMode.DEBUG:
                    startForm = Utils.getDefaultStartPoint();
                    break;
                case AccessMode.DEBUG_GAME:
                    startForm = new MainWindow();
                    break;
                case AccessMode.DEBUG_GAME_MENU:
                    //startForm = new GameMenu();
                    break;
                case AccessMode.DEBUG_MENU:
                    startForm = new MainMenuWindow();
                    break;
                case AccessMode.RELEASE:
                    startForm = Utils.getDefaultStartPoint();
                    break;
                default:
                    startForm = Utils.getDefaultStartPoint();
                    break;
            }

            Application.Run(startForm != null ? startForm : Utils.getDefaultStartPoint());
        }
    }
}
