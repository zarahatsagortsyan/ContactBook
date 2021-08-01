using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Address_Book_Zevit.Models
{
    public class Contact
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string PhysicalAddress { get; set; }
    }
}
