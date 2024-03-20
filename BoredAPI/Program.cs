using System;
using System.Net.Http;
using System.Threading.Tasks;

using chessStrapiAPI.Model;
using Newtonsoft.Json;


namespace chessStrapiAPI
{
    class Program
    {
        private const string OpeningList = "http://localhost:1337/api/openings";
        private const string Opening = "http://localhost:1337/api/openings/";
        private const string PlayerList = "http://localhost:1337/api/players?populate=openings";
        private const string Player = "http://localhost:1337/api/players/";

        private static HttpClient client;

        static async Task<string> GetDataAsync(string request)
        {
            var data = string.Empty;

            var response = await client.GetAsync(request);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }

        static void Main(string[] args)
        {

            Console.WriteLine("BORED API CLI [version 0.1]");
            client = new HttpClient();
            
            while (true)
            {
                Console.Write("openings : list all openings\n" +
                    "opening x : retrieve data about opening number x\n" +
                    "players : list all players\n" +
                    "player x : retrieve data about player number x\n");
                args = Console.ReadLine().Split(' ');
                var command = args[0];
                switch (command)
                {
                    case "openings":
                        string response = GetDataAsync(OpeningList).GetAwaiter().GetResult();
                        var openingList = JsonConvert.DeserializeObject<OpeningList>(response);
                        openingList.DisplayInfo();
                        break;
                    case "opening":
                        var key = args[1];
                        string request = String.Concat(Opening, key.ToString());
                        string response2 = GetDataAsync(request).GetAwaiter().GetResult();
                        var openingWrapper = JsonConvert.DeserializeObject<OpeningWrapper>(response2);

                        openingWrapper.Data.DisplayInfo();
                        break;
                    case "players":
                        string response3 = GetDataAsync(PlayerList).GetAwaiter().GetResult();
                        var playerList = JsonConvert.DeserializeObject<PlayerList>(response3);
                        playerList.DisplayInfo();
                        break;
                    case "player":
                        var key2 = args[1];
                        string request2 = String.Concat(Player, key2.ToString());
                        string response4 = GetDataAsync(request2).GetAwaiter().GetResult();
                        var playerWrapper = JsonConvert.DeserializeObject<PlayerWrapper>(response4);

                        playerWrapper.Data.DisplayInfo();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
