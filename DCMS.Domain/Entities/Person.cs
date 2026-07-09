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

            if (email is null)
                throw new BusinessRuleException("Email is required.");

            Name = name.Trim();
            Email = email;
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException("Name is required.");
        }
    }
}
