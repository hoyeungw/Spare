import { fluoMatrix }           from '@palett/fluo-matrix'
import { bracket as doBracket } from '@spare/bracket'
import { COLF }                 from '@spare/enum-chars'
import { liner }                from '@spare/liner'
import { mattro }               from '@spare/mattro'
import { padMatrix }            from '@spare/pad-matrix'
import { Qt }                   from '@spare/quote'
import { size }                 from '@vect/matrix'

export const cosmetics = function (matrix) {
  if (!matrix) return String(matrix)
  const [height, width] = size(matrix)
  if (!height || !width) return liner([], this)
  const { direct, preset, stringPreset, quote, ansi, discrete, delim, bracket, level } = this
  const { top, bottom, left, right, dashX, dashY, read } = this
  const { raw, text } = mattro(
    matrix,
    { top, bottom, left, right, height, width, dashX, dashY, read: Qt(read, quote) }
  )
  const dye = preset && fluoMatrix(raw, { direct, preset, stringPreset, colorant: true })
  const rows = padMatrix(text, { raw, dye, ansi })
  const lines = bracket
    ? rows.map(line => line.join(delim) |> doBracket)
    : rows.map(line => line.join(delim))
  return liner(lines, { discrete, delim: COLF, bracket, level })
}

