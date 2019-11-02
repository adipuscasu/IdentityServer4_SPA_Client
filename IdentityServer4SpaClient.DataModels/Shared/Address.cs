using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer4.DataModels.Shared
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string Locality { get; set; }
        public int PostalCode { get; set; }
        public Country Country { get; set; }
    }
}
