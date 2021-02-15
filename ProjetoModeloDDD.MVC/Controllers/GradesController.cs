using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class GradesController : Controller
    {
        // GET: Grades
        private readonly IGradeAppService _gradeApp;
        private readonly IStudentAppService _studentApp;
        private readonly ISubjectAppService _subjectApp;

        public GradesController(IGradeAppService gradeApp, IStudentAppService studentApp, ISubjectAppService subjectApp)
        {
            _gradeApp = gradeApp;
            _studentApp = studentApp;
            _subjectApp = subjectApp;
        }

        // GET: Grades
        public ActionResult Index()
        {
            var gradeViewModel = Mapper.Map<IEnumerable<Grade>, IEnumerable<GradeViewModel>>(_gradeApp.GetAll());

            return View(gradeViewModel);
        }

        // GET: Grades/Details/5
        public ActionResult Details(int id)
        {
            var grade = _gradeApp.GetById(id);
            var gradeViewModel = Mapper.Map<Grade, GradeViewModel>(grade);

            return View(gradeViewModel);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(_studentApp.GetAll(), "Id", "Name");
            ViewBag.SubjectId = new SelectList(_subjectApp.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Grades/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeViewModel grade)
        {
            if (ModelState.IsValid)
            {
                var subjectDomain = Mapper.Map<GradeViewModel, Grade>(grade);
                _gradeApp.Add(subjectDomain);

                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(_studentApp.GetAll(), "Id", "Name", grade.StudentId);
            ViewBag.SubjectId = new SelectList(_subjectApp.GetAll(), "Id", "Name", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int id)
        {
            var grade = _gradeApp.GetById(id);
            var gradeViewModel = Mapper.Map<Grade, GradeViewModel>(grade);

            ViewBag.StudentId = new SelectList(_studentApp.GetAll(), "Id", "Name", gradeViewModel.StudentId);
            ViewBag.SubjectId = new SelectList(_subjectApp.GetAll(), "Id", "Name", gradeViewModel.SubjectId);

            return View(gradeViewModel);
        }

        // POST: Grades/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeViewModel grade)
        {
            if (ModelState.IsValid)
            {
                var subjectDomain = Mapper.Map<GradeViewModel, Grade>(grade);
                _gradeApp.Update(subjectDomain);

                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(_studentApp.GetAll(), "Id", "Nome", grade.StudentId);
            ViewBag.SubjectId = new SelectList(_subjectApp.GetAll(), "Id", "Name", grade.SubjectId);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int id)
        {
            var grade = _gradeApp.GetById(id);
            var gradeViewModel = Mapper.Map<Grade, GradeViewModel>(grade);

            return View(gradeViewModel);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var grade = _gradeApp.GetById(id);
            _gradeApp.Remove(grade);

            return RedirectToAction("Index");
        }
    }
}