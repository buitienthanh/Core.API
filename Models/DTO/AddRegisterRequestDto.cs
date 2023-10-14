using System.ComponentModel.DataAnnotations;

namespace NZWalk.API.Models.DTO
{
    public class AddRegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { set; get; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { set; get; }


        public string[] Roles { set; get; }
    }
}
