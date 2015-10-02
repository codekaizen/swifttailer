﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Media;

namespace SwiftTailer.Wpf
{
    public class Settings
    {
        /// <summary>
        /// The display buffer in kilobytes (i.e. 1 = 1000 bytes). Default 255. This will control how many kilobytes will be read from the back of the log file. For example, if the file is 1000 bytes and this value is set to 100, then it will only read bytes 900 thru 1000.
        /// </summary>
        public static int SeekBuffer { get; set; } = 1000;

        /// <summary>
        /// The maximum number of lines to display in the log tailing window.
        /// </summary>
        public static int MaxDisplayLogLines = 13000;
        
        /// <summary>
        /// Polling interval in seconds. Default = 1000
        /// </summary>
        public static int PollingInterval { get; set; } = 1000; // Do NOT change this to use a timespan!

        /// <summary>
        /// The font face that will be used in log windows
        /// </summary>
        public static FontFamily LogWindowFontFamily = new FontFamily("Courier New");

        /// <summary>
        /// The directory in which all supporting files should be stored (e.g. logs, user configurations, etc)
        /// </summary>
        public static readonly string WorkingDirectory;

        static Settings()
        {
            var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            WorkingDirectory = Path.Combine(localAppDataPath, "SwiftTailer");

            // if the app directory doesn't exist, create it
            if (!Directory.Exists(WorkingDirectory))
            {
                Trace.WriteLine($"{WorkingDirectory} did not exist. Creating...");
                Directory.CreateDirectory(WorkingDirectory);
            }
        }
    }
}
