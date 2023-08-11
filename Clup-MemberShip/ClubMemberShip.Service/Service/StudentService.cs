using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public class StudentService : ClubMemberShipService, IStudentServices
{
    public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public Result DeleteStudent(string id)
    {
        UnitOfWork.StudentRepo.Delete(id);
        return Result.Ok;
    }

    public List<Grade>? GetGrades()
    {
        return UnitOfWork.GradeRepo.GetAll().ToList();
    }

    public List<Major>? GetMajors()
    {
        return UnitOfWork.MajorRepo.GetAll().ToList();
    }

    public Student? GetStudent(string id)
    {
        return UnitOfWork.StudentRepo.GetById(id);
    }

    public List<Student>? GetStudents()
    {
        return UnitOfWork.StudentRepo.GetAll(includeProperties: "Major,Grade").ToList();
    }

    public int Login(string id)
    {
        if (id == "Admin@123")
        {
            return -1;
        }

        return UnitOfWork.StudentRepo.GetById(id) == null ? 0 : 1;
    }

    public Result Register(Student student)
    {
        UnitOfWork.StudentRepo.Create(student);
        return Result.Ok;
    }

    public Result UpdateStudent(Student student)
    {
        UnitOfWork.StudentRepo.Update(student);
        return Result.Ok;
    }
}