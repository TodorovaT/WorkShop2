using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkShop2.Models;
using WorkShop2.ViewModels;

namespace WorkShop2.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly WorkShop2Context _context;

        public EnrollmentsController(WorkShop2Context context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index(string enrollmentCourse, string enrollmentIndex, int enrollmentGrade, string enrollmentSemester)
        {
            IQueryable<Enrollment> enrollments = _context.Enrollment.AsQueryable();
            IQueryable<int> gradeQuery = (IQueryable<int>)_context.Enrollment.OrderBy(m => m.Grade).Select(m => m.Grade).Distinct();
            IQueryable<string> semesterQuery = (IQueryable<string>)_context.Enrollment.OrderBy(m => m.Semester).Select(m => m.Semester).Distinct();

            if (!string.IsNullOrEmpty(enrollmentCourse))
            {
                enrollments = enrollments.Where(s => s.Course.Title.Contains(enrollmentCourse));
            }

            if (!string.IsNullOrEmpty(enrollmentIndex))
            {
                enrollments = enrollments.Where(s => s.Student.StudentId.Contains(enrollmentIndex));
            }

            if (enrollmentGrade != 0)
            {
                enrollments = enrollments.Where(s => s.Grade == enrollmentGrade);
            }

            if (!string.IsNullOrEmpty(enrollmentSemester))
            {
                enrollments = enrollments.Where(s => s.Semester.Contains(enrollmentSemester));
            }

            enrollments = enrollments.Include(m => m.Course).Include(m => m.Student);

            //teachers = teachers.Include(m => m.FirstTeacher).Include(m => m.SecondTeacher);

            var enrollmentCourseIndexVM = new EnrollmentCourseIndexViewModel
            {
                Grades = new SelectList(await gradeQuery.ToListAsync()),
                Semesters = new SelectList(await semesterQuery.ToListAsync()),
                Enrollments = await enrollments.ToListAsync()
            };

            return View(enrollmentCourseIndexVM);
            //var workShop1Context = _context.Course.Include(c => c.FirstTeacher).Include(c => c.SecondTeacher);
            //return View(await workShop1Context.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Semester,Year,Grade,StudentId,CourseId")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Semester,Year,Grade,StudentId,CourseId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}