using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.Tables
{
    public class Assets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IndexId { get; set; }

        [ForeignKey("Fecility")]
        public int FacilityId { get; set; }
        public virtual Facility Facility { get; set; }
        
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public virtual AssetType Asset { get; set; }

        [ForeignKey("MeetingRoom")]
        //[DefaultValue(null)]
        public int? MeetingRoomId { get; set; }
        public virtual MeetingRoomTable? MeetingRoom { get; set; }


    }
}
