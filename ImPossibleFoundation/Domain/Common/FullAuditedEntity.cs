using System;

namespace ImPossibleFoundation.Domain.Entities
{

    public interface IHasCreation
    {
        public DateTime Created { get; set; }
        public Guid CreatedBy { get; set; }
    }
    public interface ISoftDelete
    {
        DateTime Deleted { get; set; }
        Guid DeletedBy { get; set; }
    }

    public interface IAuditable : IHasCreation
    {
        DateTime? LastModified { get; set; }
        Guid? LastModifiedBy { get; set; }
    }

    public class FullAuditedEntity<T> : IAuditable, ISoftDelete
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