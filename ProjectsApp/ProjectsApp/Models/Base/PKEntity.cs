using SQLite;

namespace ProjectsApp.Models
{
    public abstract class PKEntity<TKey>
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public TKey Id { get; set; }

    }
}
