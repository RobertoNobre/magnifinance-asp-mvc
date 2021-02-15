using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class CourseAppService : AppServiceBase<Course>, ICourseAppService
    {
        private readonly ICourseService _courseService;

        public CourseAppService(ICourseService courseService)
            : base(courseService)
        {
            _courseService = courseService;
        }
    }
}
