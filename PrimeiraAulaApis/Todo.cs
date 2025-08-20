using System.ComponentModel.DataAnnotations;

namespace PrimeiraAulaApis
{
    public class Todo
    {
        public Guid? Id { get; set; }

        public string? Titulo { get; set; }
    }
}
