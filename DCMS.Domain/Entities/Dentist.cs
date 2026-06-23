using DCMS.Domain.Exceptions;
using System.Net.Mail;

namespace DCMS.Domain.Entities
{
    public class Dentist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;

        public Dentist(string name, string email)
        {
            ValidateName(name);
            ValidateEmail(email);

            Id = Guid.CreateVersion7();
            Name = name.Trim();
            Email = email.Trim();
        }

        public void UpdateEmail(string email)
        {
            ValidateEmail(email);
            Email = email.Trim();
        }

        private static void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException("Dentist name is required.");
            }
        }

        private static void ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException("Email is required.");
            }

            try
            {
                var mailAddress = new MailAddress(email);

                if (mailAddress.Address != email.Trim())
                {
                    throw new BusinessRuleException("Email address is not valid.");
                }
            }
            catch
            {
                throw new BusinessRuleException("Email address is not valid.");
            }
        }
    }
}
