using System;
using System.Collections.Generic;
using IntentBot.Entities;

namespace IntentBot
{
    public class IntentBuilder : Intent
    {
        public IntentBuilder()
        {
            Name = string.Empty;
            Score = 0.0;
            Utterance = string.Empty;
            IntentResponse = string.Empty;
            IntentEntities = new List<IntentEntity>();
        }

        public Intent Build()
        {
            return this;
        }

        public IntentBuilder AddName(string name)
        {
            this.Name = name;
            return this;
        }

        public IntentBuilder AddScore(double score)
        {
            this.Score = score;
            return this;
        }

        public IntentBuilder AddScore(double score, double nextBestScore)
        {
            this.Score = score;
            this.Lead = score - nextBestScore;
            return this;
        }

        public IntentBuilder AddLead(double lead)
        {
            this.Lead = lead;
            return this;
        }

        public IntentBuilder AddUtterance(string utterance)
        {
            this.Utterance = utterance;
            return this;
        }

        public IntentBuilder AddResponse(string response)
        {
            this.IntentResponse = response;
            return this;
        }

        public IntentBuilder AddEntity(string name, string type)
        {
            return AddEntity(name, type, new List<IntentEntityValue>());
        }

        public IntentBuilder AddEntity(string name, string type, IEnumerable<IntentEntityValue> values)
        {
            var newEntities = new List<IntentEntity>(this.IntentEntities);
            newEntities.Add(
                new IntentEntity()
                {
                    Name = name,
                    Type = type,
                    Values = values
                });
            this.IntentEntities = newEntities;
            return this;
        }

        public IntentBuilder AddAll(string name, double score, string utterance, string intentResponse, params IntentEntity[] intentEntities)
        {
            this.Name = name;
            this.Utterance = utterance;
            this.IntentResponse = intentResponse;
            this.Score = score;
            this.IntentEntities = intentEntities;
            return this;
        }

        public IntentBuilder Random()
        {
            this.Name = Guid.NewGuid().ToString();
            this.Score = new Random().Next();
            this.Utterance = Guid.NewGuid().ToString();
            this.IntentResponse = Guid.NewGuid().ToString();

            int entityCount = new Random().Next(1, 4);
            var entities = new List<IntentEntity>();
            for (int i = 0; i < entityCount; i++)
            {
                entities.Add(new IntentEntity()
                {
                    Name = Guid.NewGuid().ToString(),
                    Type = Guid.NewGuid().ToString()
                });
            }
            this.IntentEntities = entities;

            return this;
        }
    }
}
