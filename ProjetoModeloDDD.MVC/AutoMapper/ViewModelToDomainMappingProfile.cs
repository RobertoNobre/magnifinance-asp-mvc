using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Cliente, ClienteViewModel>();
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<Course, CourseViewModel>();
            Mapper.CreateMap<Subject, SubjectViewModel>();
            Mapper.CreateMap<Teacher, TeacherViewModel>();
            Mapper.CreateMap<Student, StudentViewModel>();
            Mapper.CreateMap<Grade, GradeViewModel>();
        }
    }
}