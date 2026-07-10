using DCMS.Application.Contracts.Persistence;
using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.Patients.Commands.CreatePatients;
using DCMS.Domain.Entities;
using DCMS.Domain.ValueObjects;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DCMS.Test.Application.Features.Patients
{
    [TestClass]
    public class PatientCommandHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IPatientRepository _repository;
        private IUnitOfWork _unitOfWork;
        private CreatePatientCommandHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IPatientRepository>();
            _unitOfWork = Substitute.For<IUnitOfWork>();
            _handler = new CreatePatientCommandHandler(_repository, _unitOfWork);
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ReturnsPatientId()
        {
            var command = new CreatePatientCommand { Name = "Test Patient", Email = "testm@example.com" };
            var patient = new Patient(command.Name, new Email(command.Email));

            _repository.Add(Arg.Any<Patient>()).Returns(patient);

            var result = await _handler.Handle(command);

            Assert.AreEqual(patient.Id, result);
            await _repository.Received(1).Add(Arg.Any<Patient>());
            await _unitOfWork.Received(1).Commit();
        }

        [TestMethod]
        public async Task Handle_WhenThereIsAnError_WeRollback()
        {
            var command = new CreatePatientCommand
            {
                Name = "Test Patient",
                Email = "testm@example.com"
            };
            _repository.Add(Arg.Any<Patient>()).Throws<Exception>();

            await Assert.ThrowsExactlyAsync<Exception>(() => _handler.Handle(command));

            await _unitOfWork.Received(1).Rollback();
        }
    }
}
