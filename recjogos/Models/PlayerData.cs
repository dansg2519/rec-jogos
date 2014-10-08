using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace RecGames
{
    class PlayerData
    {
        Player player = new Player();


        public void getPlayerSummary()
        {
            using (WebClient client = new WebClient())
            {
                string steam_key = "3E2BA9478DC190757ABE4D1DABEA9802";
                string steam_id = "76561197960435530";
                string playerDetails = client.DownloadString(@"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key=" + steam_key + "&steamids=" + steam_id);
                player = JsonConvert.DeserializeObject<Player>(playerDetails);

                string ownedGameDetails = client.DownloadString(@"http://api.steampowered.com/IPlayerService/GetOwnedGames/v0001/?key=" + steam_key + "&steamids=" + steam_id + "&format=json");
                //player.ownedGames = JsonConvert.DeserializeObject<int, int>(playerDetails);
            }
        }
    }
}
