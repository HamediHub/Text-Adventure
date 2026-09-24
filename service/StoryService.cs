using CreateYourOwnAdventure.helper;
using CreateYourOwnAdventure.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.service
{
    internal class StoryService
    {

        public void TraverseStory(Player player)
        {
            Story story = StoryHelper.GetStory();

            // currentNode ermitteln
            StoryNode currentNode = GetCurrentNode(story, player);
            OutputHelper.PrintLine(currentNode.NodeText);

            // possibleChoices ermitteln
            List<Choice> possibleChoices = GetPossibleChoices(currentNode, player);

            // 

            Choice selectedChoice = null;
            if (possibleChoices.Count <= 0)
            {
                OutputHelper.PrintLine("");
                return;
            }
            else if (possibleChoices.Count == 1) {
                OutputHelper.PrintLine(possibleChoices[0].ChoiceText);
                OutputHelper.PrintLine("Du hast keine weiteren Optionen.");

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

                int input = InputHelper.GetIntInput(1, count);

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

        public StoryNode GetCurrentNode(Story story, Player player)
        {
            StoryNode currentNode = null;

            foreach (StoryNode storyNode in story.StoryNodes)
            {
                if (storyNode.Id == player.CurrentNode)
                {
                    currentNode = storyNode;
                }
            }

            return currentNode;
        }

        public List<Choice> GetPossibleChoices(StoryNode storyNode, Player player)
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
