using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.Contracts.Models
{
    public class Persons
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Position { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int Days { get; set; }
        public string Base64 { get; set; }
    }
}
