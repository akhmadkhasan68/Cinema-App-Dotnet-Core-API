using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using CinemaApp.Dtos.Auth;
using CinemaApp.Dtos.User;
using CinemaApp.Infrastructures.Exceptions;
using CinemaApp.Interfaces.Repositories;
using CinemaApp.Interfaces.Services;
using CinemaApp.Mappers;
using CinemaApp.Utils.Helpers;
using Microsoft.IdentityModel.Tokens;

namespace CinemaApp.Services
{
    public class AuthService(
        IUserRepository userRepository, 
        IRoleRepository roleRepository
    ) : IAuthService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IRoleRepository _roleRepository = roleRepository;

        public async Task<AuthLoginResponseDto> LoginAsync(AuthLoginRequestDto authLoginRequestDto)
        {
            var findUserByEmail = await _userRepository.FindByEmailOrFailAsync(authLoginRequestDto.Email);

            bool checkPasswordIsValid = PasswordHelper.Verify(authLoginRequestDto.Password, findUserByEmail.Password);

            if (!checkPasswordIsValid)
            {
                throw new Infrastructures.Exceptions.UnauthorizedAccessException("Invalid credentials");
            }

            return new AuthLoginResponseDto
            {
                AccessToken = GenerateJwtToken(findUserByEmail),
                User = findUserByEmail.ToResponse(),
            };
        }

        public async Task<AsyncVoidMethodBuilder> RegisterAsync(UserRequestDto userRequestDto)
        {
            var roleIsExist = await _roleRepository.IsExist(userRequestDto.RoleId);

            if (!roleIsExist)
            {
                throw new DataNotFoundException("Role not found");
            }

            var findUserByEmail = await _userRepository.FindByEmailAsync(userRequestDto.Email);

            if (findUserByEmail != null)
            {
                throw new DataNotFoundException("Email already exists");
            }

            await _userRepository.CreateAsync(userRequestDto.ToModel());

            return AsyncVoidMethodBuilder.Create();
        }

        private static string GenerateJwtToken(UserDto user)
        {
            var configJwtSecretKey = AppSettingHelper.GetValue<string>("Jwt:Key");
            var expirationInMinutes = AppSettingHelper.GetValue<int>("Jwt:AccessExpirationInMinutes");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configJwtSecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Email),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: AppSettingHelper.GetValue<string>("Jwt:Issuer"),
                audience: AppSettingHelper.GetValue<string>("Jwt:Audience"),
                claims: userClaims,
                expires: DateTime.Now.AddMinutes(expirationInMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
