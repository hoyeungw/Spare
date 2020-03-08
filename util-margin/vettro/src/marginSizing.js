export const marginSizing = (ar, head, tail) => {
  let l, dash = true
  if (!ar || !(l = ar.length)) [head, tail, dash] = [0, 0, false]
  if (!head && !tail || head >= l) [head, tail, dash] = [l, 0, false]
  return { head, tail, dash }
}
