using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace IntentBot.LuisIntentProvider
{
    internal class LuisResponse
    {
        public string query { get; set; }
        public Topscoringintent topScoringIntent { get; set; }
        public LuisIntent[] intents { get; set; }
        public Entity[] entities { get; set; }

        public string AsJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    internal class Topscoringintent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    internal class LuisIntent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    internal class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public Resolution resolution { get; set; }
    }

    internal class Resolution
    {
        public Value[] values { get; set; }
    }

    internal class Value
    {
        public string timex { get; set; }
        public string type { get; set; }
        public string value { get; set; }
    }
}



