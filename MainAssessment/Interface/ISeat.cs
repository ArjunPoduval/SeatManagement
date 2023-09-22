using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface ISeat
    {
        IEnumerable<Seat> GetAllSeats();
        void AddSeat(SeatTableDTO seatTable);
        void UpdateSeatDetail(int seatId,int? employeeId);
        void RemoveSeat(int seatId);
    }
}
