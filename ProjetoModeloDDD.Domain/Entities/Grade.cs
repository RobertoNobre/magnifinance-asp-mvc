using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Grade
    {
        #region Public Properties

        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int Value { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
