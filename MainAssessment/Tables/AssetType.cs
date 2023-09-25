using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class AssetType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssetId { get; set; }

        public string AssetName { get; set; }
    }
}
