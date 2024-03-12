using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
{
    public partial class Category
    {
        public Category()
        {
            Topics = new HashSet<Topic>();
        }

        public int CategoryId { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string CategoryName { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
    }
}
