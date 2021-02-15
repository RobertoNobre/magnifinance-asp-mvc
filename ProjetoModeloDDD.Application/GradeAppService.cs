using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application
{
    public class GradeAppService : AppServiceBase<Grade>, IGradeAppService
    {
        private readonly IGradeService _gradeService;

        public GradeAppService(IGradeService gradeService)
            : base(gradeService)
        {
            _gradeService = gradeService;
        }
    }
}
