using System.ComponentModel.DataAnnotations;
namespace AdressesSQLite
{
    public class Adress
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; } = String.Empty;

        [Required]
        [StringLength(50)]
        public string HouseNumber { get; set; } = String.Empty;

        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; } = String.Empty;

        [Required]
        [StringLength(50)]
        public string Country { get; set; } = String.Empty;

        [Required]
        [StringLength(50)]
        public string City { get; set; } = String.Empty;
    }
}
