using System;
using Xunit;
using IntentBot.HttpProxy;

namespace IntentBot.HttpProxy.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var responseText = "{ \"id\":\"100370\",\"firstName\":\"Barry\",\"lastName\":\"Stahl\",\"additionalData\":null}";
            var result = responseText.AsIHttpResponseMessage();
        }
    }
}
