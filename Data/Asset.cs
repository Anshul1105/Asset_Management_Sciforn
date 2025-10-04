using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Asset_Management_Sciforn.Data;

namespace Asset_Management_Sciforn.Data
{
    public class Asset
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Asset Name is required.")]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Asset Type is required.")]
        [MaxLength(100)]
        public string AssetType { get; set; } = string.Empty;

        [MaxLength(150)]
        public string? MakeModel { get; set; }

        [MaxLength(100)]
        public string? SerialNumber { get; set; }

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public DateTime? WarrantyExpiryDate { get; set; }

        [Required(ErrorMessage = "Asset Condition is required.")]
        public int AssetConditionId { get; set; }

        [Required(ErrorMessage = "Asset Status is required.")]
        public int AssetStatusId { get; set; }

        public bool IsSpare { get; set; } = false;

        [MaxLength(500)]
        public string? Specifications { get; set; }

        [ForeignKey("AssetConditionId")]
        public AssetCondition AssetCondition { get; set; }

        [ForeignKey("AssetStatusId")]
        public AssetStatus AssetStatus { get; set; }

        public ICollection<AssetAssigned> AssetAssignments { get; set; }
    }
}
