using GestionContact.Domain.Entities;

namespace GestionContact.Models
{
    public class ContactDetailsViewModel
    {
        public ContactDetailsViewModel(Contact contact)
        {
            Id = contact.Id;
            LastName = contact.LastName;
            FirstName = contact.FirstName;
            Addresses = contact.Addresses.Select(a => $"{a.Street} {a.Number}").ToList();
        }

        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;

        public List<string> Addresses { get; set; } = null!;
    }
}
