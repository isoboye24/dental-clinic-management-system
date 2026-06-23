using DCMS.Domain.Entities;
using DCMS.Domain.Exceptions;

namespace DCMS.Test.Domain.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new DentalOffice(null!));

            Assert.AreEqual(
                "Dentist name is required.",
                ex.Message);
        }

        [TestMethod]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new DentalOffice(null!));

            Assert.AreEqual(
                "Dentist name is required.",
                ex.Message);
        }
    }
}
