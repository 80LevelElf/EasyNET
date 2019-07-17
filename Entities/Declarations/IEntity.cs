using System;

namespace EN.Core.Declarations
{
    public interface IEntity
    {
        int Id { get; set; }
        int? CreatedById { get; set; }
        DateTime? CreatedAt { get; set; }
        int? ModifiedById { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}
