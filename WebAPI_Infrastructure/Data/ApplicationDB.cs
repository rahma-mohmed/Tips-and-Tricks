using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPI.Infrastructure.Data
{
	public class ApplicationDB : IdentityDbContext
	{
		//public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
		//{
		//}
		////public DbSet<Member> Members { get; set; }
		////public DbSet<RefreshToken> RefreshTokens { get; set; }
		////public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
		////public DbSet<EmailVerificationToken> EmailVerificationTokens { get; set; }
		////public DbSet<PhoneVerificationToken> PhoneVerificationTokens { get; set; }
		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	base.OnModelCreating(modelBuilder);
		//	modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDB).Assembly);
		//}
	}
}
