using System.Diagnostics;
using System.IO.Pipes;

namespace simple_ids_cam_view
{
    static class Program
    {
        private static NamedPipeClientStream _pipeClient;
        private static StreamWriter _pipeWriter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main(string[] args)
        {
            string processName = "simple_ids_cam_view"; // Replace with your actual process name (without .exe)

            // Check if the process is already running
            if (Process.GetProcessesByName(processName).Length > 1)
            {
                MessageBox.Show("Application is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (args.Length < 1)
            {
                //ExceptionHelper.ShowWarningMessage("Pipe name argument is missing.");
                Debug.WriteLine("Pipe name argument is missing.");
                //return;
            }
            else
            {
                // read pipeName and connector name from the arguments
                string pipeName = args[0];
                //if (args.Length > 1)
                //    ProjectSettings.SetConnectorName(args[1]);

                #region -- IPC
                // Initialize the named pipe client
                _pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut);
                _pipeClient.Connect();

                _pipeWriter = new StreamWriter(_pipeClient) { AutoFlush = true };

                // Send an initial message to the parent
                _pipeWriter.WriteLine("1. Child process initialized.");
                #endregion
            }


            #region -- MAIN APPLICATION
            // Run the application with the main form
            Application.ApplicationExit += OnApplicationExit;
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalExceptionHandler);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalUnhandledExceptionHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm mainForm = new(_pipeWriter);
            Application.Run(mainForm);
            #endregion

            // finally
            Cleanup();
        }

        // Handler for UI thread exceptions
        static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred: {e.Exception.Message}",
                "ThreadException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Cleanup();
        }

        // Handler for non-UI thread exceptions
        static void GlobalUnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"An unexpected error occurred: {e.ExceptionObject}",
                "UnhandledException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Cleanup();
        }

        //Application Exit event
        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                //// Send final data to the parent process before closing
                //_pipeWriter?.WriteLine("2. Child process is exiting.");
                //_pipeWriter?.WriteLine($"-t Name -s {ProjectSettings.ConnectorName}");
            }
            catch
            {
                // Ignore errors during shutdown
            }
        }


        private static void Cleanup()
        {
            try
            {
                _pipeWriter?.Close();
                _pipeClient?.Close();
            }
            catch
            {
                // Ignore cleanup exceptions
            }
        }

    }
}
