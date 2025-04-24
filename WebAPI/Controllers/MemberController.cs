using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Abstractions.Common;
using WebAPI.Application.Members.Login;
using WebAPI_Application.Members.Login;

namespace WebAPI.App.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MemberController : ControllerBase
	{
		private readonly ISender _sender;

		public MemberController(ISender sender)
		{
			_sender = sender;
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
		{
			var command = new LoginCommand(request.Email);
			Result<string> result = (Result<string>)await _sender.Send(command, cancellationToken);

			if (result.IsSuccess)
			{
				return Ok(result.Value);
			}
			else
			{
				return BadRequest(result.Error);
			}
		}
	}
}
