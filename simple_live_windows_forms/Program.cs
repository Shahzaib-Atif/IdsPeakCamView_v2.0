using System.Diagnostics;

namespace simple_ids_cam_view
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            string processName = "simple_ids_cam_view";

            // Check if the process is already running
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("Application is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            #region -- MAIN APPLICATION
            // Run the application with the main form
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalUnhandledExceptionHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new();
            Application.Run(mainForm);
            #endregion
        }

        // Handler for UI thread exceptions
        static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}",
                "ThreadException", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Handler for non-UI thread exceptions
        static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred: {e.ExceptionObject}",
                "UnhandledException", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
