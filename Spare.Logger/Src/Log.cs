using System;
using System.Linq;

namespace Spare {
  public static class Log {
    public static void Logger() => Console.WriteLine();
    public static void Logger<T>(this T message) => Console.WriteLine(message.ToString());
    public static void Logger<T>(this T message, params object[] rest) => Console.WriteLine(message + " " + string.Join(" ", rest));
    public static void LogNext<T>(this T message) {
      Console.WriteLine(message);
      Console.WriteLine();
    }
    public static void Says<T>(this T message, string subject, string then = "") => Console.WriteLine($">> [{subject}] {message.ToString()} {then}");
    public static void Says<T>(this T message, string subject, string prefix, string suffix, string then) {
      var title = $"[{subject}]";
      if (prefix.Any()) title = prefix + ' ' + subject;
      if (suffix.Any()) title = subject + ' ' + suffix;
      Console.WriteLine($">> {title} {message.ToString()} {then}");
    }
  }
}