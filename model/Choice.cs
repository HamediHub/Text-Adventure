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
        private Item requiredItem;
        private int targetNodeId;
        private Item rewardItem;

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

        public Item RequiredItem
        {
            get
            {
                return requiredItem;
            }
            set
            {
                requiredItem = value;
            }
        }

        public int TargetNodeId
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

        public Item RewardItem
        {
            get
            {
                return rewardItem;
            }
            set
            {
                rewardItem = value;
            }
        }
    }
}
