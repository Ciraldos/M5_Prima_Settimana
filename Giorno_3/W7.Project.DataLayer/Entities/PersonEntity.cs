namespace W7.Project.DataLayer.Entities
{
    /// <summary>
    /// Una persona.
    /// </summary>
    public class PersonEntity : CustomerEntity
    {
        /// <summary>
        /// Nome.
        /// </summary>
        public required string FirstName { get; set; }
        /// <summary>
        /// Cognome.
        /// </summary>
        public required string LastName { get; set; }
        /// <summary>
        /// Codice fiscale.
        /// </summary>
        public required string FiscalCode { get; set; }
        /// <summary>
        /// Titolo di cortesia.
        /// </summary>
        public string? Title { get; set; }
        public override string DisplayName => $"{Title} {FirstName} {LastName}".Trim();
    }
}
