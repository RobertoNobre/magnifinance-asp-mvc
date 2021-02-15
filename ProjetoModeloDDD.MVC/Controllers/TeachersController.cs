using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherAppService _teacherApp;

        public TeachersController(ITeacherAppService teacherApp)
        {
            _teacherApp = teacherApp;
        }

        // GET: Teachers
        public ActionResult Index()
        {
            var teacherViewModel = Mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherViewModel>>(_teacherApp.GetAll());
            return View(teacherViewModel);
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int id)
        {
            var teacher = _teacherApp.GetById(id);
            var teacherViewModel = Mapper.Map<Teacher, TeacherViewModel>(teacher);

            return View(teacherViewModel);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                var teacherDomain = Mapper.Map<TeacherViewModel, Teacher>(teacher);
                _teacherApp.Add(teacherDomain);

                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int id)
        {
            var teacher = _teacherApp.GetById(id);
            var teacherViewModel = Mapper.Map<Teacher, TeacherViewModel>(teacher);

            return View(teacherViewModel);
        }

        // POST: Teachers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherViewModel teacher)
        {
            if (ModelState.IsValid)
            {
                var teacherDomain = Mapper.Map<TeacherViewModel, Teacher>(teacher);
                _teacherApp.Update(teacherDomain);

                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int id)
        {
            var teacher = _teacherApp.GetById(id);
            var teacherViewModel = Mapper.Map<Teacher, TeacherViewModel>(teacher);

            return View(teacherViewModel);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var teacher = _teacherApp.GetById(id);
            _teacherApp.Remove(teacher);

            return RedirectToAction("Index");
        }
    }
}
