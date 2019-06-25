using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Data;
using Domain;
namespace GSBGMconsole_APP
{
    class UpdateGameList
    {
        public string JsonResult = "";
        public List<Data.Models.BoardGame> OurBGList = new List<Data.Models.BoardGame>();
        static Repo r = new Repo();
        public void GetAllGames()
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
            Console.WriteLine("Downloading page...");
            Console.ReadLine();
            //Console.WriteLine(JsonResult);
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
                string result = await content.ReadAsStringAsync();
                List<BGGBoardGame> bgglist = new List<BGGBoardGame>();
                bgglist = JsonConvert.DeserializeObject<List<BGGBoardGame>>(result);
                foreach (var i in bgglist)
                {
                    Data.Models.BoardGame newBG = new Data.Models.BoardGame();
                    Console.WriteLine(i.name);
                    if (!r.BoardGameExist(i.name))
                    {
                        newBG.Bgname = i.name;
                        newBG.Mechanics = "Party Game";
                        newBG.MaxPlayerCount = i.maxPlayers;
                        newBG.MinPlayerCount = i.minPlayers;
                        newBG.BggId = i.gameId;
                        newBG.ThumbnailUrl = i.thumbnail;
                        newBG.PlayTime = i.playingTime;
                        newBG.Bggrating = i.bggRating;
                        r.AddBoardGameFromBGG(newBG);
                        Console.WriteLine("Game Added");
                    }
                    else { Console.WriteLine("Game existed"); }
                }
            }
        }
    }
}
