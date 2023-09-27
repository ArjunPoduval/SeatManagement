using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class MeetingRoomTableService : IMeetingroom
    {
        private readonly IRepository<MeetingRoom> _meetingRoomTableRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public MeetingRoomTableService(IRepository<MeetingRoom> meetingRoomTableRepository, IRepository<Facility> facilityRepository)
        {
            _meetingRoomTableRepository = meetingRoomTableRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<MeetingRoom> GetAllMeetingRooms()
        {
            return _meetingRoomTableRepository.GetAll();
        }

        public void AddMeetingRoom(MeetingroomDTO meetingRoomTable)
        {
            //validation
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == meetingRoomTable.FacilityId))
            {
                throw new ObjectDoNotExist("Facility");
            }
            //check if the meeting room already exist
            if (_meetingRoomTableRepository.GetAll().Any(m => m.FacilityId == meetingRoomTable.FacilityId && m.MeetingRoomNumber == meetingRoomTable.MeetingRoomNumber))
            {
                throw new ObjectAlreadyExistException("Room number in Facility");
            }
            //adding meeting room
            MeetingRoom item = new()
            {
                FacilityId = meetingRoomTable.FacilityId,
                MeetingRoomNumber = meetingRoomTable.MeetingRoomNumber,
                TotalSeats = meetingRoomTable.TotalSeats
            };
            _meetingRoomTableRepository.Add(item);
            _meetingRoomTableRepository.Save();
        }

        public void UpdateMeetingRoom(int meetingRoomId, MeetingroomDTO updatedMeetingRoomTable)
        {
            //validation
            MeetingRoom meetingRoom = _meetingRoomTableRepository.GetById(meetingRoomId);
            if (meetingRoom == null)
            {
                throw new ObjectDoNotExist("MeetingRoom");
            }
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == updatedMeetingRoomTable.FacilityId))
            {
                throw new ObjectDoNotExist("Facility");
            }
            //check if the meeting room already exist
            if (_meetingRoomTableRepository.GetAll().Any(m => m.FacilityId == updatedMeetingRoomTable.FacilityId && m.MeetingRoomNumber == updatedMeetingRoomTable.MeetingRoomNumber && m.TotalSeats == updatedMeetingRoomTable.TotalSeats))
            {
                throw new ObjectAlreadyExistException("MeetingRoom");
            }

            // Update properties with new values
            meetingRoom.FacilityId = updatedMeetingRoomTable.FacilityId;
            meetingRoom.MeetingRoomNumber = updatedMeetingRoomTable.MeetingRoomNumber;
            meetingRoom.TotalSeats = updatedMeetingRoomTable.TotalSeats;

            _meetingRoomTableRepository.Update(meetingRoom);
            _meetingRoomTableRepository.Save();
        }

        public void RemoveMeetingRoom(int meetingRoomId)
        {
            MeetingRoom meetingRoom = _meetingRoomTableRepository.GetById(meetingRoomId);
            if (meetingRoom == null)
            {
                throw new ObjectDoNotExist("MeetingRoom");
            }
            else
            {
                _meetingRoomTableRepository.Remove(meetingRoom);
                _meetingRoomTableRepository.Save();
            }
        }
    }
}
