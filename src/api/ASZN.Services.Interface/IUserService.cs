using ASZN.Web.DTO.User;
using Microsoft.AspNetCore.Identity;

namespace ASZN.Services.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(UserCreateDto dto, CancellationToken cancellationToken);
        Task<bool> ValidateUserAsync(UserLoginDto dto, CancellationToken cancellationToken);
        Task<string> CreateTokenAsync(CancellationToken cancellationToken);
    }
}