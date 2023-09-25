using MainAssessment.CustomException;
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
        public IActionResult GetAllMeetingRooms()
        {
            return Ok(_meetingRoomService.GetAllMeetingRooms());
        }

        [HttpPost]
        public IActionResult CreateMeetingRoom(MeetingroomDTO meetingRoomTableDTO)
        {
            try
            {
                _meetingRoomService.AddMeetingRoom(meetingRoomTableDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeetingRoom(int id, MeetingroomDTO updatedMeetingRoomTable)
        {
            try
            {
                _meetingRoomService.UpdateMeetingRoom(id, updatedMeetingRoomTable);
                return Ok();
            }
            catch (ObjectAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMeetingRoom(int id)
        {
            try
            {
                _meetingRoomService.RemoveMeetingRoom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
