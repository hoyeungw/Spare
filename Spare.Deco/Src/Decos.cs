using Spare.Padder;
using Texting.Bracket;
using Typen;
using Veho.Matrix;
using Veho.Matrix.Rows;
using Veho.Vector;
using static Texting.Enums.Chars;

namespace Spare.Deco {
  public static class Decos {
    public static string Deco<T>(this T[] vector) => vector.Length == 0
      ? "[]"
      : vector.Join(COSP).Bracket();

    public static string Deco<T>(this T[,] matrix, byte tab = 1) {
      if (!matrix.Any()) return "[]";
      var tabSpace = new string(' ', tab * 2);
      var (xlo, ylo) = (matrix.XLo(), matrix.YLo());
      var head = xlo != 0 || ylo != 0 ? $"{xlo}-{ylo}-based".Parenth() + SP : VO;
      var texts = head.Length > 0 ? matrix.ZeroOut(Conv.ToStr) : matrix.Map(Conv.ToStr);
      var padded = texts.Padder();
      return head + (LF + padded.MapRows(row => tabSpace + row.Join(COSP)).Join(COLF) + COLF).Bracket();
    }
  }
}