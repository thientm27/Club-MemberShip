namespace ClubMemberShip.Repo;

public interface IUnitOfWork
{
    public IClubActivityRepo ClubActivityRepo { get; }

    public IClubRepo ClubRepo{ get; }

    public IGradeRepo GradeRepo { get; }

    public IMajorRepo MajorRepo{ get; }

    public IStudentRepo StudentRepo { get; }

    public int SaveChange();
    public Task<int> SaveChangesAsync();
}