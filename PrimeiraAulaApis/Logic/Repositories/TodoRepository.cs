namespace PrimeiraAulaApis.Logic.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext dbContext;
        public TodoRepository(AppDbContext dbContext) => this.dbContext = dbContext;

        public async Task<IQueryable<Todo>> GetAll()
            => dbContext.Todos;

        public async Task<Todo> GetById(Guid id)
            => await dbContext.Todos.FindAsync(id);

        public async Task<Todo> Add(Todo todo)
        {
            await dbContext.Todos.AddAsync(todo);
            await dbContext.SaveChangesAsync();

            return todo;
        }

        public async Task Update(Todo updates)
            => await UpdateEntity(updates);

        public async Task Replace(Todo todo)
            => await UpdateEntity(todo);

        public async Task Delete(Guid id)
            => dbContext.Todos.Remove(await dbContext.Todos.FindAsync(id));

        private async Task UpdateEntity(Todo todo)
        {
            var entity = await GetById(todo.Id.Value);
            dbContext.Entry(entity).CurrentValues.SetValues(todo);
            await dbContext.SaveChangesAsync();
        }
    }
}
