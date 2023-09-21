using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public IActionResult Index()
        {
            return Ok(_assetsService.GetAllAssets());
        }

        [HttpPost]
        public IActionResult Create(AssetInsertionDTO assetsDTO)
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
        public IActionResult UpdateAssetDetails([FromRoute] int assetIndexId, int? meetingRoomId)
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
        [Route("{id}")]
        public async Task<IActionResult> Delete(int AssetIndexId)
        {
            try
            {
                _assetsService.RemoveAssets(AssetIndexId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
