using WebAPI.Domain.Entities;

namespace WebAPI.Application.Abstractions.Interfaces
{
	public interface IJwtProvider
	{
		string GenerateToken(Member member);
	}
}
