using System.Data.Entity.ModelConfiguration;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModeloDDD.Infra.Data.EntityConfig
{
    public class GradeConfiguration : EntityTypeConfiguration<Grade>
    {
        public GradeConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Value)
                .IsRequired();

            Property(p => p.SubjectId)
                .IsRequired();

            Property(p => p.StudentId)
                .IsRequired();
        }
    }
}
