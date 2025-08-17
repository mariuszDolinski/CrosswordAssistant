using CrosswordAssistant.Entities;
using System.Reflection;

namespace CrosswordAssistant
{
    public static class Logger
    {
        private static readonly string LogPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\LogApp.txt";

        public static LogLevel LogLevel { get; set; } = LogLevel.Warning;

        public static void WriteToLog(LogLevel lvl, string msg, string stackTrace = "")
        {
            if (lvl < LogLevel) return;
            try
            {
                using StreamWriter sw = File.AppendText(LogPath);
                CreateLogEntry(lvl, msg, stackTrace, sw);
            }
            catch
            {
            }
        }

        private static void CreateLogEntry(LogLevel lvl, string msg, string stackTrace, TextWriter tw)
        {
            try
            {
                tw.WriteLine($"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToLongTimeString()}");
                tw.WriteLine($"[{lvl}]: {msg}");
                if (stackTrace.Length > 0) tw.WriteLine($"Stack trace: {stackTrace}");
                tw.WriteLine("----------------------------------------------------------------");
            }
            catch
            {
            }
        }
    }
}
