using System;

namespace Spare.Logger {
  public static class Log {
    public static void Logger() => Console.WriteLine();
    public static void Logger<T>(this T message) => Console.WriteLine(message.ToString());
    public static void Logger<T>(this T message, params object[] rest) => Console.WriteLine(message + " " + string.Join(" ", rest));
    public static void LogNext<T>(this T message) {
      Console.WriteLine(message);
      Console.WriteLine();
    }
  }
}