using GestionContact.Domain.Entities;

namespace GestionContact.Models
{
    public class ContactViewModel
    {
        public ContactViewModel(Contact c)
        {
            Id = c.Id;
            FullName = c.LastName + " " + c.FirstName;
            Address = $"{c.Address.Number}, { c.Address.Street } { c.Address.City }";
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Address { get; set; } = null!; 
    }
}
