using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Abstraction
{
	public interface IMemberRepository
	{
		Task<bool> IsEmailInUseAsync(string email, CancellationToken cancellationToken);
		Task<bool> IsUsernameInUseAsync(string username, CancellationToken cancellationToken);
		Task<bool> IsPhoneNumberInUseAsync(string phoneNumber, CancellationToken cancellationToken);
		Task<bool> IsMemberExistsAsync(Guid memberId, CancellationToken cancellationToken);
		Task<bool> IsMemberExistsByEmailAsync(string email, CancellationToken cancellationToken);
		Task<bool> IsMemberExistsByUsernameAsync(string username, CancellationToken cancellationToken);
		Task<bool> IsMemberExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken);
		Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken);
	}
}