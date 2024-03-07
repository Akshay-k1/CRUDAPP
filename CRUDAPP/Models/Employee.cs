using System.ComponentModel.DataAnnotations;

namespace CRUDAPP.Models
{
    public class Employee
    {

        public int eid {  get; set; }
        public string? ename {  get; set; }
        [Required(ErrorMessage = "Employee age is required.")]
        [Range(18, 100, ErrorMessage = "Employee age must be between {1} and {2}.")]
        public int eage { get; set; }
        public string? eadd{ get; set; }
        public string? ephone {  get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, ErrorMessage = "Username must be between {2} and {1} characters", MinimumLength = 5)]
        public string? eusername {  get; set; }
        [Required(ErrorMessage = "Password is required")]

        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password must be between {2} and {1} characters", MinimumLength = 8)]
        public string? epassword { get; set;}
    }
}
