using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.Helpers;
using ToDoApp.Domain.Enums;
using ToDoApp.Domain.Models;

namespace ToDoApp.DataAccess
{
    public class ToDoContext(DbContextOptions<ToDoContext> options) : DbContext(options)
    {
        public DbSet<ToDoTask> Tasks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Priority>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ToDoTask>()
                .HasOne(e => e.AssignedUser)
                .WithMany(e => e.UsersTasks)
                .HasForeignKey(e => e.AssignedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ToDoTask>()
                .HasOne(e => e.Priority)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e => e.PriorityId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UsersTasks)
                .WithOne(e => e.AssignedUser)
                .HasForeignKey(e => e.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Priority>()
                .Property(s => s.Id).ValueGeneratedNever();

            DoDataSeeding(modelBuilder);
        }

        private void DoDataSeeding(ModelBuilder modelBuilder)
        {
            //TODO: For real app here should be added universal logic to seed reference values 
            var entities = Enum.GetValues(typeof(PriorityLevel))
                .OfType<PriorityLevel>()
                .Select(x => new Priority() { Id = x, Name = EnumHelper.GetEnumDescription(x) })
                .ToArray();

            modelBuilder.Entity<Priority>().HasData(entities);
        }
    }
}
