using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentAppService _studentApp;

        public StudentsController(IStudentAppService studentApp)
        {
            _studentApp = studentApp;
        }

        // GET: Students
        public ActionResult Index()
        {
            var studentViewModel = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(_studentApp.GetAll());
            return View(studentViewModel);
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var student = _studentApp.GetById(id);
            var studentViewModel = Mapper.Map<Student, StudentViewModel>(student);

            return View(studentViewModel);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var studentDomain = Mapper.Map<StudentViewModel, Student>(student);
                _studentApp.Add(studentDomain);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _studentApp.GetById(id);
            var studentViewModel = Mapper.Map<Student, StudentViewModel>(student);

            return View(studentViewModel);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel student)
        {
            if (ModelState.IsValid)
            {
                var studentDomain = Mapper.Map<StudentViewModel, Student>(student);
                _studentApp.Update(studentDomain);

                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _studentApp.GetById(id);
            var studentViewModel = Mapper.Map<Student, StudentViewModel>(student);

            return View(studentViewModel);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentApp.GetById(id);
            _studentApp.Remove(student);

            return RedirectToAction("Index");
        }
    }
}
