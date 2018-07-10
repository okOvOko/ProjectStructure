using Microsoft.Extensions.Options;

namespace BasicApp.DataAccess.Model
{
    using Microsoft.EntityFrameworkCore;

    public class ToDoDbContext : DbContext
    {
        private readonly IOptions<DatabaseConfiguration> configuration;

        public virtual DbSet<Label> Labels { get; set; }

        public virtual DbSet<List> Lists { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<ItemLabel> ItemLabels { get; set; }

        public ToDoDbContext(IOptions<DatabaseConfiguration> configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.configuration.Value.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasOne(i => i.List)
                .WithMany(l => l.Items)
                .HasForeignKey(i => i.ListId);

            modelBuilder.Entity<ItemLabel>()
                .HasKey(e => new {e.ItemId, e.LabelId});

            modelBuilder.Entity<ItemLabel>()
                .HasOne(e => e.Label)
                .WithMany(e => e.IteamLabels);

            modelBuilder.Entity<ItemLabel>()
                .HasOne(e => e.Item)
                .WithMany(e => e.IteamLabels);
        }
    }
}
