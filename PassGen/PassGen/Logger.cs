using System;
using System.Collections.Generic;
using System;
using System.IO;

public static class Logger
{
    private static readonly string logFilePath = "log.txt";

    public static void Log(string message)
    {
        try
        {
            // Get current timestamp
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Construct log entry
            string logEntry = $"{timestamp}: {message}";

            // Write log entry to file
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        catch (Exception ex)
        {
            // If logging fails, write the exception to the console
            Console.WriteLine($"Error occurred while logging: {ex.Message}");
        }
    }
}
