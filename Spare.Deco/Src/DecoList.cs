using System.Collections.Generic;
using Palett.Types;
using Typen;
using Veho.List;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decos {
    public static string Deco<T>(
      this IList<T> vector,
      string delim = COSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      return vector.MapToArray(Conv.ToStr).Deco(delim, presets, effects);
    }
  }
}