using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class StudentSubjectConfiguration : EntityTypeConfiguration<StudentSubject>
    {
        public StudentSubjectConfiguration()
        {
            HasKey(p => p.Id);
        }
    }
}
