using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace Xlogia.Domain.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter employee name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter age")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Age { get; set; }
    }
}
