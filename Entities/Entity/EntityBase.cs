using System;
using EN.Core.Declarations;

namespace EN.Core.Entity
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
