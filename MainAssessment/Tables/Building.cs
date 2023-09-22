using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class Building
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BuildingId { get; set; }
        public string BuildingAbbreviation { get; set; }

        public string BuildingName { get; set; }

        [ForeignKey("CityLookup")]
        public int CityId { get; set; }
        public virtual City CityLookup { get; set; }
    }
}
