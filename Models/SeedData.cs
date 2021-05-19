using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShop2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new WorkShop2Context(
                serviceProvider.GetRequiredService<
                DbContextOptions<WorkShop2Context>>()))
            {
                if (context.Student.Any() || context.Teacher.Any() || context.Course.Any())
                {
                    return;
                }
                context.Student.AddRange(
                    new Student
                    {
                        //Id=1
                        StudentId = "123/2017",
                        FirstName = "Дарија",
                        LastName = "Динева",
                        EnrollmentDate = DateTime.Parse("01-09-2017"),
                        AcquiredCredits = 200,
                        CurrentSemester = 8,
                        EducationLevel = "Додипломски студии"
                    },
                    new Student
                    {
                        //Id=2
                        StudentId = "456/2017",
                        FirstName = "Елена",
                        LastName = "Петкова",
                        EnrollmentDate = DateTime.Parse("01-09-2017"),
                        AcquiredCredits = 210,
                        CurrentSemester = 8,
                        EducationLevel = "Додипломски студии"
                    },
                    new Student
                    {
                        //Id=3
                        StudentId = "789/2017",
                        FirstName = "Марко",
                        LastName = "Прокопиев",
                        EnrollmentDate = DateTime.Parse("01-09-2020"),
                        AcquiredCredits = 12,
                        CurrentSemester = 2,
                        EducationLevel = "Додипломски студии"
                    },
                    new Student
                    {
                        //Id=4
                        StudentId = "12/2017",
                        FirstName = "Дино",
                        LastName = "Доневски",
                        EnrollmentDate = DateTime.Parse("01-09-2015"),
                        AcquiredCredits = 186,
                        CurrentSemester = 8,
                        EducationLevel = "Додипломски студии"
                    },
                    new Student
                    {
                        //Id=5
                        StudentId = "38/2017",
                        FirstName = "Леона",
                        LastName = "Луисова",
                        EnrollmentDate = DateTime.Parse("01-09-2020"),
                        AcquiredCredits = 6,
                        CurrentSemester = 2,
                        EducationLevel = "Додипломски студии"
                    },
                    new Student
                    {
                        //Id=6
                        StudentId = "14/2017",
                        FirstName = "Давор",
                        LastName = "Живков",
                        EnrollmentDate = DateTime.Parse("01-09-2017"),
                        AcquiredCredits = 204,
                        CurrentSemester = 8,
                        EducationLevel = "Додипломски студии"
                    }
                );
                context.SaveChanges();

                context.Teacher.AddRange(
                    new Teacher
                    {
                        //Id=1
                        FirstName = "Петар",
                        LastName = "Велков",
                        Degree = "Др",
                        AcademicRank = "Редовен професор",
                        OfficeNumber = "123A",
                        HireDate = DateTime.Parse("01.09.1998")
                    },
                    new Teacher
                    {
                        //Id=2
                        FirstName = "Мартина",
                        LastName = "Мимева",
                        Degree = "Апсолвент",
                        AcademicRank = "Асистент",
                        OfficeNumber = "123A",
                        HireDate = DateTime.Parse("01.09.2003")
                    },
                    new Teacher
                    {
                        //Id=3
                        FirstName = "Ацо",
                        LastName = "Ристев",
                        Degree = "Др",
                        AcademicRank = "Редовен професор",
                        OfficeNumber = "456Б",
                        HireDate = DateTime.Parse("01.09.1972")
                    },
                    new Teacher
                    {
                        //Id=4
                        FirstName = "Нина",
                        LastName = "Китевска",
                        Degree = "Мр",
                        AcademicRank = "Асистент",
                        OfficeNumber = "789Ц",
                        HireDate = DateTime.Parse("01.09.1972")
                    },
                    new Teacher
                    {
                        //Id=5
                        FirstName = "Дени",
                        LastName = "Динов",
                        Degree = "Др",
                        AcademicRank = "Вонреден професор",
                        OfficeNumber = "100А",
                        HireDate = DateTime.Parse("01.09.1932")
                    },
                    new Teacher
                    {
                        //Id=6
                        FirstName = "Петар",
                        LastName = "Лаков",
                        Degree = "Др",
                        AcademicRank = "Редовен професор",
                        OfficeNumber = "200Б",
                        HireDate = DateTime.Parse("01.09.1942")
                    },
                    new Teacher
                    {
                        //Id=7
                        FirstName = "Војдан",
                        LastName = "Фуштев",
                        Degree = "Мр",
                        AcademicRank = "Редовен професор",
                        OfficeNumber = "300Д",
                        HireDate = DateTime.Parse("01.09.1976")
                    },
                    new Teacher
                    {
                        //Id=8
                        FirstName = "Велко",
                        LastName = "Ракев",
                        Degree = "Мр",
                        AcademicRank = "Вонреден професор",
                        OfficeNumber = "400А",
                        HireDate = DateTime.Parse("01.09.2005")
                    },
                    new Teacher
                    {
                        //Id=9
                        FirstName = "Ведран",
                        LastName = "Атанасков",
                        Degree = "Др",
                        AcademicRank = "Редовен професор",
                        OfficeNumber = "500Б",
                        HireDate = DateTime.Parse("01.09.2010")
                    }
                    );
                context.SaveChanges();

                context.Course.AddRange(
                    new Course
                    {
                        //Id=1
                        Title = "Основи на Телекомуникации",
                        Credits = 6,
                        Semester = 4,
                        Programme = "ТКИИ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId=1,
                        //SecondTeacherId=2
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Петар" && d.LastName == "Велков").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Мартина" && d.LastName == "Мимева").Id
                    },
                    new Course
                    {
                        //Id=2
                        Title = "Дигитални Валути",
                        Credits = 6,
                        Semester = 8,
                        Programme = "СИТЕ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId = 3,
                        //SecondTeacherId = 2
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Ацо" && d.LastName == "Ритев").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Мартина" && d.LastName == "Мимева").Id
                    },
                    new Course
                    {
                        //Id=3
                        Title = "Комуникациски Вештини",
                        Credits = 3,
                        Semester = 8,
                        Programme = "СИТЕ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId = 4,
                        //SecondTeacherId = 2
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Нина" && d.LastName == "Китевска").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Мартина" && d.LastName == "Мимева").Id
                    },
                    new Course
                    {
                        //Id=4
                        Title = "Развој на серверски WEB апликации",
                        Credits = 6,
                        Semester = 6,
                        Programme = "ТКИИ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId = 5,
                        //SecondTeacherId = 6
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Душко" && d.LastName == "Денков").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Петар" && d.LastName == "Латков").Id
                    },
                    new Course
                    {
                        //Id=5
                        Title = "Проектен Менаџмент",
                        Credits = 3,
                        Semester = 8,
                        Programme = "СИТЕ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId = 7,
                        //SecondTeacherId = 2
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Војдан" && d.LastName == "Фуштев").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Мартина" && d.LastName == "Мимева").Id
                    },
                    new Course
                    {
                        //Id=6
                        Title = "Е-Здравство",
                        Credits = 6,
                        Semester = 8,
                        Programme = "ТКИИ",
                        EducationLevel = "Додипломски студии",
                        //FirstTeacherId = 8,
                        //SecondTeacherId = 9
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Велко" && d.LastName == "Ракиќ").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Ведран" && d.LastName == "Атанасков").Id
                    }
                    );
                context.SaveChanges();

                context.Enrollment.AddRange(
                    new Enrollment { StudentId = 1, CourseId = 1 },
                    new Enrollment { StudentId = 2, CourseId = 2 },
                    new Enrollment { StudentId = 3, CourseId = 3 },
                    new Enrollment { StudentId = 4, CourseId = 4 },
                    new Enrollment { StudentId = 5, CourseId = 5 },
                    new Enrollment { StudentId = 6, CourseId = 6 }
                    );
                context.SaveChanges();
            }
        }
    }
}
