using DCMS.Domain.ValueObjects;

namespace DCMS.Domain.Entities
{
    public class Patient : Person
    {
        public Patient(string name, Email email)
        : base(name, email)
        {
        }
    }
}
