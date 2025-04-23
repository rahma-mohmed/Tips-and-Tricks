namespace The_right_way_to_use_httpclient_in_.Net
{
	public class GitHubSettings
	{
		public string AccessToken { get; set; }    // GitHub Personal Access Token (PAT)
		public string UserAgent { get; set; }      // Required by GitHub API (e.g., your app name)
	}
}