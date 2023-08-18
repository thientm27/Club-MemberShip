using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Utils;

namespace ClubMemberShip.Service.Service;

public class ClubService : GenericService<Club>, IClubServices
{
    public ClubService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public override List<Club> Get()
    {
        return UnitOfWork.ClubRepo.Get().ToList();
    }

    public override Pagination<Club> GetPagination(int pageIndex, int pageSize)
    {
        var listEntities = Get();
        return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public override Club? GetById(object id)
    {
        return UnitOfWork.ClubRepo.GetById(id);
    }

    public override Result Update(Club newEntity)
    {
        UnitOfWork.ClubRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Delete(object idToDelete)
    {
        UnitOfWork.ClubRepo.Delete(idToDelete);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public override Result Add(Club newEntity)
    {
        var isExisted = UnitOfWork.ClubRepo.Get(filter: club => club.Code == newEntity.Code);
        if (isExisted.Count > 0)
        {
            return Result.DuplicatedId;
        }

        var maxId = Get().Max(o => o.Id);
        newEntity.Id = maxId + 1;
        newEntity.Status = Status.Active;

        UnitOfWork.ClubRepo.Create(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public Club? StudentCreateClub(Club newClub, int studentId)
    {
        // VALIDATION
        var isExisted = UnitOfWork.ClubRepo.Get(filter: club => club.Code == newClub.Code);
        if (isExisted.Count > 0)
        {
            return null;
        }

        // SET SPECIAL PROPERTIES
        var maxId = Get().Max(o => o.Id);
        newClub.Id = maxId + 1;
        newClub.Status = Status.Pending; // WAIT FOR ADMIN ACCEPT

        // CREATE CLUB
        UnitOfWork.ClubRepo.Create(newClub);
        // CREATE CLUB BOARD
        var newClubBoardCreated = CreateClubBoard(new ClubBoard
        {
            ClubId = newClub.Id,
            Name = "Owner",
            LongDecription = "Manage the club",
            ShortDecription = "Owner club",
        });

        // CREATE STUDENT JOIN CLUB (membership)
        var memberShip = JoinClub(new Membership
        {
            ClubId = newClub.Id,
            JoinDate = DateTime.Today,
            QuitDate = null,
            NickName = "Club Creator",
            StudentId = studentId,
        });

        // CREATE STUDENT JOIN CLUB BOARD (owner)
        if (memberShip != null && newClubBoardCreated != null)
        {
            JoinClubBoard(new MemberRole
            {
                MembershipId = memberShip.Id,
                ClubBoardId = newClubBoardCreated.Id,
                StartDay = DateTime.Today,
                EndDay = default,
                Role = 1,
            });
        }
           


        UnitOfWork.SaveChange();
        return newClub;
    }

    public ClubBoard? CreateClubBoard(ClubBoard newClubBoard)
    {
        throw new NotImplementedException();
    }

    public Membership? JoinClub(Membership membership)
    {
        throw new NotImplementedException();
    }

    public MemberRole? JoinClubBoard(MemberRole memberRole)
    {
        throw new NotImplementedException();
    }

    public Result? LeaveClub(Membership memberRole)
    {
        throw new NotImplementedException();
    }
}