namespace The_right_way_to_use_httpclient_in_.Net
{
	public sealed class GithubServices
	{
		private readonly HttpClient _client;

		public GithubServices(HttpClient client)
		{
			_client = client;
		}

		public async Task<GitHubUser?> GetUserAsync(string username)
		{
			var content = await _client.GetFromJsonAsync<GitHubUser>($"users/{username}");
			return content;
		}
	}
}
