using MainAssessment.DTO;
using MainAssessment.Tables;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface ICabin
    {
        IEnumerable<CabinTable> GetAllCabins();
        void AddCabin(CabinTableDTO cabinTableDTO);
        void AllocateEmployeeToCabin(CabinAllocationDTO cabinAllocationDTO);
        void DeallocateEmployeeFromCabin(CabinDeallocationDTO cabinDeallocationDTO);
        void RemoveCabin(int cabinId);
    }
}
