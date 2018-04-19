using IntentBot.Entities;
using System;
using System.Collections.Generic;

namespace IntentBot
{
    public class UserBuilder : User
    {
        List<KeyValuePair<string, string>> _additionalDataBuffer = new List<KeyValuePair<string, string>>();

        public User Build()
        {
            this.AdditionalData = _additionalDataBuffer;
            return this;
        }

        public UserBuilder AddId(string id)
        {
            this.Id = id;
            return this;
        }

        public UserBuilder AddFirstName(string name)
        {
            this.FirstName = name;
            return this;
        }

        public UserBuilder AddLastName(string name)
        {
            this.LastName = name;
            return this;
        }

        public UserBuilder AddName(string firstName, string lastName)
        {
            return this.AddFirstName(firstName).AddLastName(lastName);
        }

        public UserBuilder AddAdditionalDataItem(string key, string value)
        {
            _additionalDataBuffer.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }

        public UserBuilder Random()
        {
            this.AddId(Guid.NewGuid().ToString())
                .AddFirstName(Guid.NewGuid().ToString())
                .AddLastName(Guid.NewGuid().ToString());

            int count = Convert.ToInt32((new Random()).Next(3, 10));
            for (int i = 0; i < count; i++)
                this.AddAdditionalDataItem(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            return this;
        }
    }
}
