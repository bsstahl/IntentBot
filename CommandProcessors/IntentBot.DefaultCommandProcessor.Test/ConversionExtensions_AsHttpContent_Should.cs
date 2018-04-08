using IntentBot.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntentBot.DefaultCommandProcessor.Test
{
    public class ConversionExtensions_AsHttpContent_Should
    {
        [Fact]
        public void Test1()
        {
            var request = new UserRequestBuilder()
                .AddSource("UnitTest")
                .AddUser("A1234", "PHX")
                .AddRequestUtcDateTime(DateTime.UtcNow.AddHours(-2))
                .AddIntent(new IntentBuilder()
                    .AddAll("echo", 0.9, "Please say this back to me", "{ details of my echo intent }", new IntentEntity() { Name = "EntityName", Type = "EntityType" })
                    .Build())
                .Build();

            var json = request.AsHttpContent();
        }
    }
}
