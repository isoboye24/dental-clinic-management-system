using DCMS.Application.Exceptions;
using DCMS.Application.Utilities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace DCMS.Test.Application.Utitlities.Mediator
{
    [TestClass]
    public class SimpleMediatorTests
    {
        public class FalseRequest : IRequest<string> { }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandlerIsExcuted()
        {
            var request = new FalseRequest();

            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>))
                .Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProvider);
            var result = await mediator.Send(request);
            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_Throws()
        {
            var request = new FalseRequest();

            var serviceProvider = Substitute.For<IServiceProvider>();
            serviceProvider
                .GetService(typeof(IRequestHandler<FalseRequest, string>))
                .ReturnsNull();

            var mediator = new SimpleMediator(serviceProvider);

            await Assert.ThrowsAsync<MediatorException>(
                () => mediator.Send(request));
        }
    }
}
