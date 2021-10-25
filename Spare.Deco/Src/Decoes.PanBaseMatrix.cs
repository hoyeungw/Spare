using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting;
using Texting.Bracket;
using Typen;
using Veho.Matrix;
using Veho.PanBase.Matrix;
using Veho.Rows;
using Veho.Types;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decoes {
    public static string DecoM1B<T>(
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