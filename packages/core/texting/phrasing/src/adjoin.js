import { cosmetics } from '@spare/deco-vector'
import { SP }        from '@spare/enum-chars'

const presetAdjoin = p => {
  p = p ?? {}
  p.delim = p.delim ?? SP
  return p
}

export const adjoin = function (...words) {
  const ve = [], config = presetAdjoin(this)
  for (let word of words)
    if (word?.length)
      ve.push(word)
  return cosmetics.call(config, ve)
}

/**
 *
 * @param {Object} p
 *
 * @param {string} [p.delim=',\n']
 * @param {boolean} [p.bracket=true] - BRK = 1
 * @param {Function} [p.read]
 * @param {Object} [p.preset=FRESH]
 * @param {Object} [p.stringPreset=JUNGLE]
 *
 * @returns {Function}
 */
export const Adjoin = (p = {}) => adjoin.bind(p)
