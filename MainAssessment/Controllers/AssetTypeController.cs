using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : Controller
    {
        private readonly IAssetType _assetTypeService;

        public AssetTypeController(IAssetType assetTypeService)
        {
            _assetTypeService = assetTypeService;
        }

        [HttpGet]
        public IActionResult GetAllAssetTypes()
        {
            return Ok(_assetTypeService.GetAllAssetTypes());
        }

        [HttpPost]
        public IActionResult CreateAssetType(AssetTypeCreation newAssetType)
        {
            try
            {
                _assetTypeService.AddAssetType(newAssetType);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAssetType(int id)
        {
            try
            {
                _assetTypeService.RemoveAssetType(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
