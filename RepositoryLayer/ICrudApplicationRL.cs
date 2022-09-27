using CrudApplicationwithMySql.CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.RepositoryLayer
{
    public interface ICrudApplicationRL
    {
        public Task<AddInformationResponse> AddInformation(AddInformationRequest request);
        public Task<ReadAllInformationResponse> ReadAllInformation();
        public Task<UpdateAllInformationByIdResponse> UpdateAllInformationById(UpdateAllInformationByIdRequest request);
        public Task<DeleteInformationByIdResponse> DeleteInformationById(DeleteInformationByIdRequest request);
        public Task<GetDeleteAllInformationResponse> GetDeleteAllInformation();
        public Task<DeleteAllInActiveInformationResponse> DeleteAllInActiveInformation();
        public Task<ReadInformationByIdResponse> ReadInformationById(ReadInformationByIdRequest request);
    }
}
