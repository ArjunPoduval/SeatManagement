using MainAssessment.DTO;
using MainAssessment.Tables;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface ICabin
    {
        IEnumerable<Cabin> GetAllCabins();
        void AddCabin(CabinTableDTO cabinTableDTO);
        void UpdateCabinDetail(int cabinId, int? employeeId);
        void RemoveCabin(int cabinId);
    }
}
