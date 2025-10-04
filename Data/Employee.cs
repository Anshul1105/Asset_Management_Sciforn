using System.ComponentModel.DataAnnotations;

namespace Asset_Management_Sciforn.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required.")]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(15)]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string? Designation { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;
        public ICollection<AssetAssigned> AssetAssignments { get; set; }
    }
}
