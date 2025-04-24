using WebAPI.Application.Abstractions.Common;
using WebAPI.Application.Abstractions.Interfaces;
using WebAPI.Domain.Entities;
using WebAPI.Infrastructure.Abstraction;
using WebAPI_Application.Members.Login;

namespace WebAPI.Application.Members.Login
{
	internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, Result<string>>
	{
		private readonly IMemberRepository _memberRepository;
		private readonly IJwtProvider _jwtTokenProvider;

		public LoginCommandHandler(IMemberRepository memberRepository, IJwtProvider jwtTokenProvider)
		{
			_memberRepository = memberRepository;
			_jwtTokenProvider = jwtTokenProvider;
		}

		public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			// Get member
			Member? member = await _memberRepository.GetByEmailAsync(request.Email, cancellationToken);

			if (member is null)
			{
				return Result<string>.Failure("Member not found.");
			}
			// Generate JWT
			string token = _jwtTokenProvider.GenerateToken(member);

			// Return JWT
			return Result<string>.Success(token);
		}
	}
}


