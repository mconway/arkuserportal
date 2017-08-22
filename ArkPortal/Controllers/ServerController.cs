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
    public class ServerController : Controller
    {
        private IWebApiClient client;
        public ServerController(IWebApiClient client)
        {
            this.client = client;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return this.client.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
