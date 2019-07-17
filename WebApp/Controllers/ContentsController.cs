using EN.Core.Declarations.Services;
using EN.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentsController : ControllerBase
    {
        IContentsService _service;
        public ContentsController(IContentsService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll().ToList());
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]Content content)
        {
            return Ok(await _service.CreateAsync(content));
        }
    }
}
