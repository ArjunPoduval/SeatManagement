using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingroomController : Controller
    {
        private readonly IMeetingroom _meetingRoomService;

        public MeetingroomController(IMeetingroom meetingRoomTableService)
        {
            _meetingRoomService = meetingRoomTableService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetingRooms()
        {
            return Ok(_meetingRoomService.GetAllMeetingRooms());
        }

        [HttpPost]
        public IActionResult CreateMeetingRoom(MeetingroomDTO meetingRoomTableDTO)
        {
            _meetingRoomService.AddMeetingRoom(meetingRoomTableDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeetingRoom(int id, MeetingroomDTO updatedMeetingRoomTable)
        {
            _meetingRoomService.UpdateMeetingRoom(id, updatedMeetingRoomTable);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(int id)
        {
            _meetingRoomService.RemoveMeetingRoom(id);
            return Ok();
        }
    }
}
