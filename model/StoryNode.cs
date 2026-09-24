using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.model
{
    internal class StoryNode
    {
        private int id;
        private string nodeText;
        private List<Choice> choices;

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

        public string NodeText
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
