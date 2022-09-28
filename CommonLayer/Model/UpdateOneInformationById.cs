using System.ComponentModel.DataAnnotations;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    public class UpdateOneInformationByIdRequest
    {
        [Required(ErrorMessage="UserId is mandatory")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Salary is mandatory")]
        public int Salary { get; set; } 
    }

    public class UpdateOneInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
