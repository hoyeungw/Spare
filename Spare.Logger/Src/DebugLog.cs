using System.Diagnostics;

namespace Spare.Logger {
  public static class DebugLog {
    public static void Logger() => Debug.WriteLine("");
    public static void Logger(this string message) => Debug.WriteLine(message + "\n");
    public static void LogNext(this string message) => Debug.WriteLine(message);
    public static void Logger<T>(string message, params T[] args) => Debug.WriteLine(message, args);
  }
}