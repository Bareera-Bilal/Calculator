using System;
using System.Windows.Forms;

namespace Calculator.Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the calculator application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Form1()); // Replace 'Form1' with your main form name if different
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while launching the calculator:\n{ex.Message}",
                                "Startup Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
