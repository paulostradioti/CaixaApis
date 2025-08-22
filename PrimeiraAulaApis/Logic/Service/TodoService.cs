using Microsoft.AspNetCore.JsonPatch;
using PrimeiraAulaApis.Logic.Exceptions;
using PrimeiraAulaApis.Logic.Repositories;

namespace PrimeiraAulaApis.Logic.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository repository;
        public TodoService(ITodoRepository repository) => this.repository = repository;


        public async Task<IEnumerable<Todo>> GetAll()
            => await repository.GetAll();

        public async Task<Todo> GetById(Guid id)
            => await repository.GetById(id);

        public async Task<Todo> Add(Todo todo)
            => await repository.Add(todo);

        public async Task Update(Guid id, Todo updated)
        {
            TodoValidationException.ThrowWhenIsDifferent(id, updated.Id.Value, "Id Mismatch");
            repository.Replace(updated);
        }

        public async Task Replace(Guid id, Todo todo)
        {
            TodoValidationException.ThrowWhenIsDifferent(id, todo.Id.Value, "Id Mismatch");
            await repository.Replace(todo);
        }

        public async Task Delete(Guid id)
            => await repository.Delete(id);
    }
}
