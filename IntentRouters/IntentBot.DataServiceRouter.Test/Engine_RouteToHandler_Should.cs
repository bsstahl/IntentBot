using System;
using IntentBot.Interfaces;
using IntentBot.Entities;
using Autofac;
using TestHelperExtensions;
using Xunit;
using Moq;
using Autofac.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using IntentBot.Exceptions;
using System.Collections.Generic;

namespace IntentBot.DataServiceRouter.Test
{
    public class Engine_RouteToHandler_Should
    {
        string _routesJson = "[{ \"IntentName\" : \"default\", \"RouteUri\" : \"abcdefg\", \"SampleUtterance\" : \"default_utterance\" }, { \"IntentName\" : \"hijklmnop\", \"RouteUri\" : \"http://www.hijklmnop.com\", \"SampleUtterance\" : \"hijklmnop_utterance\" }]";
        string _routesWithoutDefaultJson = "[{\"IntentName\" : \"abcdefg\" , \"RouteUri\" : \"http://www.abcdefg.com\" , \"SampleUtterance\" : \"abcdefg_utterance\" },{\"IntentName\" : \"hijklmnop\", \"RouteUri\" : \"http://www.hijklmnop.com\" , \"SampleUtterance\" : \"hijklmnop_utterance\"},{\"IntentName\" : \"qrstuvw\" , \"RouteUri\" : \"http://www.qrstuvw.com/\" , \"SampleUtterance\" : \"qrstuvw_utterance\"}]";

        [Fact]
        public void ThrowMissingRouteExceptionIfNoDefaultRouteProvided()
        {
            var containerBuilder = new Autofac.ContainerBuilder();

            var httpResponseMessage = new Mock<IHttpResponseMessage>();
            var httpResponseTask = Task.Run(() => httpResponseMessage.Object);
            httpResponseMessage.SetupGet(m => m.Content).Returns(_routesWithoutDefaultJson);

            var httpProxy = new Mock<IHttpProxy>();
            httpProxy.Setup(p => p.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(httpResponseTask);
            containerBuilder.RegisterInstance<IHttpProxy>(httpProxy.Object);

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);

            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            Assert.Throws<MissingRouteException>(() => new DataServiceRouter.Engine(serviceProvider, string.Empty));
        }

        [Fact]
        public async Task RouteAnKnownIntentToTheProperHandler()
        {
            string intentName = "hijklmnop";
            string routeUri = $"http://www.{intentName}.com";

            var containerBuilder = new Autofac.ContainerBuilder();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();
            var httpResponseTask = Task.Run(() => httpResponseMessage.Object);
            httpResponseMessage.SetupGet(m => m.Content).Returns(_routesJson);

            var httpProxy = new Mock<IHttpProxy>();
            httpProxy.Setup(p => p.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(httpResponseTask);
            containerBuilder.RegisterInstance<IHttpProxy>(httpProxy.Object);

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);

            var intent = new IntentBuilder().Random().AddName(intentName);
            var request = new UserRequestBuilder().Random().AddIntent(intent).Build();

            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var target = new DataServiceRouter.Engine(serviceProvider, string.Empty);
            var actual = await target.HandleRequestAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(routeUri, It.IsAny<UserRequest>()), Times.Once);
        }

        [Fact]
        public async Task RouteAnUnknownIntentToTheDefaultHandler()
        {
            var containerBuilder = new Autofac.ContainerBuilder();
            var httpResponseMessage = new Mock<IHttpResponseMessage>();
            var httpResponseTask = Task.Run(() => httpResponseMessage.Object);
            httpResponseMessage.SetupGet(m => m.Content).Returns(_routesJson);

            var httpProxy = new Mock<IHttpProxy>();
            httpProxy.Setup(p => p.GetAsync(It.IsAny<string>(), It.IsAny<IEnumerable<KeyValuePair<string, string>>>())).Returns(httpResponseTask);
            containerBuilder.RegisterInstance<IHttpProxy>(httpProxy.Object);

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);

            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var request = new UserRequestBuilder().Random().Build();
            var target = new DataServiceRouter.Engine(serviceProvider, string.Empty);
            var actual = await target.HandleRequestAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync("abcdefg", It.IsAny<UserRequest>()), Times.Once);
        }
    }
}

