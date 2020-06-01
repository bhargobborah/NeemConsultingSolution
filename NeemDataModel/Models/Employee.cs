using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeemDataModel.Models
{
    /// <summary>
    /// Employee Model class
    /// </summary>
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Employee Name is required")]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "Position is required")]
        public string Position { get; set; }


        [Required(ErrorMessage = "Salary is required")]

        public decimal Salary { get; set; }


        public string Location { get; set; }
    }
}
