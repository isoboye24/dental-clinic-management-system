using DCMS.Domain.Exceptions;

namespace DCMS.Domain.ValueObjects
{
    public class TimeInterval
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TimeInterval(DateTime start, DateTime end) 
        {
            if (start > end)
            {
                throw new BusinessRuleException("Start time must be earlier than end time.");
            }

            Start = start;
            End = end;
        }
    }
}
