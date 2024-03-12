using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Models
{
    public partial class Reply
    {
        public int ReplyId { get; set; }

        [Required]
        [Display(Name = "Reply Body")]
        public string ReplyMessage { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ReplyTimestamp { get; set; }
        public int? ProfileId { get; set; }
        public int? TopicId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
