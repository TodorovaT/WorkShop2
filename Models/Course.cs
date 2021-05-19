using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShop2.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Име")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Кредити")]
        public int Credits { get; set; }

        [Required]
        [Display(Name = "Семестар")]
        public int Semester { get; set; }

        [Required]
        [Display(Name = "Смер")]
        [StringLength(100)]
        public string Programme { get; set; }

        [Required]
        [Display(Name = "Степен на образование")]
        [StringLength(25)]
        public string EducationLevel { get; set; }


        public int? FirstTeacherId { get; set; }
        [InverseProperty("FirstCourses")]
        [Display(Name = "Професор")]
        public virtual Teacher FirstTeacher { get; set; }


        public int? SecondTeacherId { get; set; }
        [InverseProperty("SecondCourses")]
        [Display(Name = "Асистент")]
        public virtual Teacher SecondTeacher { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
