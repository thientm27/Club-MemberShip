using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class StudentService : GenericService<Student>, IStudentServices
{
    public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public List<Grade>? GetGrades()
    {
        return UnitOfWork.GradeRepo.Get().ToList();
    }

    public List<Major>? GetMajors()
    {
        return UnitOfWork.MajorRepo.Get().ToList();
    }

    public int Login(string id)
    {
        if (id == "Admin@123")
        {
            return -1;
        }

        return UnitOfWork.StudentRepo.GetById(id) == null ? 0 : 1;
    }

    public Result DeleteStudent(string id)
    {
        throw new NotImplementedException();
    }

    public Result Register(Student student)
    {
        UnitOfWork.StudentRepo.Create(student);
        return Result.Ok;
    }


    public override List<Student> Get()
    {
        return UnitOfWork.StudentRepo.Get(includeProperties: "Major,Grade").ToList();
    }

    public override Pagination<Student> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.StudentRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override Student? GetById(object id)
    {
        return UnitOfWork.StudentRepo.GetByStudentCode(id.ToString());
    }

    public override Result Update(Student newEntity)
    {
        UnitOfWork.StudentRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        var id = idToDelete.ToString();
        UnitOfWork.StudentRepo.Delete(id);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Student newEntity)
    {
        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;
        
        UnitOfWork.StudentRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }
}