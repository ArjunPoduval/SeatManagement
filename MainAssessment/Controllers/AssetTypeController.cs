using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

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
            _assetTypeService.AddAssetType(newAssetType);
            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAssetType(int id)
        {
            _assetTypeService.RemoveAssetType(id);
            return Ok();
        }
    }
}
