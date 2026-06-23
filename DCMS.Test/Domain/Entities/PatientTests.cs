using DCMS.Domain.Entities;
using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Test.Domain.Entities
{
    [TestClass]
    public class PatientTests
    {
        [TestMethod]
        public void Constructor_NullName_ThrowsBusinessRuleException()
        {
            var email = new Email("iso@gmail.com");

            var ex = Assert.Throws<BusinessRuleException>(
                () => new Patient(null!, email));

            Assert.AreEqual(
                "Name is required.",
                ex.Message);
        }

        [TestMethod]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new Patient("Vincent", email: null!));

            Assert.AreEqual(
                "Email is required.",
                ex.Message);
        }

        [TestMethod]
        public void Constructor_EmptyName_ThrowsBusinessRuleException()
        {
            var email = new Email("iso@gmail.com");

            var ex = Assert.Throws<BusinessRuleException>(
                () => new Patient(string.Empty, email));

            Assert.AreEqual("Name is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_ValidDentist_CreatesDentist()
        {
            // Arrange
            var email = new Email("iso@gmail.com");

            // Act
            var dentist = new Patient("Vincent", email);

            // Assert
            Assert.AreEqual("Vincent", dentist.Name);
            Assert.AreEqual(email, dentist.Email);
        }
    }
}
