using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Features.DentalOffices.Commands.DeleteDentalOffice;
using DCMS.Domain.Entities;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace DCMS.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class DeleteDentalOfficesCommandHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IDentalOfficeRepository _repository;
        private IUnitOfWork _unitOfWork;
        private DeleteDentalOfficeCommandHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new DeleteDentalOfficeCommandHandler(_repository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeExists_DeleteAndCommitAreCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office 1");
            var command = new DeleteDentalOfficeCommand{Id = dentalOffice.Id};

            _repository.GetById(command.Id).Returns(dentalOffice);
            await _handler.Handle(command);
            await _repository.Received(1).Delete(dentalOffice);
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenDentalOfficeDoesNotExist_Throws()
        {
            var command = new DeleteDentalOfficeCommand { Id = Guid.NewGuid() };
            _repository.GetById(command.Id).ReturnsNull();
            await Assert.ThrowsExactlyAsync<NotFoundException>(() => _handler.Handle(command));
        }

        [TestMethod]
        public async Task Handle_WhenDeleteThrows_RollbackIsCalled()
        {
            var dentalOffice = new DentalOffice("Dental Office 1");
            var command = new DeleteDentalOfficeCommand { Id = dentalOffice.Id };

            _repository.GetById(command.Id).Returns(dentalOffice);
            _repository.Delete(dentalOffice).Throws(new InvalidOperationException("Delete failed"));

            await Assert.ThrowsExactlyAsync<InvalidOperationException>(() => _handler.Handle(command));
            await _unitOfWork.Received(1).Rollback();
        }
    }
}
