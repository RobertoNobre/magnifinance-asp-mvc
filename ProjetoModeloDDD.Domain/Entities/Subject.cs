using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Subject
    {

        #region Public Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        #endregion

        #region Navigation Properties
        public virtual List<StudentSubject> StudentSubject { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Course Course { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
