using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IMeetingroom
    {
        IEnumerable<MeetingRoom> GetAllMeetingRooms();
        void AddMeetingRoom(MeetingroomDTO meetingRoomTable);
        void UpdateMeetingRoom(int meetingRoomId, MeetingroomDTO updatedMeetingRoomTable);
        void RemoveMeetingRoom(int meetingRoomId);
    }
}
