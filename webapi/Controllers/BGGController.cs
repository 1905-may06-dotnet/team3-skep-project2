using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BGGController : ControllerBase
    {
        public static string JsonResult = "";
        // GET: api/BGG
        // this method fetches all our boardgames from bggweb
        [HttpGet]
        public string GetAllGames()
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
            return JsonResult;
        }
        static async void DownloadPageAsync()
        {
            // ... Endpoint
            string page = "https://bgg-json.azurewebsites.net/collection/teamskep?grouped=true";
            // ... Use HttpClient.
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                // ... Read the string.
                JsonResult = await content.ReadAsStringAsync();
            }
        }
        // GET: api/BGG/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BGG
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/BGG/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
