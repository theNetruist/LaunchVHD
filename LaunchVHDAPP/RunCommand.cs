using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaunchVHDAPP
{
    class RunCommand
    {


        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        public static string run(string command)
        {
            return run(command, null, false, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="args">Arguments to run with command.</param>
        /// <returns></returns>
        public static string run(string command, string args)
        {
            return run(command, args, false, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="args">Arguments to run with command.</param>
        /// <returns></returns>
        public static string run(string command, string[] args)
        {
            string argsB = "";
            foreach (string s in args)
            {
                argsB = argsB + " " + args;
            }
            return run(command, argsB, false, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="showWindow">Show command-line window.</param>
        /// <returns></returns>
        public static string run(string command, bool showWindow)
        {
            return run(command, null, showWindow, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="args">Arguments to run with command.</param>
        /// <param name="showWindow">Show command-line window.</param>
        /// <returns></returns>
        public static string run(string command, string args, bool showWindow)
        {
            return run(command, args, showWindow, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="args">Arguments to run with command.</param>
        /// <param name="showWindow">Show command-line window.</param>
        /// <returns></returns>
        public static string run(string command, string[] args, bool showWindow)
        {
            string argsB = "";
            foreach (string s in args)
            {
                argsB = argsB + " " + args;
            }
            return run(command, argsB, showWindow, true);
        }

        /// <summary>
        /// Run a command as if from a batch file. Returns Standard Output.
        /// </summary>
        /// <param name="command">Command to Run.</param>
        /// <param name="args">Arguments to run with command.</param>
        /// <param name="showWindow">Show command-line window.</param>
        /// <param name="waitForExit">Wait for command to finish before continuing.</param>
        /// <returns></returns>
        public static string run(string command, string args, bool showWindow, bool waitForExit)
        {
            System.Diagnostics.ProcessStartInfo procStartInfo;
            if (args == null)
            {
                procStartInfo = new System.Diagnostics.ProcessStartInfo(command);
            }
            else
            {
                procStartInfo = new System.Diagnostics.ProcessStartInfo(command, args);
            }
            procStartInfo.RedirectStandardOutput = !showWindow;
            procStartInfo.UseShellExecute = showWindow;
            procStartInfo.CreateNoWindow = !showWindow;
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            string result = "";
            if (!showWindow)
            {
                result = proc.StandardOutput.ReadToEnd();
            }
            if (waitForExit)
            {
                proc.WaitForExit();
            }
            return result;
        }

    }
}
