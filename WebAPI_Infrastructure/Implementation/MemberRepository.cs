using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Abstraction;

namespace WebAPI.Infrastructure.Implementation
{
	public class MemberRepository : IMemberRepository
	{
		public Task<bool> IsEmailInUseAsync(string email, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public Task<bool> IsUsernameInUseAsync(string username, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public Task<bool> IsPhoneNumberInUseAsync(string phoneNumber, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public Task<bool> IsMemberExistsAsync(Guid memberId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public Task<bool> IsMemberExistsByEmailAsync(string email, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public Task<bool> IsMemberExistsByUsernameAsync(string username, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public async Task<bool> IsMemberExistsByPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		public async Task<Member> GetByEmailAsync(string email, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
