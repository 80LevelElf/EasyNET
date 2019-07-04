using EN.Business.Context;
using EN.Core.Declarations.Services;
using EN.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
