using CreateYourOwnAdventure.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace CreateYourOwnAdventure.service
{
    internal class PlayerService
    {

        public List<Player> GetPlayers()
        {
            String jsonPath = @"..\..\data\players.json";
            String json = File.ReadAllText(jsonPath);

            List<Player> players = JsonConvert.DeserializeObject<List<Player>>(json);

            return players;
        }

        public Player CreateNewPlayer()
        {
            Console.WriteLine("Erstellen Sie einen neuen Spieler.");
            Console.WriteLine("Name:");
            return new Player(Console.ReadLine());
        }

        public Player SelectPlayer()
        {
            // Spielerauswahl implementieren
            return null;
        }

        public void SavePlayer(Player player)
        {
            
        }

    }
}
