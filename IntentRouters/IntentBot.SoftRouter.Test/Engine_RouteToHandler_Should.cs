using System;
using IntentBot.Interfaces;
using IntentBot.Entities;
using Autofac;
using TestHelperExtensions;
using Xunit;
using Moq;
using Autofac.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace IntentBot.SoftRouter.Test
{
    public class Engine_RouteToHandler_Should
    {
        [Fact]
        public async Task RouteAnKnownIntentToTheProperHandler()
        {
            string intentName = string.Empty.GetRandom();
            string routeUri = $"http://{string.Empty.GetRandom()}";

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var routes = new RouteCollectionBuilder(string.Empty.GetRandom()).Add(intentName, routeUri).Build();
            var intent = new IntentBuilder().Random().AddName(intentName);
            var request = new UserRequestBuilder().Random().AddIntent(intent).Build();

            var target = new SoftRouter.Engine(serviceProvider, routes);
            var actual = await target.RouteToHandlerAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(routeUri, It.IsAny<UserRequest>()), Times.Once);
        }

        [Fact]
        public async Task RouteAnUnknownIntentToTheDefaultHandler()
        {
            string defaultRouteUri = $"http://{string.Empty.GetRandom()}";

            var cmdProcessor = new Mock<ICommandProcessor>(MockBehavior.Loose);

            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterInstance<ICommandProcessor>(cmdProcessor.Object);
            var serviceProvider = new AutofacServiceProvider(containerBuilder.Build());

            var routes = new RouteCollectionBuilder(defaultRouteUri)
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Add(string.Empty.GetRandom(), string.Empty.GetRandom())
                .Build();

            var request = new UserRequestBuilder().Random().Build();
            var target = new SoftRouter.Engine(serviceProvider, routes);
            var actual = await target.RouteToHandlerAsync(request);

            cmdProcessor.Verify(p => p.ProcessAsync(defaultRouteUri, It.IsAny<UserRequest>()), Times.Once);
        }
    }
}

