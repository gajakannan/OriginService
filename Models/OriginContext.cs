using Microsoft.EntityFrameworkCore;

namespace OriginService.Models
{
    public partial class OriginContext : DbContext
    {
        // public OriginContext()
        // {
        // }

        public OriginContext(DbContextOptions<OriginContext> options) : base(options)
        {
        }

        public virtual DbSet<Inputs> Inputs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inputs>(entity =>
            {
                entity.HasKey(e => e.Inputid)
                    .HasName("inputs_pkey");

                entity.ToTable("Inputs");

                entity.Property(e => e.Inputid)
                    .HasColumnName("inputid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Moniker)
                    .HasColumnName("moniker")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(3000);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(20);

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasMaxLength(50);

                // entity.Property(e => e.Unitprice)
                //     .HasColumnName("unitprice")
                //     .HasColumnType("numeric");
            });

            // modelBuilder.Entity<Userinfo>(entity =>
            // {
            //     entity.HasKey(e => e.Userid)
            //         .HasName("userinfo_pkey");

            //     entity.ToTable("userinfo");

            //     entity.Property(e => e.Userid)
            //         .HasColumnName("userid")
            //         .UseIdentityAlwaysColumn();

            //     entity.Property(e => e.Createddate)
            //         .HasColumnName("createddate")
            //         .HasColumnType("date")
            //         .HasDefaultValueSql("CURRENT_DATE");

            //     entity.Property(e => e.Email)
            //         .IsRequired()
            //         .HasColumnName("email")
            //         .HasMaxLength(50);

            //     entity.Property(e => e.Firstname)
            //         .IsRequired()
            //         .HasColumnName("firstname")
            //         .HasMaxLength(30);

            //     entity.Property(e => e.Lastname)
            //         .IsRequired()
            //         .HasColumnName("lastname")
            //         .HasMaxLength(30);

            //     entity.Property(e => e.Password)
            //         .IsRequired()
            //         .HasColumnName("password")
            //         .HasMaxLength(20);

            //     entity.Property(e => e.Username)
            //         .IsRequired()
            //         .HasColumnName("username")
            //         .HasMaxLength(30);
            // });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}