using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Test.Domain.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Constructor_NullEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
            () => new Email(null!));

            Assert.AreEqual("Email is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_EmptyEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
               () => new Email(string.Empty));

            Assert.AreEqual("Email is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_WhitespaceEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new Email("   "));

            Assert.AreEqual("Email is required.", ex.Message);
        }

        [TestMethod]
        public void Constructor_InvalidEmail_ThrowsBusinessRuleException()
        {
            var ex = Assert.Throws<BusinessRuleException>(
                () => new Email("invalid-email"));

            Assert.AreEqual("Email address is not valid.", ex.Message);
        }

        [TestMethod]
        public void Constructor_ValidEmail_CreatesEmail()
        {
            var value = "john.doe@example.com";

            var email = new Email(value);

            Assert.AreEqual(value, email.Value);
        }

        [TestMethod]
        public void Constructor_TrimmedEmail_StoresTrimmedValue()
        {
            var value = "  john.doe@example.com  ";

            var email = new Email(value);

            Assert.AreEqual("john.doe@example.com", email.Value);
        }
    }
}
