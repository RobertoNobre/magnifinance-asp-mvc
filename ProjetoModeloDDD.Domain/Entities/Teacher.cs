
using System;

namespace ProjetoModeloDDD.Domain.Entities
{
    public class Teacher
    {
        #region Public Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public DateTime Birthday { get; set; }

        #endregion

        #region Public Members

        public object Clone() => MemberwiseClone();

        #endregion
    }
}
