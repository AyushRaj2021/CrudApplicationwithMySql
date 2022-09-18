using CrudApplicationwithMySql.CommonLayer.Model;
using CrudApplicationwithMySql.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.ServiceLayer
{
    public class CrudApplicationSL : ICRudApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;
        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string MobileRegex = @"([1-9]{1}[0-9]{9})$";
        public readonly string GenderRegex = @"^(?:m|M|male|Male|f|F|female|Female)$";

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
            else
            {
                if(!(Regex.IsMatch(request.EmailID,EmailRegex)))
                {
                    response.IsSuccess = false;
                    response.Message = "EmailID not correct format. Try following: ayush@gmail.com";
                    return response;
                }
            }

            if (String.IsNullOrEmpty(request.MobileNumber))
            {
                response.IsSuccess = false;
                response.Message = "MobileNumber can't Null or Empty";
                return response;
            }
            else
            {
                if (!(Regex.IsMatch(request.MobileNumber, MobileRegex)))
                {
                    response.IsSuccess = false;
                    response.Message = "MobileNumber not correct format";
                    return response;
                }
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
            else
            {
                if (!(Regex.IsMatch(request.Gender.ToLower(), GenderRegex)))
                {
                    response.IsSuccess = false;
                    response.Message = "Gender not correct format.";
                    return response;
                }
            }

            return await _crudApplicationRL.AddInformation(request);
        }
    }
}
