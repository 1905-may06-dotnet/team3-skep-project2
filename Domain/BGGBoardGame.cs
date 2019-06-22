using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [JsonObject]
    public class BGGBoardGame
    {
            public int gameId { get; set; }
            public string name { get; set; }
            public string image { get; set; }
            public string thumbnail { get; set; }
            public int minPlayers { get; set; }
            public int maxPlayers { get; set; }
            public int playingTime { get; set; }
            public bool isExpansion { get; set; }
            public int yearPublished { get; set; }
            public float bggRating { get; set; }
            public float averageRating { get; set; }
            public int rank { get; set; }
            public int numPlays { get; set; }
            public float rating { get; set; }
            public bool owned { get; set; }
            public bool preOrdered { get; set; }
            public bool forTrade { get; set; }
            public bool previousOwned { get; set; }
            public bool want { get; set; }
            public bool wantToPlay { get; set; }
            public bool wantToBuy { get; set; }
            public bool wishList { get; set; }
            public string userComment { get; set; }

    }
}
