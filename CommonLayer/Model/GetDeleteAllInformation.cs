using System.Collections.Generic;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    public class GetDeleteAllInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetDeleteAllInformation> getDeleteAllInformation { get; set; }
    }

    public class GetDeleteAllInformation
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        
        public string Gender { get; set; }
        public int Salary { get; set; }
    }
}
