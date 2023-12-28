using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Core.Interfaces;
using Core.Entities;

using TodoExample.Mapper.Dtos;

namespace TodoExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Todo> _repository;

        public TodoController(IMapper mapper, IRepository<Todo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetAll()
        {
            var result = await _repository.List();

            var teamDto = _mapper.Map<List<TodoDto>>(result);

            return Ok(teamDto);
        }
    }
}
