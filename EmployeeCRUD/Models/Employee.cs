using EmployeeCRUD.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter valid email id.")]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 12)]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please enter education.")]
        [EducationValidate(Allowed = new string[] { "Bachelor", "Master" }, ErrorMessage = "Education must be either Bachelor or Master.")]
        public string Education { get; set; }

        [Range(1, 10)]
        public int YearsOfExperience { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Salary { get; set; }

    }
}
