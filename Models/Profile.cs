using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Models
{
    public partial class Profile
    {
        public Profile()
        {
            Favorites = new HashSet<Favorite>();
            Replies = new HashSet<Reply>();
            Topics = new HashSet<Topic>();
        }

        public int ProfileId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [RegularExpression(@"^[a-zA-Z0-9. ,-]+$", ErrorMessage = "Invalid address")]
        public string ProfileStreetaddress { get; set; }

        [Required]
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid City")]
        public string ProfileCity { get; set; }

        public int ProfileStateid { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ProfileZipcode { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int ProfileAge { get; set; }

        
        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string ProfileHomephone { get; set; }

        [Required]
        [Display(Name = "Personal Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string ProfilePersonalphone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [RegularExpression(@"^[a-zA-Z0-9.+-@]+$", ErrorMessage = "Invalid email")]
        public string ProfileEmail { get; set; }

        [Required]
        [Display(Name = "Occupation")]
        public string ProfileOccupation { get; set; }

        
        [Display(Name = "Spouse Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileSpousename { get; set; }
        
        [Required]
        [Range(1, 2, ErrorMessage = "Number must be 1 or 2")]
        public int ProfileChildren { get; set; }

        
        public int ProfileDwellingid { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Number must be 1 or 2")]
        public int ProfileHasyard { get; set; }

        
        [Display(Name = "Name")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileLandlordname { get; set; }

        [Display(Name = "Phone")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid phone number")]
        public string ProfileLandlordphone { get; set; }

        
        [Display(Name = "OtherPetName")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileOtherpetname { get; set; }

        
        [Display(Name = "Breed")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileOtherpetbreed { get; set; }

        [Display(Name = "Gender of Pet")]
        //1 for male 2 for female when asked on the form for the sex of the pet
        [RegularExpression(@"^[mf]+$", ErrorMessage = "m or f")]
        public string ProfileOtherpetsex { get; set; }

        [Display(Name = "Other Pet Age")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid age")]
        public int? ProfileOtherpetage { get; set; }

        [Required]
        [Range(1, 2, ErrorMessage = "Number must be 1 or 2")]
        //1 for true 2 for fale
        public int ProfileFamilyallergies { get; set; }

        [Required]
        [Display(Name = "Name Responsible ")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid name")]
        public string ProfileResponsiblefordog { get; set; }

        [Required]
        [Display(Name = "Reason")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Reason")]
        public string ProfileAdoptionreason { get; set; }

        [Required]
        [Display(Name = "Pet Sleep")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Sleep")]
        public string ProfileDogsleepat { get; set; }

        [Required]
        [Display(Name = "Aggressive Reason")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Aggressive Reason")]
        public string ProfileDogaggresive { get; set; }

        [Required]
        [Display(Name = "Profile Med")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Input")]
        public string ProfileMedfordog { get; set; }

        [Required]
        [Display(Name = "No Care")]
        [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Invalid Input")]
        public string ProfileNocaredog { get; set; }

        
        public virtual Dwelling ProfileDwelling { get; set; }

        
        public virtual State ProfileState { get; set; }

        
        public virtual ICollection<Favorite> Favorites { get; set; }

        
        public virtual ICollection<Reply> Replies { get; set; }

        
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
