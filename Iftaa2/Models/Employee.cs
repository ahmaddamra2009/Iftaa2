using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Iftaa2.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage ="Please Enter Employee Name")]
        [MaxLength(20,ErrorMessage ="Your name too long")]
        [MinLength(4,ErrorMessage ="your name is too short")]
        [Display(Name ="Employee name")]
        public string EmployeeName { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email Address")]
        [Required(ErrorMessage ="Please Enter Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please Enter Salary")]
        public decimal Salary { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please Enter hiring Date")]
        public DateTime HireDate { get; set; }
        [EnumDataType(typeof(Gender))]
        [Required]
        public Gender Gender { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }

    }
    public enum Gender
    {
        Male, Female
    }
}
