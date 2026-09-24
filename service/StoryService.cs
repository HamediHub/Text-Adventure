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
            Console.WriteLine(currentNode.NodeText);

            // possibleChoices ermitteln
            List<Choice> possibleChoices = GetPossibleChoices(currentNode, player);

            // 
            if (possibleChoices.Count <= 0)
            {
                Console.ReadKey();
            }
            else if (possibleChoices.Count == 1) {
                Console.WriteLine(possibleChoices[0].ChoiceText);
                Console.WriteLine("Du hast keine weiteren Optionen.");
                Console.ReadKey();

                if (possibleChoices[0].RewardItem != null)
                {
                    Console.WriteLine("Du erhältst '" + possibleChoices[0].RewardItem.Name + "'.");
                    Console.ReadKey();
                }
            }
            else
            {
                int count = 1;
                foreach (Choice choice in possibleChoices)
                {
                    Console.Write(count + ": " + choice.ChoiceText);

                    if (choice.RequiredItem != null)
                    {
                        Console.WriteLine(" (uses " + choice.RequiredItem + ")");
                    }

                    Console.WriteLine();
                }


            }
            

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
                if (choice.RequiredItem == null || player.Inventory.Contains(choice.RequiredItem))
                {
                    possibleChoices.Add(choice);
                }
            }

            return possibleChoices;
        }

    }
}
