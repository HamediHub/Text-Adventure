using CreateYourOwnAdventure.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.model
{
    internal class Player
    {
        private string name;
        private List<Item> inventory;
        private Story story;
        private int currentNode;

        public Player(string name)
        {
            this.name = name;
            this.inventory = new List<Item>();
            this.story = StoryHelper.GetNewStory();
            this.currentNode = 0;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public List<Item> Inventory
        {
            get
            {
                return inventory;
            }
            set
            {
                inventory = value;
            }
        }

        public Story Story
        {
            get
            {
                return story;
            }
            set
            {
                story = value;
            }
        }

        public int CurrentNode
        {
            get
            {
                return currentNode;
            }
            set
            {
                currentNode = value;
            }
        }
    }
}
