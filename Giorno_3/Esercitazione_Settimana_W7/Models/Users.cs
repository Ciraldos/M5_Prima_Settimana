namespace Esercitazione_Settimana_W7.Models
{
    public class Users
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }

        public List<string> Roles { get; set; } = [];
    }
}
