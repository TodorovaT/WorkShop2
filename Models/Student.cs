using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShop2.Models
{
    public class Student
    {//primaren kluc
        public int Id { get; set; }

        //indeks
        [Required]
        [StringLength(8)]
        [Display(Name = "Индекс")]
        public string StudentId { get; set; }

        //ime
        [Required]
        [StringLength(50)]
        [Display(Name = "Име")]
        public string FirstName { get; set; }

        //prezime
        [Required]
        [StringLength(50)]
        [Display(Name = "Презиме")]
        public string LastName { get; set; }

        //datum na zapisuvanje
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Датум на запишување")]
        public DateTime? EnrollmentDate { get; set; }

        //vkupen broj na krediti
        [Required]
        [Display(Name = "Кредити")]
        public int AcquiredCredits { get; set; }

        //semestar
        [Required]
        [Display(Name = "Семестар")]
        public int CurrentSemester { get; set; }

        //nivo na studii
        [Required]
        [Display(Name = "Степен на студии")]
        [StringLength(25)]
        public string EducationLevel { get; set; }

        //celo ime
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //nadvoresen kluc preku Enrollment do Course klasa
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
