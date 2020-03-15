import { CAPWORD, INILOW, WORD } from '../resources/regexes'
import { wordToCap } from './wordToCap'

/**
 * Camel/pascal case phrase -> Lowercase dashed phrase, snake or kebab.
 * Snake: fox_jumps_over_dog
 * Kebab: fox-jumps-over-dog
 * @example 'TheCyberPunk2077Cdpr' -> 'the-cyber-punk-2077nd-cdpr'
 * @param {string} phrase camel/pascal-case phrase
 * @param {string} de
 * @returns {string} lowercase dashed phrase
 */
export function camelToSnake (phrase, de = '-') {
  let ms, wd, ph = ''
  if (((ms = INILOW.exec(phrase)) || (ms = CAPWORD.exec(phrase))) && ([wd] = ms)) ph = wd.toLowerCase()
  while ((ms = CAPWORD.exec(phrase)) && ([wd] = ms)) ph += de + wd.toLowerCase()
  return ph
}

/**
 * snake or kebab phrase -> camel-case phrase
 * @example 'THE_CYBER-PUNK.2077 cdpr' -> 'theCyberPunk2077Cdpr'
 * @param {string} dashed dashed phrase
 * @param {string} de
 * @returns {string} camel phrase
 */
export const snakeToCamel = (dashed, de = '') => {
  let ms, wd, ph = ''
  if ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph = wd.toLowerCase()
  while ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph += de + wordToCap(wd)
  return ph
}

/**
 * snake/kebab phrase -> pascal-case phrase
 * @example 'THE_CYBER-PUNK.2077 cdpr' -> 'TheCyberPunk2077Cdpr'
 * @param {string} dashed dashed phrase
 * @param {string} de
 * @returns {string} camel phrase
 */
export const snakeToPascal = (dashed, de = '') => {
  let ms, wd, ph = ''
  if ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph = wordToCap(wd)
  while ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph += de + wordToCap(wd)
  return ph
}
