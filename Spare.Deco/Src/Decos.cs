using Spare.Padder;
using Veho.Matrix;
using Veho.Vector;

namespace Spare.Deco {
  public static class Decos {
    // return "[" + string.Join(", ", arr) + "]";
    public static string Deco<T>(this T[] vector) => "[" + vector.Join(", ") + "]";

    public static string Deco<T>(this T[,] matrix) {
      var mx = matrix.Map(x => x.ToString());
      var padded = mx.Padder();
      return "[" + padded.MapRows(row => row.Join(",")).Join(",\n") + "]";
    }
  }
}