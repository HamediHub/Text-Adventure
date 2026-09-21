using CreateYourOwnAdventure.controller;

namespace CreateYourOwnAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController gameController = new GameController();
            gameController.StartGame();
        }
    }
}
