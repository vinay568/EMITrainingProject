using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AmsApi.DataModel.Models
{
    public partial class AmsDbContext : DbContext
    {
        public AmsDbContext()
        {
        }

        public AmsDbContext(DbContextOptions<AmsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestsBill> RequestsBills { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseSqlServer("Server=INDBANL096\\SQLEXPRESS;Database=amsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Designation1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("designation");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("dateOfBirth");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.ManagerId).HasColumnName("managerId");

                entity.Property(e => e.Password)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .HasColumnName("phoneNumber");

                entity.Property(e => e.RoleId).HasColumnName("roleId");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdvanceAmount).HasColumnName("advanceAmount");

                entity.Property(e => e.Approver)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("approver");

                entity.Property(e => e.ApproverId).HasColumnName("approverId");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Description)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("description");

                entity.Property(e => e.EmployeeId).HasColumnName("employeeId");

                entity.Property(e => e.EstimatedCost).HasColumnName("estimatedCost");

                entity.Property(e => e.ForwardedTo).HasColumnName("forwardedTo");

                entity.Property(e => e.PlanDate)
                    .HasColumnType("date")
                    .HasColumnName("planDate");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("purpose");

                entity.Property(e => e.RejectedReason)
                    .IsUnicode(false)
                    .HasColumnName("rejectedReason");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.HasOne(d => d.ApproverNavigation)
                    .WithMany(p => p.RequestApproverNavigations)
                    .HasForeignKey(d => d.ApproverId)
                    .HasConstraintName("fk_approverId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.RequestEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_employeeId");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Status)
                    .HasConstraintName("fk_status");
            });

            modelBuilder.Entity<RequestsBill>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comments)
                    .IsUnicode(false)
                    .HasColumnName("comments");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.FileExtension)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fileExtension");

                entity.Property(e => e.FileName)
                     .IsUnicode(false)
                    .HasColumnName("fileName");

                entity.Property(e => e.FilePath)
                    .IsUnicode(false)
                    .HasColumnName("filePath");

                entity.Property(e => e.MimeType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mimeType");

                entity.Property(e => e.RequestId).HasColumnName("requestId");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestsBills)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("fk_requestId");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
