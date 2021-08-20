using System.Diagnostics;

namespace Spare.Debugger {
  public static class Log {
    public static void Logger() => Debug.Print("");
    public static void Logger<T>(this T message) => Debug.Print(message.ToString());
    public static void Logger<T>(this T message, params object[] rest) => Debug.Print(message + " " + string.Join(" ", rest));
    public static void LogNext<T>(this T message) {
      Debug.Print(message.ToString());
      Debug.Print("");
    }
    public static void Says<T>(this T message, string subject) => Debug.Print($">> [{subject}] {message.ToString()}");
  }
}