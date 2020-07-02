import { COSP, CO } from '@spare/enum-chars';
import { Cards } from '@palett/cards';
import { hexToRgb } from '@palett/convert';
import { Dye } from '@palett/dye';
import { deNaTab } from '@spare/util';

var id = 0;

function _classPrivateFieldLooseKey(name) {
  return "__private_" + id++ + "_" + name;
}

function _classPrivateFieldLooseBase(receiver, privateKey) {
  if (!Object.prototype.hasOwnProperty.call(receiver, privateKey)) {
    throw new TypeError("attempted to use private field on non-instance");
  }

  return receiver;
}

/**
 *
 * @param {*} [text]
 * @param {number} indent
 * @param {string[]} queue
 * @return {string}
 */
const render = (text, {
  indent,
  queue
}) => {
  if (text === null || text === void 0 ? void 0 : text.length) queue.push(text);
  return ' '.repeat(indent << 1) + queue.join(' ');
};

var _Cards$blueGrey$base, _Cards$orange$lighten, _Cards$indigo$lighten;
const bm = Dye((_Cards$blueGrey$base = Cards.blueGrey.base, hexToRgb(_Cards$blueGrey$base)));
const br = Dye((_Cards$orange$lighten = Cards.orange.lighten_3, hexToRgb(_Cards$orange$lighten)));
const pr = Dye((_Cards$indigo$lighten = Cards.indigo.lighten_1, hexToRgb(_Cards$indigo$lighten)));
const bracket = tx => br('[') + tx + br(']');
const parenthesis = tx => pr('(') + tx + pr(')');

const bracket$1 = tx => '[' + tx + ']';
const parenthesis$1 = tx => '(' + tx + ')';

const toQueue = t => {
  let queue = [],
      l,
      d;

  if (t && (t = String(t)) && (l = t.length) && (d = deNaTab(t)) < l) {
    queue.push(t.slice(d));
  }

  return {
    indent: d,
    queue
  };
};

let _Symbol$toPrimitive;

class Callable extends Function {
  constructor(f) {
    super();
    Reflect.setPrototypeOf(f, new.target.prototype);
    return f;
  }

}
/**
 * @type {Object<string,string>}
 */


var _brk = _classPrivateFieldLooseKey("brk");

var _prn = _classPrivateFieldLooseKey("prn");

_Symbol$toPrimitive = Symbol.toPrimitive;
class Inka extends Callable {
  /** @type {number} */

  /** @type {string[]} */

  /** @type {Function} */

  /** @type {Function} */
  constructor(word, color = true) {
    var _word;

    super(word => render(word, this));
    this.indent = void 0;
    this.queue = void 0;
    Object.defineProperty(this, _brk, {
      writable: true,
      value: void 0
    });
    Object.defineProperty(this, _prn, {
      writable: true,
      value: void 0
    });
    Object.assign(this, (_word = word, toQueue(_word)));
    [_classPrivateFieldLooseBase(this, _brk)[_brk], _classPrivateFieldLooseBase(this, _prn)[_prn]] = color ? [bracket, parenthesis] : [bracket$1, parenthesis$1];
    return new Proxy(this, {
      get(target, p, receiver) {
        var _String;

        if (p in target) {
          return target[p];
        }

        const {
          queue
        } = target;
        queue.push((_String = String(p), _classPrivateFieldLooseBase(target, _brk)[_brk](_String)));
        return (...items) => {
          var _items$map$join;

          return queue.push((_items$map$join = items.map(String).join(COSP), _classPrivateFieldLooseBase(target, _prn)[_prn](_items$map$join))), receiver;
        };
      }

    });
  }

  cr(word) {
    var _word2;

    return Object.assign(this, (_word2 = word, toQueue(_word2))), this;
  }

  asc() {
    return this.indent++, this;
  }

  desc() {
    return this.indent--, this;
  }

  p(...items) {
    return this.queue.push(...items), this;
  }

  br(...items) {
    return this.queue.push(items.map(parenthesis$1).join(CO)), this;
  }

  toString() {
    return render(null, this);
  }

  [_Symbol$toPrimitive](h) {
    switch (h) {
      case 'string':
      case 'default':
        return render(null, this);

      case 'number':
        return this.indent;

      default:
        throw new Error('inka Symbol.toPrimitive error');
    }
  }

}

/**
 *
 * @param {string} [word]
 * @param {boolean} [color]
 * @returns {(Inka|object<string,Inka>)}
 * @constructor
 */

const Xr = (word, color = true) => new Inka(word, color);

const ink = new Inka();

const xr = word => ink.cr(word);

export { Xr, xr };
