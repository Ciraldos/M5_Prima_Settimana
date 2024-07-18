namespace W7.Project.DataLayer.Entities
{
    /// <summary>
    /// Elementi comuni a tutti i clienti.
    /// </summary>
    public abstract class CustomerEntity : BaseEntity
    {
        /// <summary>
        /// Nome visualizzato.
        /// </summary>
        public abstract string DisplayName { get; }
        /// <summary>
        /// Indirizzo.
        /// </summary>
        public required string Address { get; set; }
        /// <summary>
        /// Città.
        /// </summary>
        public required string City { get; set; }
        /// <summary>
        /// Regione/Provincia.
        /// </summary>
        public string? Region { get; set; }
        /// <summary>
        /// Codice di avviamento postale.
        /// </summary>
        public required string PostalCode { get; set; }
        /// <summary>
        /// Discriminante di tipo.
        /// </summary>
        public int CustomerType { get; set; }
    }
}
