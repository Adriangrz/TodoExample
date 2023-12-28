using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Core.Interfaces;
using Core.Entities;

namespace TodoExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IRepository<Todo> _repository;

        public TodoController(IRepository<Todo> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Todo>> GetAll()
        {
            var result = await _repository.List();

            return result;
        }
    }
}
