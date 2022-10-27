using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modeles
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Company name is required field.")]
        [MaxLength(60, ErrorMessage = "Company name has Malenght 60. ")]
        public string? name { get; set; }
        
        [Required(ErrorMessage = "company Adresse is Required field. ")]
        [MaxLength(80, ErrorMessage = "Company adresse have 60 character.")]
        public string? adresse { get; set; }

        public string? country { get; set; }

        public ICollection<Employee>? Employees { get; set; }

    }
}
