using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Address
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string? Address1 { get; set; }
        public int? Number { get; set; }
        public string? City { get; set; }
        public string? Postalcode { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
