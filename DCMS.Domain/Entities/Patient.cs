
namespace DCMS.Domain.Entities
{
    public class Patient
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
    }
}
