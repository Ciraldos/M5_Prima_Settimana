namespace W7.Project.DataLayer.Entities
{
    /// <summary>
    /// Un'azienda.
    /// </summary>
    public class CompanyEntity : CustomerEntity
    {
        /// <summary>
        /// Denominazione.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// Partita IVA.
        /// </summary>
        public required string VatCode { get; set; }

        public override string DisplayName => Name;
    }
}
