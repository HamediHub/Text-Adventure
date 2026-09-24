using CreateYourOwnAdventure.helper;
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

            string playerName = InputHelper.GetNameInput();
            Player newPlayer = new Player(playerName);

            return newPlayer;
        }

        public Player SelectPlayer()
        {
            OutputHelper.PrintLine("Wählen Sie einen Spieler");
            List<Player> players = GetPlayers();

            int count = 0;
            foreach (Player player in players)
            {
                count++;
                OutputHelper.PrintLineNoReadKey(count + ": " + player.Name + " (" + player.CurrentNode + ")");
            }

            int input = InputHelper.GetIntInput(1, count);

            return players[input-1];
        }

        public void SavePlayer(Player player)
        {

            List<Player> players = GetPlayers();
            if (players == null)
            {
                players = new List<Player>();
            }
            players.Add(player);

            String json = JsonConvert.SerializeObject(players);

            String jsonPath = @"..\..\data\players.json";
            File.WriteAllText(jsonPath, json);

            Console.WriteLine("'" + player.Name + "' wurde erfolgreich gespeichert.");
        }

    }
}
