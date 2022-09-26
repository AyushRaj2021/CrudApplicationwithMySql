using System.ComponentModel.DataAnnotations;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    public class DeleteInformationByIdRequest
    {
        [Required(ErrorMessage ="UserId is Required")]
        public int UserID { get; set; }
    }

    public class DeleteInformationByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
