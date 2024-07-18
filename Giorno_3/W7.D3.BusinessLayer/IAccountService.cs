using W7.D3.BusinessLayer.Data;

namespace W7.D3.BusinessLayer
{
    public interface IAccountService
    {
        /// <summary>
        /// Registrazione di un utente.
        /// </summary>
        /// <param name="user">Dati dell'utente da registrare.</param>
        /// <returns>Le informazioni dell'utente dopo la registrazione.</returns>
        UserDto Register(UserDto user);
        /// <summary>
        /// Recupera un utente a partire dalle credenziali di accesso.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        /// <returns>L'utente corrispondente alle credenziali o il valore <strong>null</strong>
        /// se il login non è andato a buon fine.</returns>
        UserDto? Login(string username, string password);
        /// <summary>
        /// Recupera l'elenco degli utenti.
        /// </summary>
        List<UserDto> GetAllUsers();
        /// <summary>
        /// Recupera l'elenco dei ruoli applicativi.
        /// </summary>
        List<string> GetAllRoles();
        /// <summary>
        /// Recupera i dati dell'utente attraverso lo username.
        /// </summary>
        /// <param name="username">Username per la ricerca dell'utente sul database.</param>
        /// <returns>L'utente corrispondente allo username.</returns>
        UserDto GetByUsername(string username);
        /// <summary>
        /// Associa un utente ad un ruolo.
        /// </summary>
        /// <param name="username">Username dell'utente.</param>
        /// <param name="roleName">Ruolo al quale associare l'utente.</param>
        /// <returns>Un valore booleano che indica se l'operazione è andata a buon fine.</returns>
        bool AddUserToRole(string username, string roleName);
        /// <summary>
        /// Rimuove un utente da un ruolo.
        /// </summary>
        /// <param name="username">Username dell'utente.</param>
        /// <param name="roleName">Ruolo dal quale rimuovere l'utente.</param>
        /// <returns>Un valore booleano che indica se l'operazione è andata a buon fine.</returns>
        bool RemoveUserFromRole(string username, string roleName);
        /// <summary>
        /// Recupera tutti i ruoli di un utente.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <returns>L'elenco dei ruoli ai quali è associato l'utente.</returns>
        List<string> GetUserRoles(string username);
    }
}
