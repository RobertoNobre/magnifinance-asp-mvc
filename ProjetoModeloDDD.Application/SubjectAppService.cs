using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Application
{
    public class SubjectAppService : AppServiceBase<Subject>, ISubjectAppService
    {
        private readonly ISubjectService _subjectService;

        public SubjectAppService(ISubjectService subjectService)
            : base(subjectService)
        {
            _subjectService = subjectService;
        }
    }
}
