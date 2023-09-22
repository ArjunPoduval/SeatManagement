using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly ICabin _cabinTableService;

        public CabinController(ICabin cabinTableService)
        {
            _cabinTableService = cabinTableService;
        }

        [HttpGet]
        public IActionResult GetAllCabins()
        {
            try
            {
                var cabins = _cabinTableService.GetAllCabins();
                return Ok(cabins);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddCabin(CabinTableDTO cabinTableDTO)
        {
            try
            {
                _cabinTableService.AddCabin(cabinTableDTO);
                return Ok("Cabin added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPatch]
        [Route("{cabinId}")]
        public IActionResult UpdateCabin(int cabinId,int? employeeId)
        {
            try
            {
                _cabinTableService.UpdateCabinDetail(cabinId,employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("{cabinId}")]
        public IActionResult RemoveCabin(int cabinId)
        {
            try
            {
                _cabinTableService.RemoveCabin(cabinId);
                return Ok("Cabin removed successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
