using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        //GET: api/BGG
        //this method fetches all our boardgames from bggweb
        [HttpGet("GetAllGames")]
        public string GetAllGames()
        {
            Console.WriteLine("==================started======================================");
            try
            {
                Task t = new Task(DownloadPageAsync);
                t.Start();
            }
            catch { }
            Console.WriteLine("==================end======================================");
            return JsonResult;
            //return new HttpResponseMessage()
            //{                
            //    Content = new StringContent(
            //    JsonResult,
            //    Encoding.UTF8,
            //    "text/html"
            //)
            //};
        }
        static async void DownloadPageAsync()
        {
            // ... Endpoint
           
            string page = "https://bgg-json.azurewebsites.net/collection/teamskep?grouped=true";
            // ... Use HttpClient.
            try
            {
                using (HttpClient client = new HttpClient())
                using (HttpResponseMessage response = await client.GetAsync(page))
                using (HttpContent content = response.Content)
                {
                    // ... Read the string.
                    JsonResult = await content.ReadAsStringAsync();
                }
            }
            catch { }
            Console.WriteLine(JsonResult);
        }
        //[HttpGet("Get")]
        //public async Task < HttpResponseMessage > Get()
        //{
        //    string page = "https://bgg-json.azurewebsites.net/collection/teamskep?grouped=true";
        //    // ... Use HttpClient.
        //    using (HttpClient client = new HttpClient())
        //    using (HttpResponseMessage response = await client.GetAsync(page))
        //    using (HttpContent content = response.Content)
        //    {
        //        // ... Read the string.
        //        JsonResult = await content.ReadAsStringAsync();
        //    }
        //    return new HttpResponseMessage()
        //    {
        //        Content = new StringContent(
        //            JsonResult,
        //            Encoding.UTF8,
        //            "application/json"
        //        )
        //    };
        //}

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
