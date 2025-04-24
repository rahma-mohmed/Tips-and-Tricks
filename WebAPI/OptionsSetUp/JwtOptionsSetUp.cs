using Microsoft.Extensions.Options;
using WebAPI.Infrastructure.Authentication;

namespace WebAPI.App.OptionsSetUp
{
	public class JwtOptionsSetUp : IConfigureOptions<JwtOptions>
	{
		private const string sectionName = "Jwt";
		private readonly IConfiguration _configuration;

		public JwtOptionsSetUp(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public void Configure(JwtOptions options)
		{
			_configuration.GetSection(sectionName).Bind(options);
		}
	}
}
