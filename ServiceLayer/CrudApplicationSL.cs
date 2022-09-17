using CrudApplicationwithMySql.CommonLayer.Model;
using CrudApplicationwithMySql.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.ServiceLayer
{
    public class CrudApplicationSL : ICRudApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;

        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL)
        {
            _crudApplicationRL = crudApplicationRL;
        }

        public async Task<AddInformationResponse> AddInformation(AddInformationRequest request)
        {
            AddInformationResponse response = new AddInformationResponse();
            if (String.IsNullOrEmpty(request.UserName))
            {
                response.IsSuccess = false;
                response.Message = "UserName can't Null or Empty";
                return response;
            }
            if (String.IsNullOrEmpty(request.EmailID))
            {
                response.IsSuccess = false;
                response.Message = "EmailID can't Null or Empty";
                return response;
            }
            if (String.IsNullOrEmpty(request.MobileNumber))
            {
                response.IsSuccess = false;
                response.Message = "MobileNumber can't Null or Empty";
                return response;
            }
            if (request.Salary<=0)
            {
                response.IsSuccess = false;
                response.Message = "Salary can't less than 0";
                return response;
            }
            if (String.IsNullOrEmpty(request.Gender))
            {
                response.IsSuccess = false;
                response.Message = "Gender can't Null or Empty";
                return response;
            }
            return await _crudApplicationRL.AddInformation(request);
        }
    }
}
