using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ArkPortalWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ServerController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            string response = string.Empty;

            using(var client = new HttpClient()){
                response = client.GetStringAsync("http://arkservers.net/api/query/74.82.237.253:27015").Result;
            }
           
            return response;
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
