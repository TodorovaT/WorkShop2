using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkShop2.Models;

namespace WorkShop2.Models
{
    public class WorkShop2Context : DbContext
    {
        public WorkShop2Context (DbContextOptions<WorkShop2Context> options)
            : base(options)
        {
        }

        public DbSet<WorkShop2.Models.Course> Course { get; set; }

        public DbSet<WorkShop2.Models.Student> Student { get; set; }

        public DbSet<WorkShop2.Models.Teacher> Teacher { get; set; }

        public DbSet<WorkShop2.Models.Prof> Prof { get; set; }

        public DbSet<WorkShop2.Models.Stud> Stud { get; set; }

        public DbSet<WorkShop2.Models.Sluzba> Sluzba { get; set; }

        public DbSet<WorkShop2.Models.MoiPredmetiProf> MoiPredmetiProf { get; set; }

        public DbSet<WorkShop2.Models.MoiPredmetiStud> MoiPredmetiStud { get; set; }

        public DbSet<WorkShop2.Models.Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Enrollment>()
                .HasOne<Student>(p => p.Student)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(p => p.StudentId);

            builder.Entity<Enrollment>()
                .HasOne<Course>(p => p.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(p => p.CourseId);

            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.FirstTeacher)
                .WithMany(p => p.FirstCourses)
                .HasForeignKey(p => p.FirstTeacherId);

            builder.Entity<Course>()
                .HasOne<Teacher>(p => p.SecondTeacher)
                .WithMany(p => p.SecondCourses)
                .HasForeignKey(p => p.SecondTeacherId);

        }
    }
}
