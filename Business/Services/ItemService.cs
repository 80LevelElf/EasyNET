using EN.Business.Context;
using EN.Core.Declarations.Services;
using EN.Core.Entity;

namespace EN.Business.Services
{
    public class ItemService : GenericRepository<Item>, IItemService
    {
        public ItemService(EnContext dbContext) : base(dbContext)
        {
        }
    }
}
