using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShop2.Models
{
    public class Enrollment
    { //primaren kluc
        public int Id { get; set; }

        //semestar (zimski/leten)
        [Required]
        [Display(Name = "Семестар")]
        [StringLength(10)]
        public string Semester { get; set; }

        //godina
        [Required]
        [Display(Name = "Година на запишување")]
        public int Year { get; set; }

        //ocenka
        [Display(Name = "Факултетска година")]
        public int Grade { get; set; }

        //nadvoresni klucevi do Student i Course klasa
        public int StudentId { get; set; }
        [InverseProperty("Enrollments")]
        [Display(Name = "Студент")]
        public virtual Student Student { get; set; }


        public int CourseId { get; set; }
        [InverseProperty("Enrollments")]
        [Display(Name = "Предмет")]
        public virtual Course Course { get; set; }
    }
}
