namespace ClubMemberShip.Repo.Models;

public abstract class BaseEntity
{
    public Status? Status { get; set; }
}

public enum Status
{
    Deleted = -1,
    Na = 0,
    Active = 1,
    Pending = 2,
    Prepare = 3,
    OnGoing = 4,
    Finish = 5,
    Leader = 10,
}
