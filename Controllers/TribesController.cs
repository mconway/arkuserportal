using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArkPortalWebApi.Models;

namespace ArkPortalWebApi.Controllers
{
    [Route("api/[controller]")]
    public class TribesController : Controller
    {
        // GET api/values
        [HttpGet]
        public Tribe[] Get()
        {
            using(StreamReader reader = new StreamReader("Z:\\1889248345.arktribe")){
                char[] commandChars = new char[] {(char)0,(char)1,(char)2,(char)3,(char)4,(char)5,(char)6,(char)7,(char)8,(char)9,(char)10,(char)11,(char)12,(char)13,(char)14,(char)15,(char)16,(char)17,(char)18,(char)19,(char)20,(char)21,(char)32};
                string tribeContent = reader.ReadToEnd();
                string tribeName = tribeContent.Substring((tribeContent.IndexOf("TribeName")+38), (tribeContent.IndexOf("OwnerPlayerDataID")-5)-(tribeContent.IndexOf("TribeName")+38));
                var rawMembers =  tribeContent.Substring(tribeContent.IndexOf("MembersPlayerName")+68,tribeContent.IndexOf("MembersPlayerDataID")-(tribeContent.IndexOf("MembersPlayerName")+68)).Split((char)0);

                var tribeLog = tribeContent.Substring(tribeContent.IndexOf("TribeLog")+51).Split((char)0).Where( v => v != string.Empty && v.StartsWith("Day"));

                var tribe = new Tribe() { Name = tribeName, Members = rawMembers };
                tribe.Log = tribe.ParseTribeLog(tribeLog);

                return new Tribe[] { tribe };
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
