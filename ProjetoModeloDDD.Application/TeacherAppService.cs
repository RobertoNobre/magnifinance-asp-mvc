using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class TeacherAppService : AppServiceBase<Teacher>, ITeacherAppService
    {
        private readonly ITeacherService _teacherService;

        public TeacherAppService(ITeacherService teacherService)
            : base(teacherService)
        {
            _teacherService = teacherService;
        }
    }
}
