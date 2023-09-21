using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingroomController : Controller
    {
        private readonly IMeetingroom _meetingRoomTableService;

        public MeetingroomController(IMeetingroom meetingRoomTableService)
        {
            _meetingRoomTableService = meetingRoomTableService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_meetingRoomTableService.GetAllMeetingRooms());
        }

        [HttpPost]
        public IActionResult Create(MeetingroomDTO meetingRoomTableDTO)
        {
            try
            {
                _meetingRoomTableService.AddMeetingRoom(meetingRoomTableDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, MeetingroomDTO updatedMeetingRoomTable)
        {
            try
            {
                _meetingRoomTableService.UpdateMeetingRoom(id, updatedMeetingRoomTable);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _meetingRoomTableService.RemoveMeetingRoom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
