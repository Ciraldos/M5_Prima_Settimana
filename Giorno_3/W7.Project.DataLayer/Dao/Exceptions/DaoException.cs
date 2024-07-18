namespace W7.Project.DataLayer.Dao.Exceptions
{
    [Serializable]
    public class DaoException : Exception
    {
        public DaoException(string? message = "Exception accessing data on database", Exception? innerException = null)
            : base(message, innerException) { }
    }
}
