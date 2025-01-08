using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Project6.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<Memberaddress> Memberaddresses { get; set; }

    public virtual DbSet<RegularizationRequest> RegularizationRequests { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Sessionlog> Sessionlogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PRIMARY");

            entity.ToTable("address");

            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.City)
                .HasMaxLength(45)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(45)
                .HasColumnName("country");
            entity.Property(e => e.HouseNo)
                .HasMaxLength(45)
                .HasColumnName("house_no");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .HasColumnName("postal_code");
            entity.Property(e => e.State)
                .HasMaxLength(45)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(300)
                .HasColumnName("street");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => new { e.AttendanceId, e.MemberId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("attendance");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.AttendanceDate).HasColumnName("attendance_date");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.LoginTime)
                .HasColumnType("timestamp")
                .HasColumnName("login_time");
            entity.Property(e => e.LogoutTime)
                .HasColumnType("timestamp")
                .HasColumnName("logout_time");
            entity.Property(e => e.Status)
                .HasColumnType("enum('Present','Absent','Half-day','On Leave')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Member).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attendance_ibfk_1");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => new { e.ContactId, e.MemberId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("contact");

            entity.HasIndex(e => e.ContactId, "contact_id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.MemberId, "fk_Contact_Member1_idx");

            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.ContactType)
                .HasColumnType("enum('Personal','home','work')")
                .HasColumnName("contact_type");
            entity.Property(e => e.PhoneNumber).HasColumnName("phone_number");

            entity.HasOne(d => d.Member).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contact_Member1");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PRIMARY");

            entity.ToTable("member");

            entity.HasIndex(e => e.MemberId, "Id_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.EmployeeId, "employee_id_UNIQUE").IsUnique();

            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(45)
                .HasColumnName("first_name");
            entity.Property(e => e.Gender)
                .HasColumnType("enum('male','female','other')")
                .HasColumnName("gender");
            entity.Property(e => e.HashPassword)
                .HasMaxLength(400)
                .HasColumnName("hash_password");
            entity.Property(e => e.LastName)
                .HasMaxLength(45)
                .HasColumnName("last_name");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(45)
                .HasColumnName("middle_name");
            entity.Property(e => e.Roles)
                .HasColumnType("enum('admin','user')")
                .HasColumnName("roles");
        });

        modelBuilder.Entity<Memberaddress>(entity =>
        {
            entity.HasKey(e => new { e.MemberAddressId, e.MemberId, e.AddressId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("memberaddress");

            entity.HasIndex(e => e.AddressId, "fk_MemberAddress_Address1_idx");

            entity.HasIndex(e => e.MemberId, "fk_MemberAddress_Member1_idx");

            entity.Property(e => e.MemberAddressId).HasColumnName("MemberAddress_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.AddressType)
                .HasColumnType("enum('current','permanent','work')")
                .HasColumnName("address_type");

            entity.HasOne(d => d.Address).WithMany(p => p.Memberaddresses)
                .HasForeignKey(d => d.AddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MemberAddress_Address1");

            entity.HasOne(d => d.Member).WithMany(p => p.Memberaddresses)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MemberAddress_Member1");
        });

        modelBuilder.Entity<RegularizationRequest>(entity =>
        {
            entity.HasKey(e => new { e.RequestId, e.MemberId, e.AttendanceId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("regularization_requests");

            entity.HasIndex(e => e.AttendanceId, "attendance_id").IsUnique();

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.Property(e => e.RequestId).HasColumnName("request_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.AttendanceId).HasColumnName("attendance_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.RegularizationReason)
                .HasMaxLength(255)
                .HasColumnName("regularization_reason");
            entity.Property(e => e.RequestedDate).HasColumnName("requested_date");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Pending'")
                .HasColumnType("enum('Pending','Approved','Denied')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Member).WithMany(p => p.RegularizationRequests)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("regularization_requests_ibfk_1");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => new { e.ReportId, e.MemberId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("reports");

            entity.HasIndex(e => e.MemberId, "member_id");

            entity.Property(e => e.ReportId).HasColumnName("report_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.GeneratedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("generated_at");
            entity.Property(e => e.ReportMonth).HasColumnName("report_month");
            entity.Property(e => e.TotalAbsent)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_absent");
            entity.Property(e => e.TotalLate)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_late");
            entity.Property(e => e.TotalOnLeave)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_on_leave");
            entity.Property(e => e.TotalPresent)
                .HasDefaultValueSql("'0'")
                .HasColumnName("total_present");

            entity.HasOne(d => d.Member).WithMany(p => p.Reports)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reports_ibfk_1");
        });

        modelBuilder.Entity<Sessionlog>(entity =>
        {
            entity.HasKey(e => new { e.SessionlogId, e.MemberId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("sessionlog");

            entity.HasIndex(e => e.MemberId, "fk_SessionLog_Member1_idx");

            entity.Property(e => e.SessionlogId).HasColumnName("sessionlog_id");
            entity.Property(e => e.MemberId).HasColumnName("member_id");
            entity.Property(e => e.IsValid).HasMaxLength(5);
            entity.Property(e => e.Token)
                .HasMaxLength(600)
                .HasColumnName("token");

            entity.HasOne(d => d.Member).WithMany(p => p.Sessionlogs)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SessionLog_Member1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
