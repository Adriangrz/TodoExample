namespace TodoExample.Mapper.Dtos
{
    public class EditTodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
