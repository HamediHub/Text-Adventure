
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
            Player selectedPlayer = SelectPlayer();

            playerService.SavePlayer(selectedPlayer);

            OutputHelper.PrintLine("Spieler '" + selectedPlayer.Name + "' wurde ausgewählt.");

            Console.WriteLine("Ausgewählter Spieler: '" + selectedPlayer.Name + "'");

            Console.WriteLine(StoryHelper.GetStory().Title);

            storyService.TraverseStory(selectedPlayer);


            Console.ReadKey();

        }

        private Player SelectPlayer()
        {
            Player selectedPlayer = null;

            int choice = 0;

            // Falls es noch keine gespeicherten Spieler gibt, muss ein neuer Spieler erstellt werden.
            if (playerService.GetPlayers() == null || playerService.GetPlayers().Count == 0)
            {
                Console.WriteLine("Es gibt noch keine Spieler.");
                choice = 1;
            }

            while (choice < 1 || choice > 2)
            {
                Console.WriteLine("(1) Neuer Spieler");
                Console.WriteLine("(2) Spielerauswahl");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());

                    if (choice < 1 || choice > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ihre Eingabe liegt außerhalb des erlaubten Bereichs!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sie müssen eine Zahl eingeben!");
                    Console.ForegroundColor = ConsoleColor.White;
                    choice = 0;
                }
                
                
            }

            switch (choice)
            {
                case 1:
                    OutputHelper.PrintLineNoReadKey("Erstellen Sie einen neuen Spieler.");
                    OutputHelper.PrintLineNoReadKey("Name: ");

                    selectedPlayer = playerService.CreateNewPlayer();

                    OutputHelper.Print("Spieler ");
                    OutputHelper.ColorPrint(selectedPlayer.Name, ConsoleColor.Blue);
                    OutputHelper.PrintLine(" wurde erfolgreich erstellt.");

                    break;
                case 2:
                    selectedPlayer = playerService.SelectPlayer();

                    OutputHelper.Print("Spieler ");
                    OutputHelper.ColorPrint(selectedPlayer.Name, ConsoleColor.Blue);
                    OutputHelper.PrintLine(" wurde erfolgreich ausgewählt.");

                    break;
            }

            return selectedPlayer;

        }

    }
}
