namespace SerhanApp.Core.Entities
{
    /// <summary>
    /// Entity ISoftDeletedEntity olarak implemente edilirse
    /// tablodan veri silinmeyecek Deleted = True olarak belirlenecek.
    /// </summary>
    public interface ISoftDeletedEntity
    {
        bool Deleted { get; set; }
        public DateTime? DeletedOnUtc { get; set; }
    }
}
