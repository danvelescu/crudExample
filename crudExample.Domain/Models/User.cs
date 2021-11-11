using crudExample.Domain.Audits;

namespace crudExample.Domain.Models
{
    public class User : AuditbleEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }

        public ICollection<UserTask> UserTasks { get; set; }
    }
}
