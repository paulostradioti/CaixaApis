
namespace PrimeiraAulaApis.Logic.Repositories
{
    public interface ITodoRepository
    {
        Task<IQueryable<Todo>> GetAll();

        Task<Todo> GetById(Guid id);

        Task<Todo> Add(Todo todo);

        Task Update(Todo updates);

        Task Replace(Todo todo);

        Task Delete(Guid id);
    }
}
