using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShop2.Models
{
    public class Teacher
    {//primaren kluc
        public int Id { get; set; }

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

        //obrazovanie
        [Required]
        [StringLength(50)]
        [Display(Name = "Степен на образование")]
        public string Degree { get; set; }

        //akademski rang
        [Required]
        [StringLength(25)]
        [Display(Name = "Академски ранг")]
        public string AcademicRank { get; set; }

        //kancelarija
        [Required]
        [StringLength(10)]
        [Display(Name = "Канцеларија")]
        public string OfficeNumber { get; set; }

        //datum na vrabotuvanje
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Датум на вработување")]
        public DateTime? HireDate { get; set; }

        //celo ime
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //nadvoresen kluc od Course kon Teacher klasa
        public virtual ICollection<Course> FirstCourses { get; set; }
        public virtual ICollection<Course> SecondCourses { get; set; }
    }
}
