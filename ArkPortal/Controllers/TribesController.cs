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
            var tribe = new Tribe("Z:/1889248345.arktribe");
            return new Tribe[] { tribe };
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
