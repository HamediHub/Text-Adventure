
using CreateYourOwnAdventure.helper;
using CreateYourOwnAdventure.model;
using CreateYourOwnAdventure.service;
using System;
using System.Collections.Generic;

namespace CreateYourOwnAdventure.controller
{
    internal class GameController
    {

        private static PlayerService playerService = new PlayerService();
        private static StoryService storyService = new StoryService();

        public void StartGame()
        {
            Player selectedPlayer = StartMenu();

            OutputHelper.PrintLine(StoryHelper.GetStory().Title);


            while (true)
            {
                storyService.TraverseStory(selectedPlayer);

                playerService.SavePlayer(selectedPlayer);

                Console.ReadKey();

                OutputHelper.PrintLineNoReadKey("");
                OutputHelper.PrintLineNoReadKey("Was möchten Sie tun?");
                OutputHelper.PrintLineNoReadKey("1: Spiel fortsetzen");
                OutputHelper.PrintLineNoReadKey("2: Spiel beenden");
                int choice = InputHelper.GetIntInput(1, 2);
                if (choice == 2)
                {
                    break;
                }
            }
         
        }

        private Player StartMenu()
        {
            Player selectedPlayer = null;

            int choice = 0;

            // Falls es noch keine gespeicherten Spieler gibt, muss ein neuer Spieler erstellt werden.
            if (playerService.GetPlayers() == null || playerService.GetPlayers().Count == 0)
            {
                OutputHelper.PrintLine("Es gibt noch keine Spieler.");

                // Vorauswahl auf "Neuer Spieler" setzen, da es keine Spieler gibt.
                choice = 1;
            }

            if (choice != 1)
            {
                OutputHelper.PrintLineNoReadKey("Startmenü");
                OutputHelper.PrintLineNoReadKey("1: Neuer Spieler");
                OutputHelper.PrintLineNoReadKey("2: Vorhandener Spieler");
                choice = InputHelper.GetIntInput(1, 2);
            }


            switch (choice)
            {
                case 1:
                    selectedPlayer = playerService.CreateNewPlayer();
                    break;
                case 2:
                    selectedPlayer = playerService.SelectPlayer();
                    break;
            }

            return selectedPlayer;

        }

    }
}
