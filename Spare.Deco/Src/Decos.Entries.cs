using System;
using System.Collections.Generic;
using System.Linq;
using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting.Enums;
using Texting.Joiner;
using Typen;
using Veho;
using Veho.Sequence;
using Zippers = Veho.Vector.Zippers;

namespace Spare {
  public static class DecoEnt {
    public static string DecoEntries<TK, TV>(
      this IReadOnlyList<(TK key, TV value)> entries,
      byte tab = 1,
      bool hasAnsi = false,
      string delim = Strings.RTSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!entries.Any()) return "[]";
      var (vecA, vecB) = entries.Unwind();
      IReadOnlyList<string>
        textsA = typeof(TK) == typeof(string) ? vecA.Cast<IReadOnlyList<TK>, IReadOnlyList<string>>() : vecA.Map(Conv.ToStr),
        textsB = typeof(TV) == typeof(string) ? vecB.Cast<IReadOnlyList<TV>, IReadOnlyList<string>>() : vecB.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        textsA = textsA.Fluo(presets.Value, effects);
        textsB = textsB.Fluo(presets.Value, effects);
      }
      textsA = textsA.LPadder(hasAnsi);
      textsB = textsB.RPadder(hasAnsi);
      var textEntries = textsA.Zip(textsB, (k, v) => k + delim + v);
      return textEntries.ContingentLines(delim: Strings.COLF, level: tab, Brac.BRK);
    }

    public static string DecoEntries<TA, TB, TC>(
      this IReadOnlyList<(TA x, TB y, TC z)> entries,
      byte tab = 1,
      bool hasAnsi = false,
      string delim = Strings.RTSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!entries.Any()) return "[]";
      var (vecA, vecB, vecC) = entries.Unwind();
      IReadOnlyList<string>
        textsA = typeof(TA) == typeof(string) ? vecA.Cast<IReadOnlyList<TA>, IReadOnlyList<string>>() : vecA.Map(Conv.ToStr),
        textsB = typeof(TB) == typeof(string) ? vecB.Cast<IReadOnlyList<TB>, IReadOnlyList<string>>() : vecB.Map(Conv.ToStr),
        textsC = typeof(TB) == typeof(string) ? vecC.Cast<IReadOnlyList<TC>, IReadOnlyList<string>>() : vecB.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        textsA = textsA.Fluo(presets.Value, effects);
        textsB = textsB.Fluo(presets.Value, effects);
        textsC = textsC.Fluo(presets.Value, effects);
      }
      textsA = textsA.LPadder(hasAnsi);
      textsB = textsB.RPadder(hasAnsi);
      textsC = textsC.RPadder(hasAnsi);

      Func<string, string, string, string> zipper = (x, y, z) => x + delim + y + delim + z;
      var textEntries = Zippers.Zipper(zipper, textsA, textsB, textsC);
      return textEntries.ContingentLines(delim: Strings.COLF, level: tab, Brac.BRK);
    }
  }
}