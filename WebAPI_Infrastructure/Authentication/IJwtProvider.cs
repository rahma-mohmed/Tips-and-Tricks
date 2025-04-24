using WebAPI.Domain.Entities;

namespace WebAPI.Infrastructure.Authentication
{
	public interface IJwtProvider
	{
		string Generate(Member member);
	}
}