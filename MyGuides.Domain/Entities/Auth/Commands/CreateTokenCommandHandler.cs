using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyGuides.Domain.Entities.Auth.Results; 
using MyGuides.Notifications.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyGuides.Domain.Entities.Auth.Commands
{
    public class CreateTokenCommandHandler : IRequestHandler<CreateTokenCommand, AuthResult>
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration; 
        public CreateTokenCommandHandler(INotificationService notificationService, IMapper mapper, UserManager<IdentityUser> userManager, IConfiguration configuration) 
        { 
            _notificationService = notificationService; 
            _mapper = mapper; 
            _userManager = userManager; 
            _configuration = configuration;
        }
        public async Task<AuthResult> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.UserName))
                return default;
            if (string.IsNullOrEmpty(request.Password))
                return default;
            var expiration = DateTime.UtcNow.AddMinutes(1440);
            
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
                return default;

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
                return default;


            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return _mapper.Map<AuthResult>(new AuthResult
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            }); 
        }
        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private Claim[] CreateClaims(IdentityUser user) =>
            new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
