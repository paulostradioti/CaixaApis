namespace PrimeiraAulaApis.Logic.Service
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAll();

        Task<Todo> GetById(Guid id);

        Task<Todo> Add(Todo todo);

        Task Update(Guid id, Todo patch);

        Task Replace(Guid id, Todo todo);

        Task Delete(Guid id);
    }
}
