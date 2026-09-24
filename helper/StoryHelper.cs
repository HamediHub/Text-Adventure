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

        private StoryHelper()
        {
            throw new NotSupportedException("Cannot instantiate helper class 'StoryHelper'");
        }

        public static Story GetNewStory()
        {
            String jsonPath = @"..\..\data\story.json";
            String json = File.ReadAllText(jsonPath);

            return JsonConvert.DeserializeObject<Story>(json);
        }

    }
}
