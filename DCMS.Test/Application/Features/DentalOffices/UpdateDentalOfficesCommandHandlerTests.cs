using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Features.DentalOffices.Commands.UpdateDentalOffice;
using DCMS.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace DCMS.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class UpdateDentalOfficesCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IDentalOfficeRepository _repository;
        private IUnitOfWork _unitOfWork;
        private UpdateDentalOfficeCommandHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new UpdateDentalOfficeCommandHandler(_repository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_EntityIsUpdatedAndPersisted()
        {
            var dentalOffice = new DentalOffice("Test Dental Office");
            var id = dentalOffice.Id;
            var command = new UpdateDentalOfficeCommand
            {
                Id = dentalOffice.Id,
                Name = "Updated Dental Office"
            };
            _repository.GetById(id).Returns(dentalOffice);

            await _handler.Handle(command);
            await _repository.Received(1).Update(dentalOffice);
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeDoesNotExist_Throws()
        {
            var command = new UpdateDentalOfficeCommand
            {
                Id = Guid.NewGuid(),
                Name = "Updated Dental Office"
            };

            _repository.GetById(command.Id)
                       .Returns((DentalOffice?)null);

            await Assert.ThrowsExactlyAsync<NotFoundException>(
                () => _handler.Handle(command));
        }
    }
}
