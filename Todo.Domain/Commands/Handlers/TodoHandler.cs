using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Handlers.Contracts;
using Todo.Domain.Commands.Repositories;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Handlers {
    public class TodoHandler : Notifiable, IHandler<CreateTodoCommand> {

        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository) {
            _repository = repository;
        }
        public ICommandResult Handle(CreateTodoCommand command) {

            //fail fast validation
            command.Validate();

            if (command.Invalid)
                return new GenericCommandResult(false, "Ops, parece que sua tarefa está errada!", command.Notifications);

           //gera o todo (tarefa)
            var todo = new TodoItem(command.Title, command.User, command.Date);

            //salvar no banco
            _repository.Create(todo);

            //retorna o resultado
            return new GenericCommandResult(true, "Ops, Tarefa criada com sucesso!", command.Notifications);


        }
    }
}
