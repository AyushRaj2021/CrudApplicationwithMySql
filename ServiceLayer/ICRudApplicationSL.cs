using CrudApplicationwithMySql.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.ServiceLayer
{
    public interface ICRudApplicationSL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
    }
}
