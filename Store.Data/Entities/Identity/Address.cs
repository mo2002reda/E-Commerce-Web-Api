using System.ComponentModel.DataAnnotations;

namespace Store.Data.Entities.Identity
{
    public class Address
    {
        public long id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public AppUser UserId { get; set; }
        [Required]
        public string AppUserId { get; set; }
    }
}