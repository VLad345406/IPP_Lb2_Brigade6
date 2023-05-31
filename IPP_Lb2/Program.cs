using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPP_Lb2.Windows;

namespace IPP_Lb2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void StartFirstControlWindow()
        {
            Application.Run(new FirstControlWindow());
        }
        
        private static void StartSecondControlWindow()
        {
            Application.Run(new SecondControlWindow());
        }
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var threadStartFirstControlWindow = new ThreadStart(StartFirstControlWindow);
            var threadFirstControlWindow = new Thread(threadStartFirstControlWindow);
            threadFirstControlWindow.Start();
            
            var threadStartSecondControlWindow = new ThreadStart(StartSecondControlWindow);
            var threadSecondControlWindow = new Thread(threadStartSecondControlWindow);
            threadSecondControlWindow.Start();
            
            Application.Run(new MainWindow());
        }
    }
}