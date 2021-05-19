using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop2.Models;

namespace WorkShop2.ViewModels
{
    public class EnrollmentCourseIndexViewModel
    {
        public IList<Enrollment> Enrollments { get; set; }

        public string EnrollmentCourse { get; set; }

        public string EnrollmentIndex { get; set; }

        public SelectList Grades { get; set; }
        public int EnrollmentGrade { get; set; }

        public SelectList Semesters { get; set; }
        public string EnrollmentSemester { get; set; }
    }
}
