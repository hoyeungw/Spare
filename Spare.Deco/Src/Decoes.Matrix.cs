using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting;
using Texting.Bracket;
using Texting.Enums;
using Typen;
using Veho.Enumerable;
using Veho.Matrix;
using Veho.Rows;
using Veho.Types;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decoes {
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

    public static string DecoFlat<T>(this T[,] matrix, string xde = COSP, string yde = COSP) {
      if (!matrix.Any()) return "[]";
      var textMatrix = matrix.Map(Conv.ToStr);
      return textMatrix.Rows()
                       .Map(row => row.Join(yde).Br(Brac.BRK))
                       .Join(xde).Br(Brac.BRK);
    }
  }
}