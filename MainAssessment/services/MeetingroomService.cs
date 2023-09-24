using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class MeetingRoomTableService : IMeetingroom
    {
        private readonly IRepository<MeetingRoomTable> _meetingRoomTableRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public MeetingRoomTableService(IRepository<MeetingRoomTable> meetingRoomTableRepository, IRepository<Facility> facilityRepository)
        {
            _meetingRoomTableRepository = meetingRoomTableRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<MeetingRoomTable> GetAllMeetingRooms()
        {
            return _meetingRoomTableRepository.GetAll();
        }

        public void AddMeetingRoom(MeetingroomDTO meetingRoomTable)
        {
        //validation
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == meetingRoomTable.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the meeting room already exist
            if (_meetingRoomTableRepository.GetAll().Any(m => m.FacilityId == meetingRoomTable.FacilityId && m.MeetingRoomNumber==meetingRoomTable.MeetingRoomNumber))
            {
                throw new Exception("This Facility already has a meeting room with same meeting room number.");
            }
        //adding meeting room
            var item = new MeetingRoomTable()
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
            var meetingRoom = _meetingRoomTableRepository.GetById(meetingRoomId);
            if (meetingRoom == null)
            {
                throw new Exception("The MeetingRoom record does not exist.");
            }
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == updatedMeetingRoomTable.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the meeting room already exist
            if (_meetingRoomTableRepository.GetAll().Any(m => m.FacilityId == updatedMeetingRoomTable.FacilityId && m.MeetingRoomNumber == updatedMeetingRoomTable.MeetingRoomNumber && m.TotalSeats == updatedMeetingRoomTable.TotalSeats))
            {
                throw new ObjectAlreadyExistException();
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
            var meetingRoom = _meetingRoomTableRepository.GetById(meetingRoomId);
            if (meetingRoom == null)
            {
                throw new Exception("The MeetingRoom record does not exist.");
            }
            else
            {
                _meetingRoomTableRepository.Remove(meetingRoom);
                _meetingRoomTableRepository.Save();
            }
        }
    }
}
