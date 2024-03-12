using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
{
    public partial class Dwelling
    {
        public Dwelling()
        {
            Profiles = new HashSet<Profile>();
        }

        public int DwellingId { get; set; }

        [Required]
        [Display(Name = "Dwelling Type")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Dwelling Type")]
        public string DwellingType { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
