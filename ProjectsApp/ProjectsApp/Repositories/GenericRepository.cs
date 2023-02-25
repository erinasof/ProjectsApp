using SQLite;

namespace ProjectsApp.Repositories
{
    public class GenericRepository
    {
        private readonly SQLiteConnection database;
        public GenericRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
        }
    }
}
