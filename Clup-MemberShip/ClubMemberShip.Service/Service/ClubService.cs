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

    public override Club? GetById(object? id)
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

    public Club? StudentCreateClub(Club newClub, int studentId, out string message)
    {
        // VALIDATION
        message = "";
        var isExisted = UnitOfWork.ClubRepo.Get(filter: club => club.Code == newClub.Code);
        if (isExisted.Count > 0)
        {
            message = "Duplicated Club code";
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
        }, false);

        // CREATE STUDENT JOIN CLUB (membership)
        var memberShip = JoinClub(new Membership
        {
            ClubId = newClub.Id,
            JoinDate = DateTime.Today,
            QuitDate = null,
            NickName = "Club Creator",
            StudentId = studentId,
        }, false);

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
            }, false);
        }


        UnitOfWork.SaveChange();
        return newClub;
    }

    public ClubBoard? CreateClubBoard(ClubBoard newClubBoard, bool save = true)
    {
        var maxId = UnitOfWork.ClubBoardRepo.Get().Max(o => o.Id);
        newClubBoard.Id = maxId + 1;
        var result = UnitOfWork.ClubBoardRepo.Create(newClubBoard);
        if (save)
        {
            UnitOfWork.SaveChange();
        }
       
        return result;
    }

    public Membership? JoinClub(Membership membership, bool save = true)
    {
        var result = UnitOfWork.MemberShipRepo.Create(membership);
        if (save)
        {
            UnitOfWork.SaveChange();
        }
        return result;
    }

    public MemberRole? JoinClubBoard(MemberRole memberRole, bool save = true)
    {
        var result = UnitOfWork.MemberRoleRepo.Create(memberRole);
        if (save)
        {
            UnitOfWork.SaveChange();
        }
        return result;
    }

    public Result? LeaveClub(Membership memberRole, bool save = true)
    {
        if (save)
        {
            UnitOfWork.SaveChange();
        }

        return Result.Ok;
    }

    public Pagination<Club>? GetJoinedClub(int pageIndex, int pageSize, int studentId)
    {
        // var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership => membership.StudentId == studentId);
        // List<Club> listEntities;
        //
        // if (joinedList.Count > 0)
        // {
        //     listEntities = UnitOfWork.ClubRepo.Get(filter: club => joinedList.Any(joined => joined.ClubId == club.Id));
        // }
        // else
        // {
        //     return null;
        // }
        //
        // return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);

        var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership => membership.StudentId == studentId);
        if (joinedList.Count == 0)
        {
            return null;
        }

        var clubIds = joinedList.Select(joined => joined.ClubId).ToList();
        var listEntities = UnitOfWork.ClubRepo.Get(filter: club => clubIds.Contains(club.Id));

        return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public Pagination<Club> GetAvailableClub(int pageIndex, int pageSize, int studentId)
    {
        // var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership => membership.StudentId == studentId);
        // List<Club> listEntities;
        // if (joinedList.Count > 0)
        // {
        //     listEntities = UnitOfWork.ClubRepo.Get(filter: club => joinedList.All(joined => joined.ClubId != club.Id));
        // }
        // else
        // {
        //     listEntities = UnitOfWork.ClubRepo.Get();
        // }
        //
        // return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);

        var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership => membership.StudentId == studentId);
        List<Club> listEntities;

        if (joinedList.Count > 0)
        {
            var joinedClubIds = joinedList.Select(joined => joined.ClubId).ToList();
            listEntities = UnitOfWork.ClubRepo.Get(filter: club => !joinedClubIds.Contains(club.Id));
        }
        else
        {
            listEntities = UnitOfWork.ClubRepo.Get();
        }

        return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);
    }
}