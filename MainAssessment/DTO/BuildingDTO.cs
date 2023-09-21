using MainAssessment.Tables;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.DTO
{
    public class BuildingDTO
    {
        public string BuildingAbbreviation { get; set; }

        public string BuildingName { get; set; }

        public int CityId { get; set; }
    }
}
