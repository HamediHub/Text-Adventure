using CreateYourOwnAdventure.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateYourOwnAdventure.helper
{
    internal class StoryHelper
    {

        private static Story story;

        private StoryHelper()
        {
            throw new NotSupportedException("Cannot instantiate helper class 'StoryHelper'");
        }

        private static void initStory()
        {
            String jsonPath = @"..\..\data\story.json";
            String json = File.ReadAllText(jsonPath);

            story = JsonConvert.DeserializeObject<Story>(json);
        }

        public static Story GetStory()
        {
            if (story == null)
            {
                initStory();
            }
            return story;
        }

    }
}
