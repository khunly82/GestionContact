using System.ComponentModel.DataAnnotations;

namespace GestionContact.Models
{
    public class AddAddressForm
    {
        public string Street { get; set; } = null!;

        [RegularExpression(@"\d+")]
        public string Number { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
