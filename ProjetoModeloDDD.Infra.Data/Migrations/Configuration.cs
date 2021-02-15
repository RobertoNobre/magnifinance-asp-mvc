namespace ProjetoModeloDDD.Infra.Data.Migrations
{
    using ProjetoModeloDDD.Domain.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ProjetoModeloContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ProjetoModeloContext context)
        {
            context.Courses.AddOrUpdate(course => course.Id,
                new Course
                {
                    Id = 1,
                    Name = "Course 1",
                }
            );

            context.Subjects.AddOrUpdate(subject => subject.Id,
                new Subject
                {
                    Id = 1,
                    Name = "Subject 1",
                    CourseId = 1,
                    TeacherId = 1
                }
            );

            context.Students.AddOrUpdate(student => student.Id,
                new Student
                {
                    Id = 1,
                    Name = "Student 1",
                    RegistryNumber = 100603,
                }
            );

            context.Teachers.AddOrUpdate(teacher => teacher.Id,
                new Teacher
                {
                    Id = 1,
                    Name = "Teacher 1",
                    Birthday = new DateTime(2020, 11, 06),
                    Salary = 6000,
                }
            );

            context.Grades.AddOrUpdate(grades => grades.Id,
                new Grade
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1,
                    Value = 10
                }
            );

            context.StudentSubjects.AddOrUpdate(studentSubjects => studentSubjects.Id,
                new StudentSubject
                {
                    Id = 1,
                    StudentId = 1,
                    SubjectId = 1
                }
            );
        }
    }
}
