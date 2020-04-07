'use strict';

Object.defineProperty(exports, '__esModule', { value: true });

var vectorMapper = require('@vect/vector-mapper');
var enumChars = require('@spare/enum-chars');
var decoVector = require('@spare/deco-vector');

const INIWORD = /[A-Za-z\d]+/;
const INILOW = /^[a-z]+/;
const CAMEL = /[A-Z]+|[0-9]+/g;
const WORD = /[A-Za-z\d]+/g;
const CAPWORD = /([A-Z][a-z]+|[A-Z]+|[\d]+[a-z]*)/g;
const DASH_CAPREST = /[\W_]+([A-Za-z\d])([A-Za-z\d]*)/g;
const CAPREST = /([A-Za-z\d])([A-Za-z\d]*)/g;

const wordToCap = word => word[0].toUpperCase() + word.substring(1).toLowerCase();

/**
 * Camel/pascal case phrase -> Lowercase dashed phrase, snake or kebab.
 * Snake: fox_jumps_over_dog
 * Kebab: fox-jumps-over-dog
 * @example 'TheCyberPunk2077Cdpr' -> 'the-cyber-punk-2077nd-cdpr'
 * @param {string} phrase camel/pascal-case phrase
 * @param {string} de
 * @returns {string} lowercase dashed phrase
 */

function camelToSnake(phrase, de = '-') {
  let ms,
      wd,
      ph = '';
  if (((ms = INILOW.exec(phrase)) || (ms = CAPWORD.exec(phrase))) && ([wd] = ms)) ph = wd.toLowerCase();

  while ((ms = CAPWORD.exec(phrase)) && ([wd] = ms)) ph += de + wd.toLowerCase();

  return ph;
}
/**
 * snake or kebab phrase -> camel-case phrase
 * @example 'THE_CYBER-PUNK.2077 cdpr' -> 'theCyberPunk2077Cdpr'
 * @param {string} dashed dashed phrase
 * @param {string} de
 * @returns {string} camel phrase
 */

const snakeToCamel = (dashed, de = '') => {
  let ms,
      wd,
      ph = '';
  if ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph = wd.toLowerCase();

  while ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph += de + wordToCap(wd);

  return ph;
};
/**
 * snake/kebab phrase -> pascal-case phrase
 * @example 'THE_CYBER-PUNK.2077 cdpr' -> 'TheCyberPunk2077Cdpr'
 * @param {string} dashed dashed phrase
 * @param {string} de
 * @returns {string} camel phrase
 */

const snakeToPascal = (dashed, de = '') => {
  let ms,
      wd,
      ph = '';
  if ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph = wordToCap(wd);

  while ((ms = WORD.exec(dashed)) && ([wd] = ms)) ph += de + wordToCap(wd);

  return ph;
};

const wordsToCamel = words => {
  let i = 0,
      l = words === null || words === void 0 ? void 0 : words.length;
  if (l) words[i] = words[i].toLowerCase();

  while (++i < l) words[i] = wordToCap(words[i]);

  return words;
};
const wordsToPascal = words => vectorMapper.mutate(words, wordToCap);

/**
 * Camel/pascal case phrase -> split vector
 * Snake: fox_jumps_over_dog
 * Kebab: fox-jumps-over-dog
 * @param {string} phrase camel/pascal-case phrase
 * @returns {string[]}
 */

function camelToVector(phrase) {
  let ms,
      wd,
      ve = [];
  if ((ms = INILOW.exec(phrase)) && ([wd] = ms)) ve.push(wd);

  while ((ms = CAPWORD.exec(phrase)) && ([wd] = ms)) ve.push(wd);

  return ve;
}
/**
 * snake or kebab phrase -> split vector
 * @param {string} phrase - dashed phrase
 * @returns {string[]}
 */

const snakeToVector = phrase => phrase.split(/\W/g);

const presetAdjoin = p => {
  var _p, _p$delim;

  p = (_p = p) !== null && _p !== void 0 ? _p : {};
  p.delim = (_p$delim = p.delim) !== null && _p$delim !== void 0 ? _p$delim : enumChars.SP;
  return p;
};

const adjoin = function (...words) {
  const ve = [],
        config = presetAdjoin(this);

  for (let word of words) if (word === null || word === void 0 ? void 0 : word.length) ve.push(word);

  return decoVector.cosmetics.call(config, ve);
};
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

const Adjoin = (p = {}) => adjoin.bind(p);

exports.Adjoin = Adjoin;
exports.CAMEL = CAMEL;
exports.CAPREST = CAPREST;
exports.CAPWORD = CAPWORD;
exports.DASH_CAPREST = DASH_CAPREST;
exports.INILOW = INILOW;
exports.INIWORD = INIWORD;
exports.WORD = WORD;
exports.adjoin = adjoin;
exports.camelToSnake = camelToSnake;
exports.camelToVector = camelToVector;
exports.snakeToCamel = snakeToCamel;
exports.snakeToPascal = snakeToPascal;
exports.snakeToVector = snakeToVector;
exports.wordToCap = wordToCap;
exports.wordsToCamel = wordsToCamel;
exports.wordsToPascal = wordsToPascal;
