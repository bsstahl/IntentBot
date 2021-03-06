﻿using System;
using IntentBot.Entities;

namespace IntentBot
{
    public class UserRequestBuilder : UserRequest
    {
        public UserRequestBuilder()
        {
            this.RequestDateTimeUtc = DateTime.UtcNow;
        }

        public UserRequest Build()
        {
            return this;
        }

        public UserRequestBuilder AddIntent(Intent intent)
        {
            this.Intent = intent;
            return this;
        }

        public UserRequestBuilder AddSource(string source)
        {
            this.Source = source;
            return this;
        }

        public UserRequestBuilder AddUser(User user)
        {
            this.User = user;
            return this;
        }

        public UserRequestBuilder AddRequestUtcDateTime(DateTime requestDateTimeUtc)
        {
            this.RequestDateTimeUtc = requestDateTimeUtc;
            return this;
        }

        public UserRequestBuilder Random()
        {
            this.AddUser((new UserBuilder().Random().Build()));
            this.AddSource("UserRequestBuilder");
            this.AddIntent(new IntentBuilder().Random().Build());
            return this;
        }
    }
}
