using W7.D3.DataLayer.Data;

namespace W7.D3.DataLayer
{
    /// <summary>
    /// DAO per la gestione degli utenti.
    /// </summary>
    public interface IUserDao
    {
        /// <summary>
        /// Creazione di un utente.
        /// </summary>
        /// <param name="user">Dati dell'utente.</param>
        /// <returns>L'utente dopo la persistenza.</returns>
        UserEntity Create(UserEntity user);
        /// <summary>
        /// Recupera un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        UserEntity Read(int userId);
        /// <summary>
        /// Modifica i dati di un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        /// <param name="user">Dati con i quali aggiornare l'utente.</param>
        /// <returns>L'utente dopo la persistenza.</returns>
        UserEntity Update(int userId, UserEntity user);
        /// <summary>
        /// Elimina un utente.
        /// </summary>
        /// <param name="userId">Chiave identificativa dell'utente.</param>
        /// <returns>L'utente eliminato.</returns>
        UserEntity Delete(int userId);
        /// <summary>
        /// Recupera tutti i dati dell'utente tramite lo username.
        /// </summary>
        /// <param name="username">Username dell'utente.</param>
        /// <returns>I dati dell'utente.</returns>
        UserEntity ReadByUsername(string username);
        /// <summary>
        /// Ottiene l'elenco degli utenti nel database.
        /// </summary>
        List<UserEntity> ReadAll();
        /// <summary>
        /// Valida il login di un utente.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>L'utente se il login va a buon fine.</returns>
        UserEntity? Login(string username, string password);
    }
}
