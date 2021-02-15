using System.ComponentModel.DataAnnotations;

namespace ProjetoModeloDDD.MVC.ViewModels
{
    public class SubjectViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Name")]
        [MaxLength(250, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }

        public virtual CourseViewModel Course { get; set; }

        public virtual TeacherViewModel Teacher { get; set; }
    }
}