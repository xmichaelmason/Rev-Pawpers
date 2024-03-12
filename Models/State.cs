using System;
using System.Collections.Generic;

#nullable disable

namespace Models
{
    public partial class State
    {
        public State()
        {
            Profiles = new HashSet<Profile>();
        }

        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
