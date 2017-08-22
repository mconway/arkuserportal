using System.Collections.Generic;

namespace ArkPortalWebApi.Models
{
    public enum TribeLogType { Normal, Alert, Death }
    public class TribeLogLine
    {
        public string Timestamp { get; set; }
        public TribeLogType Type { get; set; }

        public string Body { get; set; }
    }
}