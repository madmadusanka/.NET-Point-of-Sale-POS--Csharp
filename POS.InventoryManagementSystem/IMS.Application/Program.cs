using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.ExpressApp.MiddleTier;
using FinalPoject.UserInterface.Dashboard;
using FinalPoject.UserInterface.Exp;
using FinalPoject.UserInterface.Orders;
using IMS.Framework;

namespace FinalPoject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormLogin());
            }
            catch(Exception ex)
            {
                IMS.Framework.Logger.Error(ex);
            }
       
        }
    }
}
