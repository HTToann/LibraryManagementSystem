using System;
using System.Windows.Forms;

namespace LibrarySystem
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
<<<<<<< HEAD
            Application.Run(new LoginFrom());
=======
            Application.Run(new MainForm());
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
        }
    }
}
