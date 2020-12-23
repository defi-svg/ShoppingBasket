using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Shopping.Utils
{
    public class Logger
    {
        //lokal LOG folder from where is executed the application 
        public static string _path = Path.Combine(Environment.CurrentDirectory, "LOG"); 

        public static void logError(string method, Exception ex)
        {
            try
            {
                string error;

                if (ex == null)
                {
                    error= $"{DateTime.Now:dd.MM.yyyy. HH:mm:ss.fff} {method}";
                }
                else
                {
                    error = $"{DateTime.Now:dd.MM.yyyy. HH:mm:ss.fff} {method}  ---- Exception: {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        error += $" inner ex:{ex.InnerException.Message}";

                        if (ex.InnerException.InnerException != null)
                            error += $" inner_inner ex:{ex.InnerException.InnerException.Message}";

                        if (ex.InnerException.InnerException.InnerException != null)
                            error += $" inner_inner_inner ex:{ex.InnerException.InnerException.InnerException.Message}";
                    }

                }
                VerifyExistLogFolder(); //if the folder does not exist make it
                string logFile = Environment.ExpandEnvironmentVariables(
                        @$"%SystemDrive%\Log\ShoppingCart-{DateTime.Now:yyyy-MM-dd}.log");
                using (TextWriter file = System.IO.File.AppendText(logFile))
                {
                    file.WriteLine(error);
                }
            }
            catch { }
        }

        public static void logError(string method, string ex)
        {
            try
            {
                string error;

                if (ex == null)
                {
                    error = $"{DateTime.Now:dd.MM.yyyy. HH:mm:ss.fff} {method}";
                }
                else
                {
                    error = $"{DateTime.Now:dd.MM.yyyy. HH:mm:ss.fff} {method} -- > : {ex}";
                }

                VerifyExistLogFolder();
                string logFile = Environment.ExpandEnvironmentVariables(
                         @$"{_path}\ShoppingCart-{DateTime.Now:yyyy-MM-dd}.log");
                using (TextWriter file = System.IO.File.AppendText(logFile))
                {
                    file.WriteLine(error);
                }
            }
            catch{ }
        }


        /// <summary>
        /// Verify if the folder exist, if not then create folder LOG
        /// </summary>
        public static void VerifyExistLogFolder()
        {
            bool exists = Directory.Exists(_path);

            if (!exists)
                Directory.CreateDirectory(_path);
        }

    }

}
