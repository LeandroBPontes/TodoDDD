using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests {
    [TestClass]
    public class CreateTodoHandlerTests {

        private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", "", DateTime.Now);
        private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Titulo da Tarefa", "Leandro", DateTime.Now);

        private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

        public CreateTodoHandlerTests() {}

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_execucao() {

            var command = new CreateTodoCommand("", "", DateTime.Now);
         
            var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }
        [TestMethod]
        public void Dado_um_comando_valido_deve_criar_tarefa() {

            var command = new CreateTodoCommand("Titulo da Tarefa", "Leandro", DateTime.Now);
            
            var result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
           
        }
    }
}
