using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPI.Infrastructure.Authentication;

namespace WebAPI.App.OptionsSetUp
{
	public class JwtBearerOptionsSetup : IConfigureOptions<JwtBearerOptions>
	{
		private readonly JwtOptions _jwtOptions;

		public JwtBearerOptionsSetup(IOptions<JwtOptions> jwtOptions)
		{
			_jwtOptions = jwtOptions.Value;
		}
		public void Configure(JwtBearerOptions options)
		{
			options.TokenValidationParameters = new()
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key)),
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidIssuer = _jwtOptions.Issuer,
				ValidAudience = _jwtOptions.Audience,
			};
		}
	}
	{
	}
}
