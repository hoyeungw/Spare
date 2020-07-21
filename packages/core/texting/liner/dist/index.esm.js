import { br } from '@spare/bracket';
import { NONE } from '@spare/enum-brackets';
import { TB, LF, CO } from '@spare/enum-chars';

const joinLines = (lines, de = '', lv, hover = true) => {
  const IND = lv > 0 ? TB.repeat(lv) : '',
        LFI = LF + IND;
  return hover ? `${LFI + TB}${lines.join(de + LFI + TB)}${de + LFI}` : `${IND + TB}${lines.join(de + LFI + TB)}${de}`;
};
const LINEFEED = /\n/;
const COMMA = /,/;
const liner = (lines, {
  discrete = false,
  delim = LF,
  bracket = NONE,
  level = 0
} = {}) => {
  if (discrete) return lines;
  const hover = !!bracket;
  const joined = lines.length && LINEFEED.test(delim) ? joinLines(lines, COMMA.test(delim) ? CO : '', level, hover) : lines.join(delim);
  return br(joined, bracket);
};

export { joinLines, liner };
