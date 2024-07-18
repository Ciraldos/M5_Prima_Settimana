namespace W7.Project.DataLayer.Entities
{
    /// <summary>
    /// Una spedizione.
    /// </summary>
    public class ShippingEntity : BaseEntity
    {
        /// <summary>
        /// Chiave esterna verso la tabella dei clienti per il riferimento al mittente.
        /// </summary>
        public required long CustomerId { get; set; }
        /// <summary>
        /// Numero della spedizione.
        /// </summary>
        public required string Number { get; set; }
        /// <summary>
        /// Data di spedizione.
        /// </summary>
        public required DateTime ShipDate { get; set; }
        /// <summary>
        /// Chiave esterna verso la tabella dei clienti per il riferimento al destinatario.
        /// </summary>
        public required long RecipientId { get; set; }
        /// <summary>
        /// Spese di spedizione.
        /// </summary>
        public decimal Fare { get; set; }
        /// <summary>
        /// Città destinataria.
        /// </summary>
        public required string City { get; set; }
    }
}
