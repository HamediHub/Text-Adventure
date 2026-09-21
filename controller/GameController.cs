
using CreateYourOwnAdventure.model;
using CreateYourOwnAdventure.service;
using System;

namespace CreateYourOwnAdventure.controller
{
    internal class GameController
    {

        PlayerService playerService = new PlayerService();

        public void StartGame()
        {
            Player selectedPlayer = SelectPlayer();



            Console.WriteLine(selectedPlayer.Name);

            Console.WriteLine(selectedPlayer.Story.Title);

            Console.ReadKey();

        }

        private Player SelectPlayer()
        {
            Player selectedPlayer = null;

            int choice = 0;

            // Falls es noch keine gespeicherten Spieler gibt, muss ein neuer Spieler erstellt werden.
            if (playerService.GetPlayers() == null)
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
