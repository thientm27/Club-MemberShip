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

    public Pagination<Student> GetStudentInClub(int pageIndex, int pageSize, int clubId)
    {
        var joinedList =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && o.Status == Status.Active);
        var studentInClubId = joinedList.Select(joined => joined.StudentId).ToList();
        var listEntities = UnitOfWork.StudentRepo.Get(filter: o => studentInClubId.Contains(o.Id),
            includeProperties: "Major,Grade");
        return UnitOfWork.StudentRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public Pagination<Student> GetStudentRegisterInClub(int pageIndex, int pageSize, int clubId)
    {
        var joinedList =
            UnitOfWork.MemberShipRepo.Get(filter: o => o.ClubId == clubId && o.Status == Status.Pending);
        var studentInClubId = joinedList.Select(joined => joined.StudentId).ToList();
        var listEntities = UnitOfWork.StudentRepo.Get(filter: o => studentInClubId.Contains(o.Id),
            includeProperties: "Major,Grade");
        return UnitOfWork.StudentRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public Pagination<ClubActivity> GetActivityInClub(int pageIndex, int pageSize, int clubId)
    {
        var listEntities = UnitOfWork.ClubActivityRepo.Get(filter: o => o.ClubId == clubId, includeProperties: "Club");
        return UnitOfWork.ClubActivityRepo.ToPagination(listEntities, pageIndex, pageSize);
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

    public Student? GetOwner(int clubId)
    {
        var ownerBoard = UnitOfWork.ClubBoardRepo.Get(filter: o => o.ClubId == clubId && o.Name == "Owner");
        if (ownerBoard.Count == 0)
        {
            return null;
        }

        var memberRole = UnitOfWork.MemberRoleRepo.Get(filter: o => o.ClubBoardId == ownerBoard[0].Id);
        if (memberRole.Count == 0)
        {
            return null;
        }

        var ownerId = memberRole.FirstOrDefault(o => o.Role == 1);
        if (ownerId == null)
        {
            return null;
        }

        var memberShip = UnitOfWork.MemberShipRepo.Get(filter: membership => membership.Id == ownerId.MembershipId);
        var ownerMember = UnitOfWork.StudentRepo.GetById(memberShip[0].StudentId);
        return ownerMember;
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
        var maxId = UnitOfWork.MemberShipRepo.Get().Max(o => o.Id);
        membership.Id = maxId + 1;

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

    public Result UpdateMembership(Membership newEntity)
    {
        UnitOfWork.MemberShipRepo.Update(newEntity);
        UnitOfWork.SaveChange();
        return Result.Ok;
    }

    public Pagination<Club>? GetJoinedClub(int pageIndex, int pageSize, int studentId)
    {
        var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership =>
            membership.StudentId == studentId && membership.Status == Status.Active);
        if (joinedList.Count == 0)
        {
            return null;
        }

        var clubIds = joinedList.Select(joined => joined.ClubId).ToList();
        var listEntities = UnitOfWork.ClubRepo.Get(filter: club => clubIds.Contains(club.Id));

        return UnitOfWork.ClubRepo.ToPagination(listEntities, pageIndex, pageSize);
    }

    public List<Club>? GetJoinedClub(int studentId)
    {
        var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership =>
            membership.StudentId == studentId && membership.Status == Status.Active);
        if (joinedList.Count == 0)
        {
            return null;
        }

        var clubIds = joinedList.Select(joined => joined.ClubId).ToList();
        var listEntities = UnitOfWork.ClubRepo.Get(filter: club => clubIds.Contains(club.Id));

        return listEntities;
    }

    public Pagination<Club> GetAvailableClub(int pageIndex, int pageSize, int studentId)
    {
        var joinedList = UnitOfWork.MemberShipRepo.Get(filter: membership =>
            membership.StudentId == studentId && membership.Status == Status.Active);
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