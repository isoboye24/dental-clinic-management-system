using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Test.Domain.ValueObjects
{
    [TestClass]
    public class TimeIntervalTests
    {
        [TestMethod]
        public void Constructor_ValidInterval_CreatesTimeInterval()
        {
            var start = DateTime.UtcNow;
            var end = start.AddHours(1);

            var interval = new TimeInterval(start, end);

            Assert.AreEqual(start, interval.Start);
            Assert.AreEqual(end, interval.End);
        }

        [TestMethod]
        public void Constructor_StartAfterEnd_ThrowsBusinessRuleException()
        {
            var start = DateTime.UtcNow;
            var end = start.AddHours(-1);

            var ex = Assert.Throws<BusinessRuleException>(
                () => new TimeInterval(start, end));

            Assert.AreEqual(
                "Start time must be earlier than end time.",
                ex.Message);
        }
    }
}
