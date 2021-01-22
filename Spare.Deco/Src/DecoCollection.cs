using System;
using Veho.Vector;

namespace Spare.Deco {
  public static class DecoCollection {
    public static string DecoVector<T>(this T[] vec) where T : IFormattable {
      var arr = vec.Map(x => x.ToString());
      return "[" + string.Join(", ", arr) + "]";
    }
  }
}