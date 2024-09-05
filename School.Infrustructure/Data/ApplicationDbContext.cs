using Microsoft.EntityFrameworkCore;
using School.Data.Models;

namespace School.Infrustructure.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }
    public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
    public DbSet<InstructorSubject> InstructorSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<StudentSubject>().HasKey(ss => new { ss.StudentId, ss.SubjectId });
        modelBuilder.Entity<DepartmentSubject>().HasKey(ds => new { ds.DepartmentId, ds.SubjectId });
        modelBuilder.Entity<InstructorSubject>().HasKey(Is => new { Is.InstructorId, Is.SubjectId });
        modelBuilder.Entity<Instructor>()
            .HasOne(i => i.Supervisor)
            .WithMany(i => i.Instructors)
            .HasForeignKey(i => i.SupervisorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Department>()
            .HasOne(i => i.Instructor)
            .WithOne(i => i.DepartmentManager)
            .HasForeignKey<Department>(i => i.InstructorManager)
            .OnDelete(DeleteBehavior.Restrict); ;
    }
}
