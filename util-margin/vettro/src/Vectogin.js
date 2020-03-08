import { totx } from '@spare/util'
import { marginCopy, marginMapper, marginMutate } from '@vect/vector-margin'
import { marginSizing } from './marginSizing'

export class Vectogin {
  constructor (vec, head, tail, dash) {
    this.vec = vec
    this.head = head
    this.tail = tail
    this.dash = dash
  }

  static build (ar, h = 0, t = 0) {
    const { head, tail, dash } = marginSizing(ar, h, t)
    const cutVec = marginCopy(ar, head, tail)
    return new Vectogin(cutVec, head, tail, dash)
  }

  map (fn, mutate = false) {
    const { vec, head, tail } = this
    return mutate
      ? this.reboot(marginMutate(vec, fn, head, tail))
      : this.clone(marginMapper(vec, fn, head, tail))
  }

  stringify (fn, mutate = true) { return this.map(fn ? (_ => String(fn(_))) : totx, mutate) }

  toVector (el) {
    const { vec, head, tail } = this,
      dif = vec.length - (head + tail),
      ar = vec.slice()
    this.dash && el
      ? ar.splice(head, dif, el)
      : ar.splice(head, dif)
    return ar
  }

  reboot (ar) {
    if (ar) this.vec = ar
    return this
  }

  clone (ar) { return new Vectogin(ar, this.head, this.tail, this.dash) }
}
