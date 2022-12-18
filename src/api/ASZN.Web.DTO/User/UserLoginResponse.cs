using System.ComponentModel.DataAnnotations;

namespace ASZN.Web.DTO.User
{
    public class UserLoginResponse
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
}