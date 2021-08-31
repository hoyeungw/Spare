using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting.Enums;
using Texting.Joiner;
using Typen;
using Veho.Matrix;
using Veho.Rows;
using Veho.Types;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decos {
    public static string Deco<T>(
      this T[,] matrix,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Rowwise,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!matrix.Any()) return "[]";
      var textMatrix = matrix.Map(Conv.ToStr);
      if (presets != null && (hasAnsi = true)) {
        textMatrix = textMatrix.Fluo(orient, presets.Value, effects);
      }
      return textMatrix.Padder(hasAnsi)
                       .MapRows(row => row.Join(COSP))
                       .ContingentLines(delim: COLF, level: tab, brac: Brac.BRK);
    }
  }
}