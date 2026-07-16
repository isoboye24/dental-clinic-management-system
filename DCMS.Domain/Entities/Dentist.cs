using DCMS.Domain.ValueObjects;

namespace DCMS.Domain.Entities
{
    public class Dentist : Person
    {
        public Dentist(string name, Email email)
        : base(name, email)
        {
        }

        private Dentist()
        {
            
        }
    }    
}
