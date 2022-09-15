using CrudApplicationwithMySql.CommonLayer.Model;
using CrudApplicationwithMySql.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudApplicationContoller : ControllerBase
    {

        public readonly ICRudApplicationSL _crudApplicationSL;

        public CrudApplicationContoller(ICRudApplicationSL crudApplicationSL)
        {
            _crudApplicationSL = crudApplicationSL;
        }

        [HttpPost]
        public IActionResult AddInformation(AddInformationRequest request )
        {
            AddInformationResponse response = new AddInformationResponse();
            try 
            { 
            }
            catch(Exception ex)
            {

            }
            return Ok();
        }
    }
}
