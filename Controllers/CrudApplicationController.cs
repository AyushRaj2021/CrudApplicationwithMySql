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
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CrudApplicationController : ControllerBase
    {

        public readonly ICRudApplicationSL _crudApplicationSL;
        public readonly ILogger<CrudApplicationController> _logger;

        public CrudApplicationController(ICRudApplicationSL crudApplicationSL, ILogger<CrudApplicationController> logger)
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


        [HttpGet]
        public async Task<IActionResult> ReadAllInformation()
        {
            ReadAllInformationResponse response = new ReadAllInformationResponse();
            _logger.LogInformation($"AddInformation API Calling in controller...");

            try
            {
                response = await _crudApplicationSL.ReadAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message ,Data = response.readAllInformation });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"ReadAllInformation API Error Occurs : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message , Data = response.readAllInformation });
        }


        [HttpPut]
        public async Task<IActionResult>UpdateAllInformationById(UpdateAllInformationByIdRequest request)
        {
            UpdateAllInformationByIdResponse response = new UpdateAllInformationByIdResponse();
            _logger.LogInformation($"UpdateAllInformationById API Calling in controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.UpdateAllInformationById(request);

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


        [HttpDelete]
        public async Task<IActionResult> DeleteInformationById(DeleteInformationByIdRequest request)
        {
            DeleteInformationByIdResponse response = new DeleteInformationByIdResponse();
            _logger.LogInformation($"DeleteInformationById API Calling in controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.DeleteInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"DeleteInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }


        [HttpGet]
        public async Task<IActionResult> GetDeleteAllInformation()
        {
            GetDeleteAllInformationResponse response = new GetDeleteAllInformationResponse();
            _logger.LogInformation($"GetDeleteAllInformation API Calling in controller...");

            try
            {
                response = await _crudApplicationSL.GetDeleteAllInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getDeleteAllInformation });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"GetDeleteAllInformation API Error Occurs : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message, Data = response.getDeleteAllInformation });
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAllInActiveInformation()
        {
            DeleteAllInActiveInformationResponse response = new DeleteAllInActiveInformationResponse();
            _logger.LogInformation($"DeleteAllInActiveInformation API Calling in controller..");

            try
            {
                response = await _crudApplicationSL.DeleteAllInActiveInformation();

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"DeleteAllInActiveInformation API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }


        [HttpPost]
        public async Task<IActionResult> ReadInformationById(ReadInformationByIdRequest request)
        {
            ReadInformationByIdResponse response = new ReadInformationByIdResponse();
            _logger.LogInformation($"ReadInformationById API Calling in controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.ReadInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"ReadInformationById API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message , data=response.Data});
        }


        [HttpPatch]
        public async Task<IActionResult> UpdateOneInformationById(UpdateOneInformationByIdRequest request)
        {
            UpdateOneInformationByIdResponse response = new UpdateOneInformationByIdResponse();
            _logger.LogInformation($"UpdateOneInformationById API Calling in controller...{JsonConvert.SerializeObject(request)}");

            try
            {
                response = await _crudApplicationSL.UpdateOneInformationById(request);

                if (!response.IsSuccess)
                {
                    return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logger.LogError($"UpdateOneInformationById API Error Occur : Message {ex.Message}");
                return BadRequest(new { IsSuccess = response.IsSuccess, Message = response.Message });
            }
            return Ok(new { IsSuccess = response.IsSuccess, Message = response.Message });
        }
    }
}
