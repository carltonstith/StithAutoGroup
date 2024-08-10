using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StithAutoGroup.Models.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            CreationDate = DateTime.Now;
        }

        [PersonalData]
        public string? FirstName { get; set; }

        [PersonalData]
        public string? LastName { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime CreationDate { get; set; }

        public int AutoGroupRole { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        //public virtual int ReferenceID { get; private set; }
        protected int ReferenceID { get; set; }
    }
}
