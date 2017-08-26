using System;
using System.IO;
using Moq;
using System.Linq;
using Xunit;
using ArkPortalWebApi.Models;

namespace ArkPortal.Tests
{
    public class Tribe_Test
    {
        private string tribeFile = "artifacts/1889248345.arktribe";

        [Fact]
        public void ParseTribeName_Test()
        {
            using(var reader = new StreamReader(this.tribeFile))
            {
                var content = reader.ReadToEnd();
                var tribe = new Tribe();
                var name = tribe.ParseName(content);
                Assert.Equal(name, "Iron Corsets");
            }
        }

        [Fact]
        public void ParseTribeMembers_Test()
        {
            using(var reader = new StreamReader(this.tribeFile))
            {
                var content = reader.ReadToEnd();
                var tribe = new Tribe();
                var members = tribe.ParseMembers(content);
                Assert.Contains("Rylan", members);
            }
        }

        [Fact]
        public void ParseTribeLog_Test()
        {
            using(var reader = new StreamReader(this.tribeFile))
            {
                var content = reader.ReadToEnd();
                var tribe = new Tribe();
                var log = tribe.ParseTribeLog(content);
                var logLine = log.First();

                Assert.False(logLine.Body == string.Empty);
                Assert.False(logLine.Timestamp == string.Empty);
                Assert.True(logLine.Type.GetType() == typeof(TribeLogType));
            }
        }
    }

}