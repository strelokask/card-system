using ASZN.DAL;
using ASZN.DomainModel;
using ASZN.Services.Interface;
using ASZN.Web.DTO.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASZN.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private User? _user;
        public UserService(UserManager<User> userManager, IConfiguration configuration, IMapper mapper)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserCreateDto dto, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(dto);

            user.CreatedAt = DateTimeOffset.UtcNow;
            user.LastLoginAt = DateTimeOffset.UtcNow;
            user.LastPasswordChangedAt = DateTimeOffset.UtcNow;

            return await _userManager.CreateAsync(user, dto.Password);
        }

        public async Task<bool> ValidateUserAsync(UserLoginDto dto, CancellationToken cancellationToken)
        {
            _user = await _userManager.FindByNameAsync(dto.UserName);
            var isValid = _user != null && await _userManager.CheckPasswordAsync(_user, dto.Password);

            return isValid;
        }

        public async Task<string> CreateTokenAsync(CancellationToken cancellationToken)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtConfig = _configuration.GetSection("JWT");
            var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["ValidIssuer"],
                audience: jwtSettings["ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}