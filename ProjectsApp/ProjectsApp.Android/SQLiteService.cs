using SQLite;
using ProjectsApp.Services;

namespace ProjectsApp.Droid
{
    class SQLiteService : ISQLiteService
    {
        public static string GetLocalFilePath(string filename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
            return System.IO.Path.Combine(documentsPath, filename);
        }

        public SQLiteAsyncConnection GetAsyncConnection(string dbPath)
        {
            return new SQLiteAsyncConnection(GetLocalFilePath(dbPath));
        }

        public SQLiteConnection GetConnection(string dbPath)
        {
            return new SQLiteConnection(GetLocalFilePath(dbPath));
        }
    }
}