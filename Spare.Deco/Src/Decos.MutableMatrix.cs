using System.Collections.Generic;
using Palett.Types;
using Veho.Mutable.Matrix;
using Veho.Types;

namespace Spare {
  public static partial class Decos {
    public static string Deco<T>(
      this IReadOnlyList<IReadOnlyList<T>> matrix,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Rowwise,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      return matrix.ToMatrix().Deco(tab, hasAnsi, orient, presets, effects);
    }
  }
}