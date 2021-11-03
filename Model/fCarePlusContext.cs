using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NitcoBackEnd.Model
{
    public partial class fCarePlusContext : DbContext
    {
        public fCarePlusContext()
        {
        }

        public fCarePlusContext(DbContextOptions<fCarePlusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountsChart> AccountsCharts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=fCarePlus;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccountsChart>(entity =>
            {
                entity.ToTable("AccountsChart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AllowEntry).HasColumnName("Allow_Entry");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.ChartLevelDepth).HasColumnName("Chart_Level_Depth");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Creation_Date");

                entity.Property(e => e.FkCostCenterTypeId).HasColumnName("FK_Cost_Center_Type_ID");

                entity.Property(e => e.FkTransactionTypeId).HasColumnName("FK_Transaction_Type_ID");

                entity.Property(e => e.FkWorkFieldsId).HasColumnName("FK_Work_Fields_ID");

                entity.Property(e => e.IsActive).HasColumnName("Is_Active");

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("NameAR");

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("NameEN");

                entity.Property(e => e.NoOfChilds).HasColumnName("noOfChilds");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgId).HasColumnName("Org_ID");

                entity.Property(e => e.ParentId).HasColumnName("Parent_ID");

                entity.Property(e => e.ParentNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Parent_Number");

                entity.Property(e => e.Status).HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("User_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
