using Palett.Fluos;
using Palett.Utils.Types;
using Spare.Padder;
using Texting.Bracket;
using Typen;
using Veho.Matrix;
using Veho.Matrix.Rows;
using Veho.Types;
using Veho.Vector;
using static Texting.Enums.Chars;

namespace Spare.Deco {
  public static class Decos {
    public static string Deco<T>(
      this T[] vector,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (vector.Length == 0) return "[]";
      if (presets == null) return vector.Join(COSP).Bracket();
      return vector.Fluo(presets.Value, effects).Join(COSP).Bracket();
    }

    public static string Deco<T>(
      this T[,] matrix,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Rowwise,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!matrix.Any()) return "[]";
      var tabSpace = new string(' ', tab * 2);
      var (xlo, ylo) = (matrix.XLo(), matrix.YLo());
      var head = xlo != 0 || ylo != 0 ? $"{xlo}-{ylo}-based".Parenth() + SP : VO;
      var texts = head.Length > 0 ? matrix.ZeroOut(Conv.ToStr) : matrix.Map(Conv.ToStr);
      if (presets != null) {
        hasAnsi = true;
        texts = texts.Fluo(orient, presets.Value, effects);
      }
      var padded = texts.Padder(hasAnsi);
      return head + (LF + padded.MapRows(row => tabSpace + row.Join(COSP)).Join(COLF) + COLF).Bracket();
    }
  }
}