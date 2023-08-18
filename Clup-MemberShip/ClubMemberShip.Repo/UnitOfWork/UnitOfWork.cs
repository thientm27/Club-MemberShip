using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository;

namespace ClubMemberShip.Repo.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClubMembershipContext _context = new();
    private IClubActivityRepo? _clubActivityRepo;
    private IClubRepo? _clubRepo;
    private IGradeRepo? _gradeRepo;
    private IMajorRepo? _majorRepo;
    private IStudentRepo? _studentRepo;
    private IMemberShipRepo? _memberShipRepo;
    private IClubBoardRepo? _clubBoardRepo;
    private IMemberRoleRepo? _memberRoleRepo;

    public IClubActivityRepo ClubActivityRepo => _clubActivityRepo ??= new ClubActivityRepo(_context);
    public IClubRepo ClubRepo => _clubRepo ??= new ClubRepo(_context);
    public IGradeRepo GradeRepo => _gradeRepo ??= new GradeRepo(_context);
    public IMajorRepo MajorRepo => _majorRepo ??= new MajorRepo(_context);
    public IStudentRepo StudentRepo => _studentRepo ??= new StudentRepo(_context);
    public IMemberShipRepo MemberShipRepo => _memberShipRepo ??= new MemberShipRepo(_context);
    public IClubBoardRepo ClubBoardRepo => _clubBoardRepo ??= new ClubBoardRepo(_context);
    public IMemberRoleRepo MemberRoleRepo => _memberRoleRepo ??= new MemberRoleRepo(_context);


    public int SaveChange()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}