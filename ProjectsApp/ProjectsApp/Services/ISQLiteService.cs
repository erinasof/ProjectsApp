using SQLite;

namespace ProjectsApp.Services
{
    public interface ISQLiteService
    {
        SQLiteConnection GetConnection(string dbPath);

        //TODO: проработать момент с асинхронным подключением к БД
        SQLiteAsyncConnection GetAsyncConnection(string dbPath);
    }
}
