using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface ISeat
    {
        IEnumerable<Seat> GetAllSeats();
        void AddSeat(SeatDTO seatTable);
        void UpdateSeatDetail(int seatId, int? employeeId);
        void RemoveSeat(int seatId);
    }
}
