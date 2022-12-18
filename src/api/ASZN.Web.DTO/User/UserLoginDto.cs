using System.ComponentModel.DataAnnotations;

namespace ASZN.Web.DTO.User
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}