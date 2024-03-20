using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace chessStrapiAPI.Model
{
    public class PlayerAttributes
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Birthdate { get; set; }
        public string Biography { get; set; }
        public OpeningsContainer Openings { get; set; }

    }
    public class OpeningsContainer
    {
        public List<Opening> Data { get; set; }
    }

    public class PlayerWrapper
    {
        public Player Data { get; set; }
    }

    // Modèle pour un joueur individuel
    public class Player
    {
        public int Id { get; set; }

        public PlayerAttributes Attributes { get; set; }

        public void DisplayInfo(bool includeDescription = true)
        {
            Console.WriteLine($"ID : {Id}, Lastname : {Attributes.Lastname}, Firstname : {Attributes.Firstname}, Birthdate : {Attributes.Birthdate}");
            Console.WriteLine(includeDescription ? $"Biography : {Attributes.Biography}" : "");
            if (Attributes.Openings?.Data != null)
            {
                Console.WriteLine("Related Openings : ");
                foreach (var opening in Attributes.Openings.Data)
                {
                    Console.WriteLine($"- {opening.Attributes.Name}");
                }
            }
        }
    }

    // Modèle pour la liste des joueurs
    public class PlayerList
        {
            public List<Player> Data { get; set; } = new List<Player>();
            public void DisplayInfo()
            {
                foreach (var player in Data)
                {
                    player.DisplayInfo(false);
                }
            }
        }
    }


