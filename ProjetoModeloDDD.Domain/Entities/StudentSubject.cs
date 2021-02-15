namespace ProjetoModeloDDD.Domain.Entities
{
    public class StudentSubject
    {
        #region Public Properties

        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }

        #endregion

        #region Navigation Properties

        public virtual Subject Subject { get; set; }

        public virtual Student Student { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
