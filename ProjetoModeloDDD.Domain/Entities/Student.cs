using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Student
    {
        #region Public Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegistryNumber { get; set; }

        #endregion

        #region Navigation Properties

        public virtual List<StudentSubject> StudentSubjects { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
