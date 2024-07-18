namespace W7.D3.DataLayer
{
    /// <summary>
    /// Rappresenta tutto il contesto dati dell'applicazione consentendo
    /// di accedere a tutti i DAO presenti.
    /// </summary>
    public class DbContext
    {
        public IRoleDao Roles { get; set; }
        public IUserRoleDao UsersRoles { get; set; }
        public IUserDao Users { get; set; }

        public DbContext(IRoleDao roleDao, IUserDao userDao, IUserRoleDao userRoleDao) {
            Roles = roleDao;
            Users = userDao;
            UsersRoles = userRoleDao;
        }
    }
}
