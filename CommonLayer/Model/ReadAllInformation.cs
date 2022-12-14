using System.Collections.Generic;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    public class ReadAllInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<GetReadAllInformation> readAllInformation { get; set; }

    }
    public class GetReadAllInformation
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public string MobileNumber { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }
    }
}
