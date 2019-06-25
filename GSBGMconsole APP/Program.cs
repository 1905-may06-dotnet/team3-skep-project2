using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using webapi;
using webapi.Controllers;

namespace GSBGMconsole_APP
{
    static class Program
    {
        static string s = "";
        static void Main(string[] args)
        {
            //UpdateGameList newUpdate = new UpdateGameList();
            //newUpdate.GetAllGames();
            Data.Repo r = new Data.Repo();
            foreach (var i in r.GetALLBoardGames())
            {
                Console.WriteLine(i.BGName);
            }
        }
    }
}
