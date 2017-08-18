using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ArkPortalWebApi.Models
{
    public class Tribe
    {
        public string Name { get; set; }
        public IEnumerable<string> Members { get; set; }

        public IEnumerable<TribeLogLine> Log { get; set; }

        public IEnumerable<TribeLogLine> ParseTribeLog(IEnumerable<string> lines)
        {
            var list = new List<TribeLogLine>();

            foreach(var line in lines)
            {
                System.Diagnostics.Debug.WriteLine(line);
                var todPattern = "(\\w{3}\\s\\d+,\\s\\d{2}:?\\d{2}:\\d{2}):\\s(<\\w+\\s\\w+=\"\\d,\\s\\d,\\s\\d,\\s\\d\">)?([\\w\\s-\\(\\)'\\!]+)";
                var r = new Regex(todPattern, RegexOptions.IgnoreCase|RegexOptions.Multiline);
                var match = r.Match(line);
                var type = TribeLogType.Normal;
                if(match.Groups[2].Value.Contains("1, 1, 0"))
                {
                    type = TribeLogType.Alert;
                }
                else if(match.Groups[2].Value.Contains("1, 0, 0"))
                {
                    type = TribeLogType.Death;
                }
                list.Add(new TribeLogLine() { Timestamp = match.Groups[1].Value, Body = match.Groups[3].Value, Type = type });
            }

            list.Reverse();

            return list;
        }
    }
}