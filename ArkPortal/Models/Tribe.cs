using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ArkPortalWebApi.Models
{
    public class Tribe
    {
        private char[] commandChars = new char[] {(char)0,(char)1,(char)2,(char)3,(char)4,(char)5,(char)6,(char)7,(char)8,(char)9,(char)10,(char)11,(char)12,(char)13,(char)14,(char)15,(char)16,(char)17,(char)18,(char)19,(char)20,(char)21,(char)32};
        
        public string Name { get; set; }
        public IEnumerable<string> Members { get; set; }

        public IEnumerable<TribeLogLine> Log { get; set; }

        // Allow an empty instance be created for testing - methods should probably just be static instead.
        public Tribe()
        {

        }

        public Tribe(string fileName)
        {
            using(StreamReader reader = new StreamReader(fileName)){
                var tribeContent = reader.ReadToEnd();
                this.Name = ParseName(tribeContent);
                this.Members = ParseMembers(tribeContent);
                this.Log = ParseTribeLog(tribeContent);
            }
        }

        public string ParseName(string tribeContent)
        {
            string tribeName = tribeContent.Substring((tribeContent.IndexOf("TribeName")+38), (tribeContent.IndexOf("OwnerPlayerDataID")-5)-(tribeContent.IndexOf("TribeName")+38));
            return tribeName;
        }

        public string[] ParseMembers(string tribeContent)
        {
            return tribeContent.Substring(tribeContent.IndexOf("MembersPlayerName")+68,tribeContent.IndexOf("MembersPlayerDataID")-(tribeContent.IndexOf("MembersPlayerName")+68)).Split((char)0);
        }

        public IEnumerable<TribeLogLine> ParseTribeLog(string tribeContent)
        {
            var list = new List<TribeLogLine>();
            IEnumerable<string> lines = tribeContent.Substring(tribeContent.IndexOf("TribeLog")+51).Split((char)0).Where( v => v != string.Empty && v.StartsWith("Day"));

            foreach(var line in lines)
            {
                System.Diagnostics.Debug.WriteLine(line);
                //(\w{3}\s\d+,\s\d{2}:?\d{2}:\d{2}):\s(<\w+\s\w+="\d,\s\d,\s\d,\s\d">)?([\w\s-\(\)'\!]+)
                var todPattern = "(\\w{3}\\s\\d+,\\s\\d{2}:?\\d{2}:\\d{2}):\\s(<\\w+\\s\\w+=\"\\d[\\.\\d+]*,\\s\\d[\\.\\d+]*,\\s\\d[\\.\\d+]*,\\s\\d[\\.\\d+]*\">)?([\\w\\s-\\(\\)'\\!]+)";
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