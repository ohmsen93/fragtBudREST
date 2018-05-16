using fragtBudRESTwebAPI.Models;

namespace fragtBudRESTwebAPI.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FragtContextEDM : DbContext
    {
        public FragtContextEDM()
            : base("name=FragtContextEDM")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<fragt> fragt { get; set; }
        public virtual DbSet<kunde> kunde { get; set; }
        public virtual DbSet<kundetype> kundetype { get; set; }
        public virtual DbSet<medarbejder> medarbejder { get; set; }
        public virtual DbSet<ordre> ordre { get; set; }
        public virtual DbSet<postnrBy> postnrBy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.kunde)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.AspUserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.medarbejder)
                .WithRequired(e => e.AspNetUsers)
                .HasForeignKey(e => e.AspUserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<fragt>()
                .Property(e => e.afVej)
                .IsFixedLength();

            modelBuilder.Entity<fragt>()
                .Property(e => e.afHusNr)
                .IsFixedLength();

            modelBuilder.Entity<fragt>()
                .Property(e => e.levVej)
                .IsFixedLength();

            modelBuilder.Entity<fragt>()
                .Property(e => e.levHusNr)
                .IsFixedLength();

            modelBuilder.Entity<kunde>()
                .Property(e => e.kundeNavn)
                .IsFixedLength();

            modelBuilder.Entity<kundetype>()
                .Property(e => e.type)
                .IsFixedLength();

            modelBuilder.Entity<kundetype>()
                .HasMany(e => e.kunde)
                .WithOptional(e => e.kundetype1)
                .HasForeignKey(e => e.kundeType);

            modelBuilder.Entity<medarbejder>()
                .Property(e => e.medarbejderNavn)
                .IsFixedLength();

            modelBuilder.Entity<medarbejder>()
                .Property(e => e.medarbejderEfternavn)
                .IsFixedLength();

            modelBuilder.Entity<ordre>()
                .Property(e => e.QR)
                .IsFixedLength();

            modelBuilder.Entity<postnrBy>()
                .Property(e => e.By)
                .IsFixedLength();

            modelBuilder.Entity<postnrBy>()
                .HasMany(e => e.fragt)
                .WithOptional(e => e.postnrBy)
                .HasForeignKey(e => e.afPostnr);

            modelBuilder.Entity<postnrBy>()
                .HasMany(e => e.fragt1)
                .WithOptional(e => e.postnrBy1)
                .HasForeignKey(e => e.levPostnr);
        }
    }
}
