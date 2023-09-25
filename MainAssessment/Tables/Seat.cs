using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatId { get; set; }

        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public int SeatNumber { get; set; }
        /*[DefaultValue(null)]*/
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }

    }
}
