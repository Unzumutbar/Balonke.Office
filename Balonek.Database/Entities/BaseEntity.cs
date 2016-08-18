using Balonek.Database.Interfaces;

namespace Balonek.Database.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
