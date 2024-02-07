using System.ComponentModel.DataAnnotations;

namespace GestionContact.Models
{
    public class AddContactForm
    {
        [MaxLength(50, ErrorMessage = "c'est trop court !!")]
        public string LastName { get; set; } = null!;
        [MaxLength(50)]
        public string FirstName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Street { get; set; } = null!;

        [RegularExpression(@"\d+")]
        public string Number { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
