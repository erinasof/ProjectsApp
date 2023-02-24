
using SQLite;

namespace ProjectsApp.Models.Base
{
    public abstract class PKNamedEntity<TKey> : PKEntity<TKey>
    {
        [Column("_name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
