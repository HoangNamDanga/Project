using apiVPP.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;


namespace apiVPP.Data
    {
        public class Context : IdentityDbContext<Employee, Role, int>
        {
            public Context(DbContextOptions options) : base(options) { }

            public DbSet<Employee> Employees { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<AuditLog> AuditLogs { get; set; }
            public DbSet<Approval> Approvals { get; set; }
            public DbSet<Notification> Notifications { get; set; }
            public DbSet<StationeryItem> StationeryItems { get; set; }
            public DbSet<StationeryRequest> StationeryRequests { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {

            builder.Entity<Employee>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd(); // Đánh dấu rằng Id không sử dụng Identity

            builder.Entity<Role>()
                .Property(r => r.Id)
                .ValueGeneratedOnAdd(); // Đánh dấu rằng Id không sử dụng Identity

            // Quan hệ giữa Approval và StationeryRequest
            builder.Entity<Approval>()
                    .HasOne(a => a.StationeryRequest)
                    .WithMany()
                    .HasForeignKey(a => a.RequestID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Quan hệ giữa Approval và StationeryItem
                builder.Entity<Approval>()
                    .HasOne(a => a.StationeryItem)
                    .WithMany()
                    .HasForeignKey(a => a.ItemID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Quan hệ giữa Approval và Employee
                builder.Entity<Approval>()
                    .HasOne(a => a.Employee)
                    .WithMany()
                    .HasForeignKey(a => a.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Cấu hình quan hệ giữa Employee và Role
                builder.Entity<Employee>()
                    .HasOne(e => e.Role)
                    .WithMany(r => r.Employees)
                    .HasForeignKey(e => e.RoleId)
                    .OnDelete(DeleteBehavior.NoAction);

                // Cấu hình quan hệ tự liên kết cho Employee (Superior)
                builder.Entity<Employee>()
                    .HasOne(e => e.Superior)
                    .WithMany()
                    .HasForeignKey(e => e.SuperiorID)
                    .OnDelete(DeleteBehavior.NoAction);

                // Cấu hình quan hệ tự liên kết cho Subordinates
                builder.Entity<Employee>()
                    .HasMany(e => e.Subordinates)
                    .WithOne(s => s.Superior)
                    .HasForeignKey(s => s.SuperiorID)
                    .OnDelete(DeleteBehavior.NoAction);

                // Cấu hình khóa chính cho StationeryRequest
                builder.Entity<StationeryRequest>()
                    .HasKey(sr => sr.RequestID);

                // Quan hệ giữa StationeryRequest và Employee
                builder.Entity<StationeryRequest>()
                    .HasOne(sr => sr.Employee)
                    .WithMany()
                    .HasForeignKey(sr => sr.EmployeeID)
                    .OnDelete(DeleteBehavior.Restrict);

                // Quan hệ giữa StationeryRequest và Supervisor
                builder.Entity<StationeryRequest>()
                    .HasOne(sr => sr.Supervisor)
                    .WithMany()
                    .HasForeignKey(sr => sr.SuperviorID)
                    .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<AuditLog>()
                .HasOne(a => a.Employee)
                .WithMany()
                .HasForeignKey(a => a.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict); // Đặt hành vi xóa khi Employee tồn tại

            builder.Entity<AuditLog>()
                .HasOne(a => a.ChangedByEmployee)
                .WithMany()
                .HasForeignKey(a => a.ChangedBy)
                .OnDelete(DeleteBehavior.Restrict); // Đặt hành vi xóa khi ChangedByEmployee tồn tại
            base.OnModelCreating(builder);

            }
    }
}
