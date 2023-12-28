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

        [HttpPost]
        public async Task<ActionResult<TodoDto>> CreateTodo([FromBody] AddTodoDto dto)
        {
            var todo = _mapper.Map<Todo>(dto);

            var result = _repository.Add(todo);

            await _repository.Save();

            var todoDto = _mapper.Map<TodoDto>(result);

            return Ok(todoDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetById([FromRoute] Guid id)
        {
            var result = await _repository.GetById(id);

            var todoDto = _mapper.Map<TodoDto>(result);

            return Ok(todoDto);
        }

        [HttpGet]
        public async Task<ActionResult<List<TodoDto>>> GetAll()
        {
            var result = await _repository.List();

            var todoDto = _mapper.Map<List<TodoDto>>(result);

            return Ok(todoDto);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] EditTodoDto dto)
        {
            var todo = _mapper.Map<Todo>(dto);

            _repository.Edit(todo);

            await _repository.Save();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            await _repository.Delete(id);

            await _repository.Save();

            return Ok();
        }

    }
}
