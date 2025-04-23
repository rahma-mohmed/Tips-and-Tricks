using Microsoft.Extensions.Options;

namespace The_right_way_to_use_httpclient_in_.Net
{
	public static class UserEndPointsClass
	{
		public static void MapUserEndPoints(this IEndpointRouteBuilder app)
		{
			app.MapGet("/users/v5/{username}", async (string username, IGitHubApi githubServices) =>
			{
				var content = await githubServices.GetByUsernameAsync(username);

				return Results.Ok(content);
			});

			//using typed httpclient
			app.MapGet("/users/v4/{username}", async (string username, GithubServices githubServices) =>
			{
				var content = await githubServices.GetUserAsync(username);

				return Results.Ok(content);
			});

			app.MapGet("/users/v3/{username}", async (string username, IHttpClientFactory factory) =>
			{
				var client = factory.CreateClient("github"); //cached instance of httpclient

				var content = await client.GetFromJsonAsync<GitHubUser>($"users/{username}");

				return Results.Ok(content);
			});

			app.MapGet("/users/v2/{username}", async (string username, IHttpClientFactory factory, IOptions<GitHubSettings> settings) =>
			{
				var client = factory.CreateClient(); //cached instance of httpclient

				client.BaseAddress = new Uri("https://api.github.com");
				client.DefaultRequestHeaders.Add("User-Agent", settings.Value.AccessToken);
				client.DefaultRequestHeaders.Add("Authorization", settings.Value.UserAgent);

				var content = await client.GetFromJsonAsync<GitHubUser>($"users/{username}");

				return Results.Ok(content);
			});

			app.MapGet("/users/v1/{username}", async (string username, IOptions<GitHubSettings> settings) =>
			{
				//socketsHttpHandler is a low level handler that is used to create a HttpClient instance. It is not recommended to use it directly in production code because it is not thread safe.
				//Instead, you should use the IHttpClientFactory interface to create and manage HttpClient instances. This allows you to take advantage of features like connection pooling, automatic retries, and circuit breaking.
				var client = new HttpClient(); //incorrect way because it supposed to be long lived and reused throught the lifetime of app 

				client.BaseAddress = new Uri("https://api.github.com");
				client.DefaultRequestHeaders.Add("User-Agent", settings.Value.AccessToken);
				client.DefaultRequestHeaders.Add("Authorization", settings.Value.UserAgent);

				var content = await client.GetFromJsonAsync<GitHubUser>($"users/{username}");

				return Results.Ok(content);
			});
		}

	}
}
