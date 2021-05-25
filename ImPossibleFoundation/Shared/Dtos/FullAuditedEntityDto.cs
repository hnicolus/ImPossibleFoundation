using System;

namespace ImPossibleFoundation.Dtos
{
    public class FullAuditedEntityDto<T>
    {
        public T Id { get; set; }
        public DateTime? LastModified { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime Deleted { get; set; }
        public Guid DeletedBy { get; set; }
    }
}