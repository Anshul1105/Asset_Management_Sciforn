using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asset_Management_Sciforn.Data
{
    public class AssetAssigned
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AssetId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime AssignedDate { get; set; }

        [ForeignKey("AssetId")]
        public Asset Asset { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
