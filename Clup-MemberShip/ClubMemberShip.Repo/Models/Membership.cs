using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class Membership
    {
        public Membership()
        {
            MemberRoles = new HashSet<MemberRole>();
            Participants = new HashSet<Participant>();
        }

        public string StudentId { get; set; } = null!;
        public int ClubId { get; set; }
        public int Id { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? QuitDate { get; set; }
        public string? NickName { get; set; }
        public int? Status { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
