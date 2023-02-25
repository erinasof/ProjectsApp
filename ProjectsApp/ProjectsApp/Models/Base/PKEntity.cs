using SQLite;

namespace ProjectsApp.Models
{
    public abstract class PKEntity<TKey>
    {

        [PrimaryKey, AutoIncrement, Column("_id")]
        public TKey Id { get; set; }
        
        public bool IsExist()
        {
            return !Equals(Id, default(TKey));
        }
    }
}
