using System;
using Texting.Lange;
using Texting.Padder;
using Veho.Columns;
using Veho.Matrix;
using Veho.Vector;

namespace Spare.Padder {
  public static class Padders {
    public static string[,] Padder(this string[,] matrix, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      var padder = PadFactory.ToPad(' ', ansi);
      var widths = matrix.MapColumns(
        col => col.Fold((max, tx) => Math.Max(max, lange(tx)), 0)
      );
      return matrix.Map((i, j, v) => padder(v, widths[j]));
    }
    public static string[] RPadder(this string[] column, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      var padder = PadFactory.ToRPad(' ', ansi);
      var width = column.Fold((max, tx) => Math.Max(max, lange(tx)), 0);
      return column.Map(word => padder(word, width));
    }
    public static string[] LPadder(this string[] column, bool ansi = true) {
      var lange = Langes.ToLange(ansi);
      var padder = PadFactory.ToLPad(' ', ansi);
      var width = column.Fold((max, tx) => Math.Max(max, lange(tx)), 0);
      return column.Map(word => padder(word, width));
    }
  }
}