using CrudApplicationwithMySql.CommonLayer.Model;
using CrudApplicationwithMySql.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApplicationContoller : ControllerBase
    {

        public readonly ICRudApplicationSL _crudApplicationSL;
        public readonly ILogger<CrudApplicationContoller> _logger;

        public CrudApplicationContoller(ICRudApplicationSL crudApplicationSL, ILogger<CrudApplicationContoller> logger)
        {
            _crudApplicationSL = crudApplicationSL;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformationAsync(AddInformationRequest request )
        {
            AddInformationResponse response = new AddInformationResponse();
            _logger.LogInformation($"AddInformation API Calling in controller...{JsonConvert.SerializeObject(request)}");

            try 
            {
                response = await _crudApplicationSL.AddInformation(request);
                
                if(!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }

        [HttpPost]
        public async Task<IActionResult> ReadAllInformationAsync()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            _logger.LogInformation($"AddInformation API Calling in controller...");

            try
            {
                response = await _crudApplicationSL.ReadAllInformation(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"AddInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }
    }
}
