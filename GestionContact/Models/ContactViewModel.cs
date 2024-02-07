using GestionContact.Domain.Entities;

namespace GestionContact.Models
{
    public class ContactViewModel
    {
        public ContactViewModel(Contact c)
        {
            Id = c.Id;
            FullName = c.LastName + " " + c.FirstName;

        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
    }
}
