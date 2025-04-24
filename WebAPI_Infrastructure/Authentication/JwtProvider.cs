using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Authentication
{
	internal sealed class JwtProvider : IJwtProvider
	{
		private readonly JwtOptions _jwtOptions;

		public JwtProvider(IOptions<JwtOptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}

		public string Generate(Member member)
		{
			// Create claims
			var claims = new Claim[] {
				new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
				new Claim(ClaimTypes.Email, member.Email),
			};

			var token = new JwtSecurityToken(
				issuer: _jwtOptions.Issuer,
				audience: _jwtOptions.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddHours(1),
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
					SecurityAlgorithms.HmacSha256)
			);

			string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

			return tokenString;
		}
	}
}
