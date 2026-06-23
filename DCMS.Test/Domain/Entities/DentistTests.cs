using DCMS.Domain.Entities;
using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Test.Domain.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            var email = new Email("iso@gmail.com");

            var ex = Assert.Throws<BusinessRuleException>(
                () => new Dentist(null!, email));

            Assert.AreEqual(
                "Name is required.",
                ex.Message);
        }

        [TestMethod]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new Dentist("Vincent", email: null!));

            Assert.AreEqual(
                "Email is required.",
                ex.Message);
        }

        [TestMethod]
        public void Constructor_EmptyName_ThrowsBusinessRuleException()
        {
            var email = new Email("iso@gmail.com");

            var ex = Assert.Throws<BusinessRuleException>(
                () => new Dentist(string.Empty, email));

            Assert.AreEqual("Name is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_ValidDentist_CreatesDentist()
        {
            // Arrange
            var email = new Email("iso@gmail.com");

            // Act
            var dentist = new Dentist("Vincent", email);

            // Assert
            Assert.AreEqual("Vincent", dentist.Name);
            Assert.AreEqual(email, dentist.Email);
        }
    }
}
