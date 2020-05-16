import { LITERAL, INILOW, CAPWORD } from '@spare/regex-phrasing';
import { Ripper } from '@spare/ripper';

const splitter = (text, reg) => {
  let ms,
      l = 0,
      r = 0,
      sp,
      ph;
  const vec = [];

  while ((ms = reg.exec(text)) && ([ph] = ms)) {
    r = ms.index;
    if (sp = text.slice(l, r)) vec.push(sp);
    vec.push(ph);
    l = reg.lastIndex;
  }

  if (l < text.length) vec.push(text.slice(l));
  return vec;
};

/** @type {Function|function(string):string[]} */

const splitLiteral = Ripper(LITERAL);

/**
 * Camel/pascal case phrase -> split vector
 * Snake: fox_jumps_over_dog
 * Kebab: fox-jumps-over-dog
 * @param {string} phrase camel/pascal-case phrase
 * @returns {string[]}
 */

function splitCamel(phrase) {
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
const splitSnake = phrase => phrase.split(/\W/g);

export { splitCamel, splitLiteral, splitSnake, splitter };
