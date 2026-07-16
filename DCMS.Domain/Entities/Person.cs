using DCMS.Domain.Exceptions;
using DCMS.Domain.ValueObjects;

namespace DCMS.Domain.Entities
{
    public abstract class Person
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; } = null!;
        public Email Email { get; protected set; } = null!;

        protected Person()
        {
            
        }

        protected Person(string name, Email email)
        {
            ValidateName(name);
            ValidateEmail(email);

            Name = name.Trim();
            Email = email;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Name is required.");
        }

        private static void ValidateEmail(Email email)
        {
            if (email is null)
                throw new BusinessRuleException("Email is required.");
        }

        public void UpdateName(string name)
        {
            ValidateName(name);
            Name = name.Trim();
        }

        public void UpdateEmail(Email email)
        {
            ValidateEmail(email);
            Email = email;
        }
    }
}
