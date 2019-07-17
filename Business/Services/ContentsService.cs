using EN.Business.Context;
using EN.Core.Declarations.Services;
using EN.Core.Entity;

namespace EN.Business.Services
{
    public class ContentsService : GenericRepository<Content>, IContentsService
    {
        EnContext enContext;
        public ContentsService(EnContext dbContext) : base(dbContext)
        {
            enContext = dbContext;
        }
    }
}
