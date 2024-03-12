using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models
{
    public partial class Favorite
    {
        public int FavId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int DogId { get; set; }

        [Range(1, 2, ErrorMessage = "Number must be 1 or 2")]
        public int IsAvailable { get; set; }

        public int ProfileId { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
