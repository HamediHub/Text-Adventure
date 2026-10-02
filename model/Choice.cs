using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.model
{
    internal class Choice
    {
        private string choiceText;
        private string requiredItemId;
        private string targetNodeId;
        private string rewardItemId;

        public string ChoiceText
        {
            get
            {
                return choiceText;
            }
            set
            {
                choiceText = value;
            }
        }

        public string RequiredItemId
        {
            get
            {
                return requiredItemId;
            }
            set
            {
                requiredItemId = value;
            }
        }

        public string TargetNodeId
        {
            get
            {
                return targetNodeId;
            }
            set
            {
                targetNodeId = value;
            }
        }

        public string RewardItemId
        {
            get
            {
                return rewardItemId;
            }
            set
            {
                rewardItemId = value;
            }
        }
    }
}
