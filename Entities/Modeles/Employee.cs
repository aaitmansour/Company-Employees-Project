using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Modeles
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Empoyee name is required field.")]
        [MaxLength(30, ErrorMessage = "naem length is 39 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Emplyee age is required field.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Employee position is required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }

}
