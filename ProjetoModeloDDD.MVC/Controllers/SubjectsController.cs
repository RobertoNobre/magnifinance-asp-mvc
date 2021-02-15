using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        private readonly ISubjectAppService _subjectApp;
        private readonly ICourseAppService _courseApp;
        private readonly ITeacherAppService _teacherApp;

        public SubjectsController(ISubjectAppService subjectApp, ICourseAppService courseApp, ITeacherAppService teacherApp)
        {
            _subjectApp = subjectApp;
            _courseApp = courseApp;
            _teacherApp = teacherApp;
        }

        // GET: Subjects
        public ActionResult Index()
        {
            var subjectViewModel = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(_subjectApp.GetAll());

            return View(subjectViewModel);
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int id)
        {
            var subject = _subjectApp.GetById(id);
            var subjectViewModel = Mapper.Map<Subject, SubjectViewModel>(subject);

            return View(subjectViewModel);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(_courseApp.GetAll(), "Id", "Name");
            ViewBag.TeacherId = new SelectList(_teacherApp.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                var subjectDomain = Mapper.Map<SubjectViewModel, Subject>(subject);
                _subjectApp.Add(subjectDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_courseApp.GetAll(), "Id", "Name", subject.CourseId);
            ViewBag.TeacherId = new SelectList(_teacherApp.GetAll(), "Id", "Name", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int id)
        {
            var subject = _subjectApp.GetById(id);
            var subjectViewModel = Mapper.Map<Subject, SubjectViewModel>(subject);

            ViewBag.CourseId = new SelectList(_courseApp.GetAll(), "Id", "Name", subjectViewModel.CourseId);
            ViewBag.TeacherId = new SelectList(_teacherApp.GetAll(), "Id", "Name", subjectViewModel.TeacherId);

            return View(subjectViewModel);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectViewModel subject)
        {
            if (ModelState.IsValid)
            {
                var subjectDomain = Mapper.Map<SubjectViewModel, Subject>(subject);
                _subjectApp.Update(subjectDomain);

                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(_courseApp.GetAll(), "Id", "Nome", subject.CourseId);
            ViewBag.TeacherId = new SelectList(_teacherApp.GetAll(), "Id", "Name", subject.TeacherId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int id)
        {
            var subject = _subjectApp.GetById(id);
            var subjectViewModel = Mapper.Map<Subject, SubjectViewModel>(subject);

            return View(subjectViewModel);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var subject = _subjectApp.GetById(id);
            _subjectApp.Remove(subject);

            return RedirectToAction("Index");
        }
    }
}