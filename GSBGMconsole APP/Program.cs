﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
//using Newtonsoft.Json;
using webapi;
using webapi.Controllers;

namespace GSBGMconsole_APP
{
    static class Program
    {
        static string s = "";
        static void Main(string[] args)
        {
<<<<<<< HEAD
            //UpdateGameList newUpdate = new UpdateGameList();
            //newUpdate.GetAllGames();
            Data.Repo r = new Data.Repo();
            foreach (var i in r.GetALLBoardGames())
            {
                Console.WriteLine(i.BGName);
            }



            //Client c = new Client();
            //c.RunAPP();
=======
            //Guid u = Guid.NewGuid();
            //Console.WriteLine(u);
            Client c = new Client();
            c.RunAPP();
>>>>>>> 57bed7b39a395abe3f7b4b2634716effa3f61024
            //c.UserActivity("evanh");
            
            //Data.Repo r = new Data.Repo();
            //Console.WriteLine( r.UsernameExist("test1") ); 
            //int count = r.GetUserByUserName("evanh").HasFriends.Count;
            //Console.WriteLine(count);
            //r.GetUserByUserName("evanh").HasFriends.Add(r.GetFriendByFID(2));
            //r.GetUserByUserName("kevin").IsFriendTo.Add(r.GetFriendByFID(2));
            //int countafter = r.GetUserByUserName("evanh").HasFriends.Count;
            //Console.WriteLine(countafter);

            //if (false)
            //{
            //    Console.WriteLine("some m");
            //}

            //===================================================fetch json and convert json to objects==========
            //Task t = new Task(DownloadPageAsync);
            //t.Start();
            //Console.WriteLine("Downloading page...");
            //Console.WriteLine(s);
            //Console.ReadLine();


            //===================================================fetch json and convert json to objects==========

        }
        ////===================================================fetch json and convert json to objects==========
        //static async void DownloadPageAsync()
        //{
        //    // ... Endpoint
        //    string page = "https://bgg-json.azurewebsites.net/collection/teamskep?grouped=true";
        //    // ... Use HttpClient.
        //    using (HttpClient client = new HttpClient())
        //    using (HttpResponseMessage response = await client.GetAsync(page))
        //    using (HttpContent content = response.Content)
        //    {
        //        // ... Read the string.
        //        string result = await content.ReadAsStringAsync();
        //        List<BGGBoardGame> bgglist = new List<BGGBoardGame>();
        //        bgglist = JsonConvert.DeserializeObject<List<BGGBoardGame>>(result);
        //        foreach (var i in bgglist)
        //        {
        //            Console.WriteLine(i.gameId);
        //        }
        //        s = result;
        //    }
        //}
        ////===================================================fetch json and convert json to objects==========

    }
}
