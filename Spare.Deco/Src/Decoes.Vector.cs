using System.Collections.Generic;
using System.Linq;
using Palett.Fluos;
using Palett.Types;
using Texting;
using Texting.Enums;
using Typen;
using Veho.Sequence;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decoes {
    public static string Deco<T>(
      this IReadOnlyList<T> vector,
      string delim = COSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!vector.Any()) return "[]";
      var textVector = typeof(T) == typeof(string)
        ? vector.Cast<IReadOnlyList<T>, IReadOnlyList<string>>()
        : vector.Map(Conv.ToStr);
      if (presets != null) textVector = textVector.Fluo(presets.Value, effects);
      return textVector.ContingentLines(delim, brac: Brac.BRK);
    }
  }
}