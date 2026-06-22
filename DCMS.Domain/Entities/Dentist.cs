
namespace DCMS.Domain.Entities
{
    public class Dentist
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
    }
}
