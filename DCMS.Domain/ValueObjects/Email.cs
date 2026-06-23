using DCMS.Domain.Exceptions;
using System.Net.Mail;

namespace DCMS.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; } = null!;
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException("Email is required.");
            }

            email = email.Trim();

            try
            {
                var mailAddress = new MailAddress(email);

                if (mailAddress.Address != email.Trim())
                {
                    throw new BusinessRuleException("Email address is not valid.");
                }
            }
            catch (FormatException)
            {
                throw new BusinessRuleException("Email address is not valid.");
            }

            Value = email;
        }
    }
}
