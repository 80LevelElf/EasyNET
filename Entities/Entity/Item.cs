using EN.Core.Declarations;

namespace EN.Core.Entity
{
    public class Item : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
