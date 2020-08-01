using Microsoft.EntityFrameworkCore;

namespace TodoApplication.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { } //(base)Miras aldığı sınıfın constructorına erişmek için böyle bir eklenti yapmamız gerekir.  

        public DbSet<TodoItem> TodoList { get; set; }
        

    }
}
