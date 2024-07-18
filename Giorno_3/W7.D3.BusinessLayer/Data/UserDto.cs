namespace W7.D3.BusinessLayer.Data
{
    /// <summary>
    /// Cos'è un utente?
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Chiave identificativa.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Username.
        /// </summary>
        public required string Username { get; set; }
        /// <summary>
        /// Password.
        /// </summary>
        public required string Password { get; set; }
        /// <summary>
        /// Ruoli applicativi ai quali l'utente è associato.
        /// </summary>
        public List<string> Roles { get; set; } = [];
    }
}
