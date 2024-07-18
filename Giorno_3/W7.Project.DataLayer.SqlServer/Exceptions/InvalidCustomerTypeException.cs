using W7.Project.DataLayer.Dao.Exceptions;

namespace W7.Project.DataLayer.SqlServer.Exceptions
{
    public class InvalidCustomerTypeException : DaoException
    {
        public InvalidCustomerTypeException(string? message = "Invalid customer type", Exception? innerException = null) : base(message, innerException) { }
    }
}
