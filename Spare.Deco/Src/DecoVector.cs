using System.Linq;
using Palett.Fluos;
using Palett.Types;
using Texting.Enums;
using Texting.Joiner;
using Typen;
using Veho.Vector;
using static Texting.Enums.Strings;

namespace Spare {
  public static partial class Decos {
    public static string Deco<T>(
      this T[] vector,
      string delim = COSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!vector.Any()) return "[]";
      var textVector = typeof(T) == typeof(string) ? vector.Cast<T[], string[]>() : vector.Map(Conv.ToStr);
      if (presets != null) textVector = textVector.Fluo(presets.Value, effects);
      return textVector.ContingentLines(delim, brac: Brac.BRK);
    }
  }
}