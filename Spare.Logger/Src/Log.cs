using System;

namespace Spare.Logger {
  public static  class Log {
    public static void Logger() => Console.WriteLine();
    public static void Logger(this string message) => Console.WriteLine(message);
    public static void Logger<T>(string message, params T[] args) => Console.WriteLine(message, args);
    public static void LogNext(this string message) {
      Console.WriteLine(message);
      Console.WriteLine();
    }
  }
}