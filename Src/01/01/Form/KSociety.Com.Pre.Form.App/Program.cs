using System;
using System.Windows.Forms;

namespace KSociety.Com.Pre.Form.App
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Base.Pre.Model.Utility.Utility.PriorProcess() != null)
            {
                MessageBox.Show(@"Another instance of the app is already running.");
                return;
            }
            KSociety.Com.Srv.Contract.ProtoModel.Configuration.ProtoBufConfiguration();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var startUp = new Class.StartUp();
            Application.Run();
            //Application.Run(new Form1());
        }
    }
}
