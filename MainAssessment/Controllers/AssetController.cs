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
            return  Ok(_assetsService.GetAllAssets());
        }

        [HttpPost]
        public IActionResult CreateAsset(AssetCreationDTO assetsDTO)
        {
            try
            {
                _assetsService.AddAssets(assetsDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("{assetIndexId}")]
        public IActionResult UpdateAssetDetails( int assetIndexId, int? meetingRoomId)
        {
            try
            {
                _assetsService.UpdateAssetDetails(assetIndexId, meetingRoomId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{assetIndexId}")]
        public async Task<IActionResult> DeleteAsset(int assetIndexId)
        {
            try
            {
                _assetsService.RemoveAssets(assetIndexId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
