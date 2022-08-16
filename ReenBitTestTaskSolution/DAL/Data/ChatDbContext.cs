using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    internal class ChatDbContext : DbContext
    {
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {

        }

    }
}
