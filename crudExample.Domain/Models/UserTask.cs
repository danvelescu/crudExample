using crudExample.Domain.Audits;
using crudExample.Domain.Enums;

namespace crudExample.Domain.Models
{
    public class UserTask : AuditbleEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskPriority TaskPriority { get; set; }

        public User AssignToUser { get; set; } 
    }
}
