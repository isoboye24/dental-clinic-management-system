using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.DentalOffices.Commands.CreateDentalOffice;
using DCMS.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DCMS.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class CreateDentalOfficeCommandHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IDentalOfficeRepository _repository;
        private IUnitOfWork _unitOfWork;
        private CreateDentalOfficeCommandHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new CreateDentalOfficeCommandHandler(_repository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsDentalOfficeId()
        {
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office"};
            var dentalOffice = new DentalOffice(command.Name);
            _repository.Add(Arg.Any<DentalOffice>()).Returns(dentalOffice);

            var result = await _handler.Handle(command);

            Assert.AreEqual(dentalOffice.Id, result);
            await _repository.Received(1).Add(Arg.Any<DentalOffice>());
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhentheresAnError_WeRollback()
        {
            var command = new CreateDentalOfficeCommand { Name = "Test Dental Office" };
            _repository.Add(Arg.Any<DentalOffice>()).Throws<Exception>();

            await Assert.ThrowsAsync<Exception>(
            () => _handler.Handle(command));

            await _unitOfWork.Received(1).Rollback();
        }
    }
}
