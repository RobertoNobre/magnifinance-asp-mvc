using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseAppService _courseApp;

        public CoursesController(ICourseAppService courseApp)
        {
            _courseApp = courseApp;
        }

        // GET: Clientes
        public ActionResult Index()
        {
            var courseViewModel = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(_courseApp.GetAll());
            return View(courseViewModel);
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var course = _courseApp.GetById(id);
            var courseViewModel = Mapper.Map<Course, CourseViewModel>(course);

            return View(courseViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var courseDomain = Mapper.Map<CourseViewModel, Course>(course);
                _courseApp.Add(courseDomain);

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {
            var course = _courseApp.GetById(id);
            var courseViewModel = Mapper.Map<Course, CourseViewModel>(course);

            return View(courseViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                var courseDomain = Mapper.Map<CourseViewModel, Course>(course);
                _courseApp.Update(courseDomain);

                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var course = _courseApp.GetById(id);
            var courseViewModel = Mapper.Map<Course, CourseViewModel>(course);

            return View(courseViewModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = _courseApp.GetById(id);
            _courseApp.Remove(course);

            return RedirectToAction("Index");
        }
    }
}
