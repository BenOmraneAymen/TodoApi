using TodoApi.Models;

namespace TodoApi.DTO
{
    public class TodoDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId { get; set; }
        public List<int> LabelIds { get; set; }
    }
}
