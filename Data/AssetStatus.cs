using System.ComponentModel.DataAnnotations;

namespace Asset_Management_Sciforn.Data
{
    public class AssetStatus
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string StatusName { get; set; }
    }
}

