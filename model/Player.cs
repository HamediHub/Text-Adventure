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
        private int id;
        private List<string> inventory;
        private string currentNode;

        public Player(string name, int id)
        {
            this.name = name;
            this.id = id;
            this.inventory = new List<string>();
            this.currentNode = "start";
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

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public List<string> Inventory
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

        public string CurrentNode
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
