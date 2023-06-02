using System;
using System.Threading;
using System.Windows.Forms;
using IPP_Lb2.Windows;

namespace IPP_Lb2
{
    internal static class Program
    {
        //private static MainWindow _mainWindow;
        
        private static void StartSecondControlWindow()
        {
            Application.Run(new SecondControlWindow());
        }
        
        private static void StartFirstControlWindow()
        {
            Application.Run(new FirstControlWindow());
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var threadStartSecondControlWindow = new ThreadStart(StartSecondControlWindow);
            var threadSecondControlWindow = new Thread(threadStartSecondControlWindow);
            threadSecondControlWindow.Start();
            
            var threadStartFirstControlWindow = new ThreadStart(StartFirstControlWindow);
            var threadFirstControlWindow = new Thread(threadStartFirstControlWindow);
            threadFirstControlWindow.Start();
            
            Application.Run(new MainWindow());
            threadFirstControlWindow.Abort();
            threadSecondControlWindow.Abort();
        }
    }
}