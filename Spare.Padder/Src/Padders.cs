﻿using System;
using Texting.Lange;
using Texting.Padder;
using Veho.Matrix;
using Veho.Matrix.Columns;
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
  }
}