using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.model
{
    internal class StoryNode
    {
        private string nodeId;
        private List<string> nodeText;
        private List<Choice> choices;

        public string NodeId
        {
            get
            {
                return nodeId;
            }
            set
            {
                nodeId = value;
            }
        }

        public List<string> NodeText
        {
            get
            {
                return nodeText;
            }
            set
            {
                nodeText = value;
            }
        }

        public List<Choice> Choices
        {
            get
            {
                return choices;
            }
            set
            {
                choices = value;
            }
        }
    }
}
