using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficesList;
using DCMS.Domain.Entities;
using NSubstitute;

namespace DCMS.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class GetDentalOfficesListQueryHandlerTests
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IDentalOfficeRepository _repository;
        private GetDentalOfficesListQueryHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.

        [TestInitialize]
    public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _handler = new GetDentalOfficesListQueryHandler(_repository);
        }

        [TestMethod]
        public async Task Handle_WhenThereAreDentalOffices_ReturnsDentalOfficesList()
        {
            var dentalOffices = new List<DentalOffice>
            {
                new DentalOffice("Dental Office 1"),
                new DentalOffice("Dental Office 2")
            };

            _repository.GetAll().Returns(dentalOffices);

            var expectedResult = dentalOffices.Select(d => new DentalOfficesListDTO
            {
                Id = d.Id,
                Name = d.Name
            }).ToList();

            var result = await _handler.Handle(new GetDentalOfficeListQuery());

            Assert.AreEqual(expectedResult.Count, result.Count());
            for(int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult.ElementAt(i).Id, result.ElementAt(i).Id);
                Assert.AreEqual(expectedResult.ElementAt(i).Name, result.ElementAt(i).Name);
            }
        }

        [TestMethod]
        public async Task Handle_WhenThereAreNoDentalOffices_ReturnsEmptyList()
        {
            _repository.GetAll().Returns(new List<DentalOffice>());
            var result = await _handler.Handle(new GetDentalOfficeListQuery());
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
