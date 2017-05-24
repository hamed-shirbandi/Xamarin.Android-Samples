
using SQLite;

namespace Sqlite_In_Xamarin.Domain
{
   public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string  Name { get; set; }
    }
}