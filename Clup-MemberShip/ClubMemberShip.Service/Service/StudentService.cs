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

    public Student? GetStudentById(int id)
    {
        return Get().FirstOrDefault(o => o.Id == id);
    }

    public List<Student> GetClubOfStudent(int id)
    {
        return UnitOfWork.StudentRepo.Get(filter: student => student.Id == id, includeProperties: "Major,Grade")
            .ToList();
    }

    public Membership? GetMemberShipById(int id)
    {
        var result = UnitOfWork.MemberShipRepo.Get(filter: student => student.Id == id);
        if (result.Count > 0)
        {
            return result[0];
        }

        return null;
    }

    public Membership? GetMemberShipByClubIdAndStudentId(int studentId, int clubId)
    {
        var result = UnitOfWork.MemberShipRepo.Get(filter: o => o.StudentId == studentId && o.ClubId == clubId);
        if (result.Count > 0)
        {
            return result[0];
        }

        return null;
    }

    public bool CheckRegisterToClub(int studentId, int clubId)
    {
        var result = UnitOfWork.MemberShipRepo.Get(filter: membership =>
            membership.ClubId == clubId && membership.StudentId == studentId);

        if (result.Count > 0 && result[0].Status == Status.Pending) // contain + pending = registerd
        {
            return false;
        }

        return true;
    }

    public Membership? RegisterToClub(Membership membership, bool save = true)
    {
        var existed =
            UnitOfWork.MemberShipRepo.Get(filter: o =>
                o.ClubId == membership.ClubId && o.StudentId == membership.StudentId);

        if (existed.Count > 0 && existed[0].Status == Status.Pending) // Already registered
        {
            return null;
        }

        if (existed.Count > 0) // Already have but out 
        {
            var ship = existed[0];
            ship.Status = Status.Pending;
            UnitOfWork.MemberShipRepo.Update(ship);
            UnitOfWork.SaveChange();
            return ship;
        }

        var maxId = UnitOfWork.MemberShipRepo.GetIgnoreDeleted().Max(o => o.Id);
        membership.Id = maxId + 1;

        var result = UnitOfWork.MemberShipRepo.Create(membership);
        UnitOfWork.SaveChange();
        if (result == null)
        {
            return null;
        }

        result.Status = Status.Pending;
        UnitOfWork.MemberShipRepo.Update(result);
        if (save)
        {
            UnitOfWork.SaveChange();
        }

        return result;
    }

    public Pagination<Student> GetPaginationIgnoreId(int pageIndex, int pageSize, List<int> listIgnore)
    {
        var listEntities = UnitOfWork.StudentRepo.Get(filter: o => !listIgnore.Contains(o.Id));
        return UnitOfWork.StudentRepo.ToPagination(listEntities, pageIndex, pageSize);
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

        return UnitOfWork.StudentRepo.GetByStudentCode(id) == null ? 0 : 1;
    }

    public Result DeleteStudent(string id)
    {
        UnitOfWork.StudentRepo.Delete(id);
        return Result.Ok;
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

    public override Student? GetById(object? id)
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
        var isExisted = UnitOfWork.StudentRepo.Get(filter: st => st.Code == newEntity.Code);
        if (isExisted.Count > 0)
        {
            return Result.DuplicatedId;
        }

        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;

        UnitOfWork.StudentRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }
}