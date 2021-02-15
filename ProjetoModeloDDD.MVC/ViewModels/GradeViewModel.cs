using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class GradeViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Value")]
        public string Value { get; set; }

        [Required(ErrorMessage = "Preencha o Subject")]
        public int SubjectId { get; set; }

        [Required(ErrorMessage = "Preencha o Student")]
        public int StudentId { get; set; }

        public virtual StudentViewModel Student { get; set; }

        public virtual SubjectViewModel Subject { get; set; }
    }
}