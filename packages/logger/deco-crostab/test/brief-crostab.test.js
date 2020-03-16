import { Foba } from '@foba/crostab'
import { delogger } from '@spare/deco'
import { logger } from '@spare/logger'
import { POINTWISE } from '@vect/enum-matrix-directions'
import { Mag } from '@cliche/mag'
import { isNumeric } from '@typen/num-strict'
import { OCEAN } from '@palett/presets'
import { Deco } from '../index'

const mag = new Mag(0)

const crostab = Foba.flop()
crostab |> delogger

crostab |> Deco({
  direct: POINTWISE,
  labelPreset: OCEAN,
  abstract: x => isNumeric(x) ? mag.format(x) : NaN,
  top: 4, bottom: 3, left: 3, right: 2
}) |> logger


