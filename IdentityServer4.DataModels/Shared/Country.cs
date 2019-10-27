using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityServer4.DataModels.Shared
{
    public class Country : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
