namespace W7.Project.DataLayer.Dao.Exceptions
{
    public class EntityNotFoundException : DaoException
    {
        public required long SearchedKey { get; set; }
        public EntityNotFoundException(string? message = "Entity not found on database", Exception? innerException = null) : base(message, null) { }
    }
}
