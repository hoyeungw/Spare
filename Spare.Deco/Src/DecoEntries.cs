using System.Collections.Generic;
using System.Linq;
using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting.Enums;
using Texting.Joiner;
using Typen;
using Veho;
using Veho.Vector;

namespace Spare {
  public static class DecoEnt {
    public static string DecoEntries<TK, TV>(
      this (TK key, TV value)[] entries,
      byte tab = 1,
      bool hasAnsi = false,
      string delim = Strings.RTSP,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!entries.Any()) return "[]";
      var (keys, values) = entries.Unwind();
      string[]
        textKeys = keys.Map(Conv.ToStr),
        textValues = values.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        textKeys = textKeys.Fluo(presets.Value, effects);
        textValues = textValues.Fluo(presets.Value, effects);
      }
      textKeys = textKeys.LPadder(hasAnsi);
      textValues = textValues.RPadder(hasAnsi);

      var textEntries = textKeys.Zip(textValues, (k, v) => k + delim + v);
      return textEntries.ContingentLines(delim: Strings.COLF, level: tab, Brac.BRK);
    }
  }
}