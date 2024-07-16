namespace W7.D2.WebAuthentication.Services.Models
{
    public class ApplicationUser
    {
        public int Id {  get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? FriendlyName {  get; set; }

        public List<string> Roles { get; set; } = [];
    }
}
