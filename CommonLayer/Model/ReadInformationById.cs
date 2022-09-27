using System.ComponentModel.DataAnnotations;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    public class ReadInformationByIdRequest
    {
        [Required(ErrorMessage ="UserID is mandatory")]
        public int UserID { get; set; }
    }

    public class ReadInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ReadInformationByIdResponse Data { get; set; }   
    }
    public class ReadInformationById
    {
        public string UserName { get; set; }
        public string EmailID { get; set; }
        public int Salary { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }       
        public bool IsActive { get; set; }       
        
        
    }
}
