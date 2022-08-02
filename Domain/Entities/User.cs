using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Vatnumber { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
    }
}
