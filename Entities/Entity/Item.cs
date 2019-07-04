using EN.Core.Declarations;

namespace EN.Entities.Entity
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
