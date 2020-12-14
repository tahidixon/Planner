namespace Disciplanner.Resources
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DisciplannerEntities : DbContext
    {
        public DisciplannerEntities()
            : base("name=DisciplannerEntities")
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Deadline> Deadlines { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.CreationTime)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.StartTime)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.EndTime)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryID)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.CreationTime)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.StartTime)
                .IsUnicode(false);

            modelBuilder.Entity<Deadline>()
                .Property(e => e.EndTime)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.CreationTime)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.StartTime)
                .IsUnicode(false);

            modelBuilder.Entity<Task>()
                .Property(e => e.EndTime)
                .IsUnicode(false);
        }
    }
}
