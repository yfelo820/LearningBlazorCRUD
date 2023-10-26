using Microsoft.EntityFrameworkCore;

namespace LearningBlazorCRUD.DB.Entities
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=BookDBPrincipal.mssql.somee.com;Initial Catalog=BookDBPrincipal;user id=yfelo820_SQLLogin_1;pwd=z4gllynoip;Trust Server Certificate=True;");

            // LOCAL "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;"
        }
    }
}
