using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public Email Email { get; private set; } = null!;

        public Patient(string name, Email email)
        {
            ValidateName(name);

            if (email is null)
            {
                throw new BusinessRuleException("The email is required.");
            }

            Id = Guid.CreateVersion7();
            Name = name.Trim();
            Email = email;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException("Patient name is required.");
            }
        }

    }
}
