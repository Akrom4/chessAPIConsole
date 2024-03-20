using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace chessStrapiAPI.Model
{
    public class OpeningAttributes
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
    }

    public class OpeningWrapper
    {
        public Opening Data { get; set; }
    }

    // Modèle pour une ouverture individuelle
    public class Opening
    {
        public int Id { get; set; }

        public OpeningAttributes Attributes { get; set; }

        public void DisplayInfo(bool includeDescription = true)
        {
            // Access the OpeningAttributes directly
            Console.WriteLine($"ID: {Id}, Name: {Attributes.Name}, Link: {Attributes.Link}");
            Console.WriteLine(includeDescription ? $"Description: {Attributes.Description}\n" : "\n");
        }
    }



    // Modèle pour la liste des ouvertures
    public class OpeningList
        {
            public List<Opening> Data { get; set; } = new List<Opening>();
            public void DisplayInfo()
            {
                foreach (var opening in Data)
                {
                    opening.DisplayInfo(false);
                }
            }
        }
    }


