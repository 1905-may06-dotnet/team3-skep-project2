using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Domain;
using webapi;
using webapi.Controllers;
using RestSharp;
using RestSharp.Authenticators;

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
            //foreach (var i in r.GetALLBoardGames())
            //{
            //    Console.WriteLine(i.BGName);
            //}
            //string a = "evan";
            //string b = "kevin";
            //string c = "liv+";
            //    Console.WriteLine(SendSimpleMessage(a,b,c).Content.ToString());
            Domain.UserCollection c = new UserCollection();
            c.Uid = 8;
            c.Gid = 1;
            Console.WriteLine("result: "+r.CheckGameExistedInCollection(c));
            //foreach (var u in r.GetUserByLocation(1))
            //{
            //    Console.WriteLine(u.Username);
            //    Console.WriteLine("something");
            //}

        }
        public static IRestResponse SendSimpleMessage(string a, string b, string c)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3");
            client.Authenticator =
                new HttpBasicAuthenticator("api",
                                            "49d580152859b132a138a91a1418aa43-2b778fc3-24fa546d");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandboxd3b07b7021e44d4d86a10aec3eaa29c4.mailgun.org", ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", "Excited User <mailgun@sandboxd3b07b7021e44d4d86a10aec3eaa29c4.mailgun.org>");
            request.AddParameter("to", "team.skep4@gmail.com");
            request.AddParameter("to", "YOU@YOUR_DOMAIN_NAME");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", $"{a} receive a request from {b} in {c}!");
            request.Method = Method.POST;
            return client.Execute(request);
        }
    }
}
