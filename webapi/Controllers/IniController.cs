using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Domain;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IniController : ControllerBase
    {
        private readonly IRepo db;
        public IniController(IRepo db)
        {
            this.db = db;
        }
        [HttpGet("GetAllGames")]
        public IActionResult GetAllGames()
        {
            try
            {
                return Ok(db.GetALLBoardGames());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("GetAllLocations")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(db.GetAllLocations());
            }
            catch
            {
                return BadRequest();
            }
        }

        //

        public static string JsonResult = "";

        [HttpGet("UpdateBGGGames")]
        public string UpdateBGGGames()
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



    }
}
