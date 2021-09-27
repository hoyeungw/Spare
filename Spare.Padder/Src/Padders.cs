using System;
using System.Collections.Generic;
using System.Linq;
using Texting;
using Veho.Columns;
using Veho.Matrix;
using Veho.Vector;

namespace Spare.Padder {
  public static class LengthUtil {
    public static int MaxLength(this IReadOnlyList<string> column, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      return column.Max(tx => lange(tx));
    }
    public static int MaxLength<T>(this IReadOnlyList<T> column, Func<T, string> selector, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      return column.Max(x => lange(selector(x)));
    }
  }

  public static class Padders {
    public static string[,] Padder(this string[,] matrix, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      var padder = PadFactory.ToPad(' ', ansi);
      var widths = matrix.MapColumns(
        col => col.Fold((max, tx) => Math.Max(max, lange(tx)), 0)
      );
      return matrix.Map((i, j, v) => padder(v, widths[j]));
    }
    public static string[] RPadder(this IReadOnlyList<string> column, bool ansi = true) {
      var padder = PadFactory.ToRPad(' ', ansi);
      var width = column.MaxLength(ansi);
      return column.Map(word => padder(word, width));
    }
    public static string[] LPadder(this IReadOnlyList<string> column, bool ansi = true) {
      var padder = PadFactory.ToLPad(' ', ansi);
      var width = column.MaxLength(ansi);
      // var lange = Langes.ToLange(ansi);
      // var width = column.Fold((max, tx) => Math.Max(max, lange(tx)), 0);
      return column.Map(word => padder(word, width));
    }
  }
}