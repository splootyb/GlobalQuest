using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalQuest
{
    internal static class Log
    {
        public static LogLevel LogLevel;
        public static void Debug(string Message)
        {
            if (LogLevel < LogLevel.Debug)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[LocalQuest - DEBUG] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Complete(string Message)
        {
            if (LogLevel < LogLevel.Info)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[LocalQuest - COMPLETE] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warn(string Message)
        {
            if (LogLevel < LogLevel.Warn)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[LocalQuest - WARN] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string Message)
        {
            if (LogLevel < LogLevel.Error)
            {
                return;
            }
            UiTools.ShowBanner(Message, ConsoleColor.Red);
        }

        public static void Info(string Message)
        {
            if (LogLevel < LogLevel.Info)
            {
                return;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[LocalQuest - INFO] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public enum LogLevel
    {
        None,
        Error,
        Warn,
        Info,
        Debug,
    }
}
