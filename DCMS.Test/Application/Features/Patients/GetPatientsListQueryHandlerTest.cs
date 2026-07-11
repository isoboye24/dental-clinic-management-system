using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.Patients.Queries.GetPatientsList;
using DCMS.Domain.Entities;
using DCMS.Domain.ValueObjects;
using NSubstitute;

namespace DCMS.Test.Application.Features.Patients
{
    [TestClass]
    public class GetPatientsListQueryHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IPatientRepository _repository;
        private GetPatientListQueryHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IPatientRepository>();
            _handler = new GetPatientListQueryHandler(_repository);
        }

        [TestMethod]
        public async Task Handle_ValidQuery_ReturnsPatientsPaginatedList()
        {
            var page = 1;
            var recordsPerPage = 2;

            var patient1 = new Patient("Patient 1", new Email("patient1@example.com"));
            var patient2 = new Patient("Patient 2", new Email("patient2@example.com"));

            IEnumerable<Patient> patients = new List<Patient> { patient1, patient2 };

            _repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));

            _repository.GetTotalAmountOfRecords().Returns(Task.FromResult(10));

            var query = new GetPatientListQuery { Page = page, RecordsPerPage = recordsPerPage };

            var result = await _handler.Handle(query);

            Assert.AreEqual(10, result.TotalAmountOfRecords);
            Assert.AreEqual(2, result.Elements.Count);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoPatients_ReturnsEmptyListAndZero()
        {
            IEnumerable<Patient> patients = new List<Patient>();

            _repository.GetFiltered(Arg.Any<PatientsFilterDTO>()).Returns(Task.FromResult(patients));

            _repository.GetTotalAmountOfRecords().Returns(Task.FromResult(0));

            var query = new GetPatientListQuery { Page = 1, RecordsPerPage = 5 };

            var result = await _handler.Handle(query);

            Assert.AreEqual(0, result.TotalAmountOfRecords);
            Assert.IsNotNull(result.Elements);
            Assert.AreEqual(0, result.Elements.Count);
        }
    }
}
