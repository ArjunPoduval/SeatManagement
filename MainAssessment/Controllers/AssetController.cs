using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : Controller
    {
        private readonly IAsset _assetsService;

        public AssetsController(IAsset assetsService)
        {
            _assetsService = assetsService;
        }
        [HttpGet]
        public IActionResult GetAllAssets()
        {
            return Ok(_assetsService.GetAllAssets());
        }

        [HttpPost]
        public IActionResult CreateAsset(AssetCreationDTO assetsDTO)
        {
            _assetsService.AddAssets(assetsDTO);
            return Ok();
        }


        [HttpPatch("{assetindexid}")]
        public IActionResult UpdateAssetDetails(int assetindexid, int? meetingRoomId)
        {
            try
            {
                _assetsService.UpdateAssetDetails(assetindexid, meetingRoomId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{assetindexid}")]
        public async Task<IActionResult> DeleteAsset(int assetindexid)
        {
            _assetsService.RemoveAssets(assetindexid);
            return Ok();
        }
    }
}
