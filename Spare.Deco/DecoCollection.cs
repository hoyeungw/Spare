using System;
using System.Linq;

namespace Spare.Deco {
  public static class DecoCollection {
    public static string DecoVector<T>(this T[] vec) {
      var arr = vec.Select(x => x.ToString());
      return "[" + string.Join(", ", arr) + "]";
    }
  }
}