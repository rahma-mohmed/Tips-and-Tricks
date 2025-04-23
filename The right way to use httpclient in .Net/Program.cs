
using Microsoft.Extensions.Options;

namespace The_right_way_to_use_httpclient_in_.Net
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddHttpClient<GithubServices>("github", (serviceprovider, Httpclient) =>
			{
				// preconfigured httpclient with base address and headers
				var settings = serviceprovider.GetRequiredService<IOptions<GitHubSettings>>().Value;
				Httpclient.BaseAddress = new Uri("https://api.github.com");
				Httpclient.DefaultRequestHeaders.Add("User-Agent", settings.UserAgent);
				Httpclient.DefaultRequestHeaders.Add("Authorization", settings.AccessToken);
			});

			builder.Services.AddHttpClient("github", (serviceprovider, Httpclient) =>
			{
				// preconfigured httpclient with base address and headers
				var settings = serviceprovider.GetRequiredService<IOptions<GitHubSettings>>().Value;
				Httpclient.BaseAddress = new Uri("https://api.github.com");
				Httpclient.DefaultRequestHeaders.Add("User-Agent", settings.UserAgent);
				Httpclient.DefaultRequestHeaders.Add("Authorization", settings.AccessToken);
			}).ConfigurePrimaryHttpMessageHandler(() =>
			{
				return new SocketsHttpHandler()
				{
					// Configure the SocketsHttpHandler as needed
					// For example, you can set properties like PooledConnectionLifetime, MaxConnectionsPerServer, etc.
					PooledConnectionLifetime = TimeSpan.FromMinutes(5),
				};
			}).SetHandlerLifetime(Timeout.InfiniteTimeSpan);

			builder.Services.Configure<GitHubSettings>(builder.Configuration.GetSection("GitHubSettings"));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapUserEndPoints();

			app.Run();
		}
	}
}
