namespace WebAPI.Application.Abstractions.Interfaces
{
	public interface ICommandHandler<in TCommand, TResponse>
		where TCommand : ICommand<TResponse>
	{
		Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
	}

	public interface ICommand<TResponse> { }
}
