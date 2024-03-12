using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

#nullable disable

namespace Models
{
    public partial class Topic
    {
        public Topic()
        {
            Replies = new HashSet<Reply>();
        }

        public int TopicId { get; set; }

        [Required]
        [Display(Name = "Topic Name")]
        public string TopicName { get; set; }

        [Required]
        [Display(Name = "Topic Body")]
        public string TopicBody { get; set; }

        public int? ProfileId { get; set; }
        
        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? PostTimestamp { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
    }
}
