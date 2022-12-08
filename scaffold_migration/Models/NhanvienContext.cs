using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace scaffold_migration.Models;

public partial class NhanvienContext : DbContext
{
    public NhanvienContext()
    {
    }

    public NhanvienContext(DbContextOptions<NhanvienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<SalaryGrade> SalaryGrades { get; set; }

    public virtual DbSet<Timekeeper> Timekeepers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=NHANVIEN;User ID=sa;Password=1234; TrustServerCertificate=True ; ");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK__DEPARTME__512A59AC999F51A7");

            entity.ToTable("DEPARTMENT");

            entity.HasIndex(e => e.DeptNo, "UQ__DEPARTME__512A302D197A5DD5").IsUnique();

            entity.Property(e => e.DeptId)
                .ValueGeneratedNever()
                .HasColumnName("DEPT_ID");
            entity.Property(e => e.DeptName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DEPT_NAME");
            entity.Property(e => e.DeptNo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DEPT_NO");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__EMPLOYEE__16EBFA26083DB420");

            entity.ToTable("EMPLOYEE");

            entity.HasIndex(e => e.EmpNo, "UQ__EMPLOYEE__16EB127C4EA884EA").IsUnique();


            entity.Property(e => e.EmpId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("EMP_ID");
            entity.Property(e => e.DeptId).HasColumnName("DEPT_ID");
            entity.Property(e => e.EmpName)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMP_NAME");

            entity.Property(e => e.infoadd)
            .HasColumnName("Info_EMP")
            .HasColumnType("nvarchar(500)");

            entity.Property(e => e.EmpNo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EMP_NO");
            entity.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("HIRE_DATE");
            entity.Property(e => e.Image)
                .HasColumnType("image")
                .HasColumnName("IMAGE");
            entity.Property(e => e.Job)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("JOB");
            entity.Property(e => e.MngId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("MNG_ID");
            entity.Property(e => e.Salary).HasColumnName("SALARY");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK75C8D6AE269A3C9");

            entity.HasOne(d => d.Mng).WithMany(p => p.InverseMng)
                .HasForeignKey(d => d.MngId)
                .HasConstraintName("FK75C8D6AE13C12F64");
        });

        modelBuilder.Entity<SalaryGrade>(entity =>
        {
            entity.HasKey(e => e.Grade).HasName("PK__SALARY_G__B80884C7ED963CFA");

            entity.ToTable("SALARY_GRADE");

            entity.Property(e => e.Grade)
                .ValueGeneratedNever()
                .HasColumnName("GRADE");
            entity.Property(e => e.HighSalary).HasColumnName("HIGH_SALARY");
            entity.Property(e => e.LowSalary).HasColumnName("LOW_SALARY");
        });

        modelBuilder.Entity<Timekeeper>(entity =>
        {
            entity.HasKey(e => e.TimekeeperId).HasName("PK__TIMEKEEP__3421CD0F46BA6804");

            entity.ToTable("TIMEKEEPER");

            entity.Property(e => e.TimekeeperId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("Timekeeper_Id");
            entity.Property(e => e.DateTime)
                .HasColumnType("datetime")
                .HasColumnName("Date_Time");
            entity.Property(e => e.EmpId)
                .HasColumnType("numeric(19, 0)")
                .HasColumnName("EMP_ID");
            entity.Property(e => e.InOut)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("In_Out");

            entity.HasOne(d => d.Emp).WithMany(p => p.Timekeepers)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK744D9BFF6106A42");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
