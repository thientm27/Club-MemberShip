using ClubMemberShip.Repo.UnitOfWork;

namespace ClubMemberShip.Service.Service;

public abstract class ClubMemberShipService
{
    protected readonly IUnitOfWork UnitOfWork;

    protected ClubMemberShipService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}

public enum Result
{
    Ok,
    Null,
    DuplicatedId,
    NullParameter,
    NullProperties,
}