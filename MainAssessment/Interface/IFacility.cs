﻿using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IFacility
    {
        IEnumerable<Facility> GetAll();
        void AddFacility(FacilityDTO facility);
        void RemoveFacility(int FacilityId);
    }
}
