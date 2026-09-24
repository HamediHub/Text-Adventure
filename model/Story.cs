using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.model
{
    internal class Story
    {
        private string title;
        private List<StoryNode> storyNodes;

        private List<Item> items;

        public string Title {
            
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public List<StoryNode> StoryNodes
        {
            get
            {
                return storyNodes;
            }
            set
            {
                storyNodes = value;
            }
        }

        public List<Item> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
            }
        }

    }

}
