using DCMS.Application.Contracts.Repositories;
using DCMS.Application.Exceptions;
using DCMS.Application.Features.DentalOffices.Queries.GetDentalOfficeDetail;
using DCMS.Domain.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace DCMS.Test.Application.Features.DentalOffices
{
    [TestClass]
    public class GetDentalOfficeCommandHandlerTest
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.
        private IDentalOfficeRepository _repository;
        private GetDentalOfficeDetailQueryHandler _handler;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the field as nullable.


        [TestInitialize]
        public void Setup()
        {
            _repository = Substitute.For<IDentalOfficeRepository>();
            _handler = new GetDentalOfficeDetailQueryHandler(_repository);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeExists_ReturnsIt()
        {
            var dentalOffice = new DentalOffice("Test Dental Office");
            var id = dentalOffice.Id;
            var query = new GetDentalOfficeDetailQuery { Id = id};

            _repository.GetById(id).Returns(dentalOffice);

            var result = await _handler.Handle(query);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(dentalOffice.Name, result.Name);
        }

        [TestMethod]
        public async Task Handle_DentalOfficeDoesNotExists_Throws()
        {
            var id = Guid.NewGuid();
            var query = new GetDentalOfficeDetailQuery { Id = id };

            _repository.GetById(id).ReturnsNull();

            await Assert.ThrowsAsync<NotFoundException>(
            () => _handler.Handle(query));
        }
    }
}
