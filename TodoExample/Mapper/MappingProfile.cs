using AutoMapper;

using Core.Entities;

using TodoExample.Mapper.Dtos;

namespace TodoExample.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddTodoDto, Todo>();
            CreateMap<EditTodoDto, Todo>();
            CreateMap<Todo, TodoDto>();
        }
    }
}
