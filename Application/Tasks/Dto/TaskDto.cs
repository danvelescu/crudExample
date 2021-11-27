using crudExample.Domain.Enums;

namespace crudExample.Application.Tasks.Dto
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public string AssignedUserUsername { get; set; }
    }
}
