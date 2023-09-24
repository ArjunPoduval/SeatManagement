using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class MeetingRoomTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MeetingRoomId { get; set; }

        [ForeignKey("FacilityId")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        public int MeetingRoomNumber { get; set; }
        public int TotalSeats { get; set; }

    }
}
