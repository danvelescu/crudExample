namespace crudExample.Domain.Audits
{
    public abstract class AuditbleEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
