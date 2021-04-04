using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SSTruyen.Models
{
    public partial class TruyenDBContext : DbContext
    {
        public TruyenDBContext()
            : base("name=TruyenDBContext")
        {
        }

        public virtual DbSet<ChapTruyen> ChapTruyens { get; set; }
        public virtual DbSet<CheckTheLoai> CheckTheLoais { get; set; }
        public virtual DbSet<TheLoai> TheLoais { get; set; }
        public virtual DbSet<Truyen> Truyens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChapTruyen>()
                .Property(e => e.IDtruyen)
                .IsUnicode(false);

            modelBuilder.Entity<CheckTheLoai>()
                .Property(e => e.IDtruyen)
                .IsUnicode(false);

            modelBuilder.Entity<TheLoai>()
                .HasMany(e => e.CheckTheLoais)
                .WithRequired(e => e.TheLoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Truyen>()
                .Property(e => e.IDTruyen)
                .IsUnicode(false);

            modelBuilder.Entity<Truyen>()
                .HasMany(e => e.ChapTruyens)
                .WithRequired(e => e.Truyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Truyen>()
                .HasMany(e => e.CheckTheLoais)
                .WithRequired(e => e.Truyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
