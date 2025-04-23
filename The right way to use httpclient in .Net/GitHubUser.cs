namespace The_right_way_to_use_httpclient_in_.Net
{
	public class GitHubUser
	{
		public string Login { get; set; }          // GitHub username
		public int Id { get; set; }               // GitHub user ID
		public string Avatar_Url { get; set; }     // URL of the user's avatar
		public string Html_Url { get; set; }       // GitHub profile URL
		public string Name { get; set; }          // Full name of the user
		public string Company { get; set; }        // User's company
		public string Blog { get; set; }           // User's website/blog
		public string Location { get; set; }       // User's location
		public string Email { get; set; }          // User's email
		public string Bio { get; set; }            // User's bio
		public int Public_Repos { get; set; }      // Number of public repositories
		public int Followers { get; set; }         // Number of followers
		public int Following { get; set; }         // Number of users followed
		public DateTime Created_At { get; set; }   // Account creation date
		public DateTime Updated_At { get; set; }   // Last update date
	}
}