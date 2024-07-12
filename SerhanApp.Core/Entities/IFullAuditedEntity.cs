namespace SerhanApp.Core.Entities
{
    /// <summary>
    /// Entity Full Audited Entity olarak implemente edilirse, Denetime tabi demektir. 
    /// Ne zaman yaratıldı güncellendi veya silindi takip edilecek.
    /// </summary>
    public interface IFullAuditedEntity : ISoftDeletedEntity
    {
        public int CreatedbyApplicationUserId { get; set; }
        public DateTime CreatedOnUtc  { get; set; }
        //public int? UpdatedByApplicationUserId  { get; set; }
        public DateTime? UpdatedOnUtc  { get; set; }
    }
}