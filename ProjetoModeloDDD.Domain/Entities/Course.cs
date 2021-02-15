
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Course
    {
        #region Public Properties

        public int Id { get; set; }
        public string Name { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<Subject> Subjects { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
