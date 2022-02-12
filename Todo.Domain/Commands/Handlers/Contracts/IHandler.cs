using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands.Handlers.Contracts {
    //quem herdar dessa interface, obrigatoriamente tem que trazer um ICommand junto
    public interface IHandler<T> where T: ICommand {
        ICommandResult Handle(T command);
    }
}
