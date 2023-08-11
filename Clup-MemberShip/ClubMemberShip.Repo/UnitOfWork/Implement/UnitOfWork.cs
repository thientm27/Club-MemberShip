using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository;
using ClubMemberShip.Repo.Repository.Implement;

namespace ClubMemberShip.Repo.UnitOfWork.Implement;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClubMembershipContext _context = new();
    private IClubActivityRepo? _clubActivityRepo;
    private IClubRepo? _clubRepo;
    private IGradeRepo? _gradeRepo;
    private IMajorRepo? _majorRepo;
    private IStudentRepo? _studentRepo;

    public IClubActivityRepo ClubActivityRepo => _clubActivityRepo ??= new ClubActivityRepo(_context);

    public IClubRepo ClubRepo => _clubRepo ??= new ClubRepo(_context);

    public IGradeRepo GradeRepo => _gradeRepo ??= new GradeRepo(_context);

    public IMajorRepo MajorRepo => _majorRepo ??= new MajorRepo(_context);

    public IStudentRepo StudentRepo => _studentRepo??= new StudentRepo(_context);


    public int SaveChange()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}