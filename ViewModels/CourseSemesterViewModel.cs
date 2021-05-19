using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop2.Models;

namespace WorkShop2.ViewModels
{
    public class CourseSemesterViewModel
    {
        public IList<Course> Courses { get; set; }
        public SelectList Semesters { get; set; }
        public int CourseSemester { get; set; }
        public SelectList Programmes { get; set; }
        public string CourseProgramme { get; set; }
        public string SearchString { get; set; }
    }
}
