using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace SteamCNHelper
{
    class Extractor
    {
        const string QualifierMatcher = @"((?<q>￥|¥)(?<p>(\d|\.)+)|((?<p>(\d|\.)+)|(?<c>(一|二|两|三|四|五|六|七|八|九|⑨|十)+))(?<q>\s*(腿|鸡腿|元|角|毛|CNY|rmb|RMB|Rmb|软|软妹)))";
        public static bool ConvertPrice(Match match, out float result)
        {
            bool success = false;
            float multiplier = 1f, value = 0f;
            if (match.Groups["q"].Value == "角" || match.Groups["q"].Value == "毛") multiplier = 0.1f;
            if (match.Groups["p"].Value != "")
            {
                success = float.TryParse(match.Groups["p"].Value, out value);
                if (!success)
                {
                    result = 0f;
                    return false;
                }
            }
            else if (match.Groups["c"].Value != "")
            {
                string str = match.Groups["c"].Value;
                success = true;
                float based = 0f;
                if (str.Length == 2 && str[0] == '十')
                {
                    based += 10f;
                    str = str.Substring(1);
                }
                else if (str.Length == 2 && str[1] == '十')
                {
                    multiplier *= 10f;
                    str = str.Substring(0, 1);
                }
                switch (str)
                {
                    case "一": value = 1f; break;
                    case "二": value = 2f; break;
                    case "两": value = 2f; break;
                    case "三": value = 3f; break;
                    case "四": value = 4f; break;
                    case "五": value = 5f; break;
                    case "六": value = 6f; break;
                    case "七": value = 7f; break;
                    case "八": value = 8f; break;
                    case "九": value = 9f; break;
                    case "⑨": value = 9f; break;
                    case "十": value = 10f; break;
                    default: success = false; break;
                }
                if (!success)
                {
                    result = 0f;
                    return false;
                }
                value += based;
            }
            result = multiplier * value;
            return true;
        }
        public static bool IsPriceContext(string str, out float result)
        {
            Match match, matchSpecial;
            // match = Regex.Match(str, @"(?<=每个)(\d|\.)+|(?<=每个￥)(\d|\.)+");
            match = Regex.Match(str, 
                @"(?<=每个|一个|以下)" + QualifierMatcher + @"|" +
                QualifierMatcher + @"(一个|区|key|散key|:[^\w]*$|：[^\w]*$)|" +
                @"^[^\w]*" + QualifierMatcher + @"[^\w]*$");
            matchSpecial = Regex.Match(str, @"(?<s>打包|结贴|出完|结束|已出)");
            if (match.Success)
            {
                bool success = ConvertPrice(match, out result);
                if (success)
                {
                    Console.WriteLine("检测到价格上下文" + Environment.NewLine +
                        "数值：" + match.Groups["p"].Value + Environment.NewLine +
                        "中文：" + match.Groups["c"].Value + Environment.NewLine +
                        "单位：" + match.Groups["q"].Value + Environment.NewLine +
                        "结算：" + result.ToString());
                    return true;
                }
                return false;
            }
            result = 0f;
            return false;
        }
        public static float GetSellingItemPrice(string str, float context)
        {
            float result;
            Match match, matchSpecial;
            string inlineQualiferMatcher = @"(" + QualifierMatcher + @"|(?<p>(\d|\.)+)[^\w]*$)";
            //match = Regex.Match(str, @"(?<=每个)(\d|\.)+|(?<=每个￥)(\d|\.)+");
            match = Regex.Match(str, inlineQualiferMatcher);
            matchSpecial = Regex.Match(str, @"(?<s>打包|结贴|出完|结束|已出)");
            if (match.Success)
            {
                bool success = ConvertPrice(match, out result);
                if (success)
                {
                    return result;
                }
            }
            return context;

        }
    }
}
