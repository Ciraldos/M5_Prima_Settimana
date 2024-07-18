namespace W7.Project.DataLayer.Entities
{
    /// <summary>
    /// Stati possibili di una spedizione.
    /// </summary>
    public enum ShippingStatus
    {
        /// <summary>
        /// In transito.
        /// </summary>
        InTransit,
        /// <summary>
        /// In consegna.
        /// </summary>
        Delivering,
        /// <summary>
        /// Consegnato.
        /// </summary>
        Delivered,
        /// <summary>
        /// Non consegnato.
        /// </summary>
        NotDelivered
    }
    /// <summary>
    /// Stato di una spedizione.
    /// </summary>
    public class ShippingStatusEntity : BaseEntity
    {
        /// <summary>
        /// Chiave esterna verso la tabella delle spedizioni.
        /// </summary>
        public required long ShippingId { get; set; }
        /// <summary>
        /// Stato della spedizione.
        /// </summary>
        public required ShippingStatus Status { get; set; }
        /// <summary>
        /// Località in cui si trova la spedizione.
        /// </summary>
        public required string Place { get; set; }
        /// <summary>
        /// Eventuale descrizione.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Data dell'ultimo aggiornamento.
        /// </summary>
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}
