using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface IMeetingroom
    {
        IEnumerable<MeetingRoomTable> GetAllMeetingRooms();
        void AddMeetingRoom(MeetingroomDTO meetingRoomTable);
        void UpdateMeetingRoom(int meetingRoomId, MeetingroomDTO updatedMeetingRoomTable);
        void RemoveMeetingRoom(int meetingRoomId);
    }
}
