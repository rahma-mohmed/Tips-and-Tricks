using WebAPI.Application.Abstractions.Common;
using WebAPI.Application.Abstractions.Interfaces;

namespace WebAPI_Application.Members.Login;

public record LoginCommand(string Email) : ICommand<Result<string>>;
