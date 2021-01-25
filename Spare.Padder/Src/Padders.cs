using System;
using Veho.Matrix;
using Veho.Vector;

namespace Spare.Padder {
  public static class Padders {
    public static string[,] Padder(this string[,] matrix) {
      var widths = matrix.MapColumns(
        col => col.Fold((l, t) => Math.Max(l, t.Length), 0)
      );
      return matrix.Map((i, j, v) => v.PadLeft(widths[j]));
    }
  }
}