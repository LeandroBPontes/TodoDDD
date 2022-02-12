using System;
using System.Collections.Generic;
using System.Text;
using Todo.Domain.Entities;

namespace Todo.Domain.Commands.Repositories {
    public interface ITodoRepository {
        void Create(TodoItem todo);
        void Update(TodoItem todo);
    }
}
