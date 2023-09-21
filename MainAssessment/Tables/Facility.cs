using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class Facility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacilityId { get; set; }

        [ForeignKey("building")]
        public int BuildingId { get; set; }
        public virtual Building building { get; set; }

        public int Floor { get; set; }
        public string FacilityName { get; set; }
    }
}
