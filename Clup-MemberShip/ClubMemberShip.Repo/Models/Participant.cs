using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class Participant : BaseEntity
    {
        public int MembershipId { get; set; }
        public int ClubActivityId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual ClubActivity ClubActivity { get; set; } = null!;
        public virtual Membership Membership { get; set; } = null!;
    }
}
