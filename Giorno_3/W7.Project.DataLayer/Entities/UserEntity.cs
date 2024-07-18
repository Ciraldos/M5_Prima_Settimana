namespace W7.Project.DataLayer.Entities
{
    public class UserEntity : BaseEntity
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
