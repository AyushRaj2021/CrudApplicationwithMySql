using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.CommonLayer.Model
{
    
    public class AddInformationRequest
    {
        [Required(ErrorMessage ="Userfield is mandatory field")]
        public string UserName { get; set; }

        [Required]
        [RegularExpression("^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$",ErrorMessage = "EmailID not correct format")]
        public string EmailID { get; set; }

        [Required]
        [RegularExpression("([1-9]{1}[0-9]{9})$",ErrorMessage = "MobileNumber not correct format")]
        public string MobileNumber { get; set; }

        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Enter salary greater than zero")]
        public int Salary { get; set; }

        [Required]
        [RegularExpression("^(?:m|male|f|female)$",ErrorMessage ="Gender not in valid format")]
        public string Gender { get; set; }
    }
    public class AddInformationResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

    }
}
