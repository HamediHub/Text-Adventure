using CreateYourOwnAdventure.helper;
using CreateYourOwnAdventure.model;
using System;
using System.Collections.Generic;

namespace CreateYourOwnAdventure.service
{
    internal class StoryService
    {

        public void TraverseStory(Player player)
        {
            Story story = StoryHelper.GetStory();

            // currentNode ermitteln
            StoryNode currentNode = GetCurrentNode(story, player);

            // NodeText ausgeben
            Console.Clear();

            for (int i = 0; i < currentNode.NodeText.Count; i++)
            {
                OutputHelper.PrintLine(currentNode.NodeText[i] + "\n");
            }

            // possibleChoices ermitteln
            List<Choice> possibleChoices = GetPossibleChoices(currentNode, player);

            // 

            Choice selectedChoice = null;
            if (possibleChoices.Count <= 0)
            {
                OutputHelper.PrintLineNoReadKey("");
                OutputHelper.PrintLine("Weiter");
                return;
            }
            else if (possibleChoices.Count == 1) {
                OutputHelper.PrintLineNoReadKey("1: " +possibleChoices[0].ChoiceText);
                OutputHelper.PrintLineNoReadKey("2: Beenden");

                int input = InputHelper.GetIntInput(1, 2);

                if (input == 2)
                {
                    return;
                }

                selectedChoice = possibleChoices[0];
            }
            else
            {
                int count = 0;
                foreach (Choice choice in possibleChoices)
                {
                    count++;
                    OutputHelper.Print(count + ": " + choice.ChoiceText);

                    if (choice.RequiredItemId != null)
                    {
                        OutputHelper.Print(" (uses " + StoryHelper.GetItem(choice.RequiredItemId).Name + ")");
                    }

                    OutputHelper.PrintLineNoReadKey("");
                }
                OutputHelper.PrintLineNoReadKey(++count + ": Beenden");

                int input = InputHelper.GetIntInput(1, count);

                if (input == count)
                {
                    return;
                }

                selectedChoice = possibleChoices[input - 1];

                
            }

            if (selectedChoice.RewardItemId != null)
            {
                OutputHelper.Print("Du erhältst ");
                OutputHelper.ColorPrint(StoryHelper.GetItem(selectedChoice.RewardItemId).Name, ConsoleColor.DarkGreen);
                OutputHelper.PrintLine(".");
                player.Inventory.Add(selectedChoice.RewardItemId);
            }

            if (selectedChoice.RequiredItemId != null)
            {
                OutputHelper.Print("Du verlierst ");
                OutputHelper.ColorPrint(StoryHelper.GetItem(selectedChoice.RequiredItemId).Name, ConsoleColor.DarkRed);
                OutputHelper.PrintLine(".");
                player.Inventory.Remove(selectedChoice.RequiredItemId);
            }

            player.CurrentNode = selectedChoice.TargetNodeId;


        }

        public void showInventory(Player player)
        {
            Story story = StoryHelper.GetStory();

            List<Item> playerItems = new List<Item>();

            Console.Clear();

            int count = 0;
            foreach (string itemId in player.Inventory)
            {
                count++;
                Item item = StoryHelper.GetItem(itemId);
                playerItems.Add(item);
                OutputHelper.PrintLineNoReadKey(count + ": " + item.Name);
            }
            OutputHelper.PrintLineNoReadKey("");

            if (count == 0)
            {
                OutputHelper.PrintLine("Ihr Inventar ist leer.");
                return;
            }
            int input = InputHelper.GetIntInput(1, count);

            lookAtItem(player, playerItems[input - 1]);
        }

        private void lookAtItem(Player player, Item item)
        {
            Console.Clear();
            OutputHelper.ColorPrintLineNoReadKey(item.Name, ConsoleColor.Green);
            OutputHelper.PrintLineNoReadKey(item.Description);
            OutputHelper.PrintLineNoReadKey("");
            OutputHelper.PrintLine("Drücken Sie eine beliebige Taste, um fortzufahren...");

            Console.Clear();
            OutputHelper.PrintLineNoReadKey("Wie möchten Sie fortfahren?");
            OutputHelper.PrintLineNoReadKey("1: Weiter");
            OutputHelper.PrintLineNoReadKey("2: Zurück");

            int input = InputHelper.GetIntInput(1, 2);
            if (input == 2)
            {
                showInventory(player);
            }
        }

        private StoryNode GetCurrentNode(Story story, Player player)
        {
            StoryNode currentNode = null;

            foreach (StoryNode storyNode in story.StoryNodes)
            {
                if (storyNode.NodeId == player.CurrentNode)
                {
                    currentNode = storyNode;
                }
            }

            return currentNode;
        }

        private List<Choice> GetPossibleChoices(StoryNode storyNode, Player player)
        {
            List<Choice> possibleChoices = new List<Choice>();

            foreach (Choice choice in storyNode.Choices)
            {
                if (choice.RequiredItemId == null || player.Inventory.Contains(choice.RequiredItemId))
                {
                    possibleChoices.Add(choice);
                }
            }

            return possibleChoices;
        }

    }
}
