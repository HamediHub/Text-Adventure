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
        string title;
        List<StoryNode> storyNodes;

        public string Title {
            
            get
            {
                return title;
            }
        }

    }

}
