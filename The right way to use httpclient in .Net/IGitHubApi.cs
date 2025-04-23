using Refit;

namespace The_right_way_to_use_httpclient_in_.Net
{
	public interface IGitHubApi
	{
		[Get("/users/{username}")]
		Task<GitHubUser?> GetByUsernameAsync(string username);
	}
}
