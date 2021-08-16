// using System.Collections.Generic;
// using Palett.Types;
// using Typen;
// using Veho.Mutable.Matrix;
// using Veho.Mutable;
// using Veho.Types;
//
// namespace Spare {
//   public static partial class Decos {
//     public static string Deco<T>(
//       this List<List<T>> matrix,
//       byte tab = 1,
//       bool hasAnsi = false,
//       Operated orient = Operated.Rowwise,
//       (Preset, Preset)? presets = null,
//       params Effect[] effects
//     ) {
//       if (!matrix.Any()) return "[]";
//       var textMatrix = matrix.Map(Conv.ToStr);
//       if (presets != null && (hasAnsi = true)) {
//         textMatrix = textMatrix.Fluo(orient, presets.Value, effects);
//       }
//       return textMatrix.Padder(hasAnsi)
//                        .MapRows(row => row.Join(COSP))
//                        .ContingentLines(delim: COLF, level: tab);
//     }
//   }
// }