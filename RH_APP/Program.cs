using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mallaca;
using System.Threading;
namespace RH_APP
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
            //Application.Run(new GUI.chooseYourBikeUI());
            Application.Run(new GUI.LoginScreen());
            

            
        }

        private static void insertMeasurementTest()
        {
            DBConnect db = new DBConnect();
            Measurement m = new Measurement();

            db.SaveMeasurement(m, db.getNewTrainingSessionId(1), 1);
        }
    }


}
