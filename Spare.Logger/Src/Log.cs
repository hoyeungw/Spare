using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Spare {
  public static class Log {
    public static void Logger() => Console.WriteLine();
    public static void Logger<T>(this T message) => Console.WriteLine(message.ToString());
    public static void Logger<T>(this T message, params object[] rest) => Console.WriteLine(message + " " + string.Join(" ", rest));
    public static void LogNext<T>(this T message) {
      Console.WriteLine(message);
      Console.WriteLine();
    }
    private static readonly Regex Lf = new Regex("\\n", RegexOptions.Compiled);
    private static readonly Regex InitWs = new Regex(@"^\s", RegexOptions.Compiled);
    private static readonly Regex InitWsBrac = new Regex(@"^\s*[[({]", RegexOptions.Compiled);
    public static void Says<T>(this T message, string subject, string then = "") {
      var text = message.ToString();
      string link;
      if (InitWsBrac.IsMatch(text)) link = " ";
      else if (InitWs.IsMatch(text)) link = "\n";
      else if (Lf.IsMatch(text)) link = "\n   ";
      else link = " ";
      Console.WriteLine($">> [{subject}]{link}{text} {then}");
    }
    public static void Says<T>(this T message, string subject, string prefix, string suffix, string then) {
      var title = $"[{subject}]";
      if (prefix.Any()) title = prefix + ' ' + subject;
      if (suffix.Any()) title = subject + ' ' + suffix;
      Console.WriteLine($">> {title} {message.ToString()} {then}");
    }
  }
}