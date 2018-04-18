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

namespace IntentBot.ConfigRouter.Test
{
    public class Engine_RouteToHandler_Should
    {
        [Fact]
        public void ThrowMissingRouteExceptionIfNoDefaultRouteProvided()
        {
            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var config = new ConfigurationBuilder()
                .AddJsonFile("noDefaultRoute.json")
                .Build();

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            containerBuilder.RegisterInstance<IConfiguration>(config);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            //var intent = new IntentBuilder().Random().AddName(string.Empty.GetRandom());
            //var request = new UserRequestBuilder().Random().AddIntent(intent).Build();

            Assert.Throws<MissingRouteException>(() => new ConfigRouter.Engine(serviceProvider));
        }

        [Fact]
        public async Task RouteAnKnownIntentToTheProperHandlerUsingAJsonConfigFile()
        {
            string intentName = "hijklmnop";
            string routeUri = $"http://www.{intentName}.com";

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var config = new ConfigurationBuilder()
                .AddJsonFile("routes.json")
                .Build();

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            containerBuilder.RegisterInstance<IConfiguration>(config);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var intent = new IntentBuilder().Random().AddName(intentName);
            var request = new UserRequestBuilder().Random().AddIntent(intent).Build();

            var target = new ConfigRouter.Engine(serviceProvider);
            var actual = await target.HandleRequestAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(routeUri, It.IsAny<UserRequest>()), Times.Once);
        }

        [Fact]
        public async Task RouteAnKnownIntentToTheProperHandler()
        {
            string intentName = string.Empty.GetRandom();
            string routeUri = $"http://www.{intentName}.com";

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var routes = new RouteCollectionBuilder(string.Empty.GetRandom())
                .Add(intentName, routeUri).Build().AsJsonString();
            var routeCollection = new List<KeyValuePair<string, string>>()
                { new KeyValuePair<string, string>("intentRoutes", routes) };
            var config = new ConfigurationBuilder().AddInMemoryCollection(routeCollection).Build();

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            containerBuilder.RegisterInstance<IConfiguration>(config);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var intent = new IntentBuilder().Random().AddName(intentName);
            var request = new UserRequestBuilder().Random().AddIntent(intent).Build();

            var target = new ConfigRouter.Engine(serviceProvider);
            var actual = await target.HandleRequestAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(routeUri, It.IsAny<UserRequest>()), Times.Once);
        }

        [Fact]
        public async Task RouteAnUnknownIntentToTheDefaultHandler()
        {
            string defaultRouteUri = $"http://{string.Empty.GetRandom()}";

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var routes = new RouteCollectionBuilder(defaultRouteUri)
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Build().AsJsonString();
            var routeCollection = new List<KeyValuePair<string, string>>()
                { new KeyValuePair<string, string>("intentRoutes", routes) };
            var config = new ConfigurationBuilder().AddInMemoryCollection(routeCollection).Build();

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            containerBuilder.RegisterInstance<IConfiguration>(config);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var request = new UserRequestBuilder().Random().Build();
            var target = new ConfigRouter.Engine(serviceProvider);
            var actual = await target.HandleRequestAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(defaultRouteUri, It.IsAny<UserRequest>()), Times.Once);
        }
    }
}

