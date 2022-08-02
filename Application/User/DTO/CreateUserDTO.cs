using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.User.DTO
{
    public class CreateUserDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Vatnumber { get; set; }
        public string? Email { get; set; }
    }
}
