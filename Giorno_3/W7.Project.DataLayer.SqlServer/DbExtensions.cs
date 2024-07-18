namespace W7.Project.DataLayer.SqlServer
{
    public static class DbExtensions
    {
        public static object Coalesce(this object? obj, params object[] objects) =>
            obj ?? objects?.FirstOrDefault(o => o != null) ?? DBNull.Value;
    }
}
