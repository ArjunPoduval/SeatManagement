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
        private readonly IAssetType _assetLookupService;

        public AssetTypeController(IAssetType assetLookupService)
        {
            _assetLookupService = assetLookupService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_assetLookupService.GetAllAssetLookups());
        }

        [HttpPost]
        public IActionResult Create(string AssetName)
        {
            try
            {
                _assetLookupService.AddAssetLookup(AssetName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Update")]
        public IActionResult Update(int id, string assetname)
        {
            try
            {
                _assetLookupService.UpdateAssetLookup(id, assetname);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _assetLookupService.RemoveAssetLookup(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
