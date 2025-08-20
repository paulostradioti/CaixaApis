
namespace PrimeiraAulaApis.Controllers
{
    internal class TodoViewModel
    {
        internal static Todo? ToEntity(TodoViewModel todo)
        {
            return new Todo() { };
        }


        internal static TodoViewModel? FromEntity(Todo todo)
        {
            return new TodoViewModel() { };
        }
    }
}