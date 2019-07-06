using EN.Core.Declarations.Services;
using EN.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItemService _service;
        public ItemsController(IItemService service)
        {
            _service = service;
        }
        [HttpGet]
        public List<Item> GetAll()
        {
            return _service.GetAll().ToList();
        }
    }
}
