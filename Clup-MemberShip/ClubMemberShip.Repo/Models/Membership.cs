using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubMemberShip.Repo.Models
{
    public partial class Membership : BaseEntity
    {
        public Membership()
        {
            MemberRoles = new HashSet<MemberRole>();
            Participants = new HashSet<Participant>();
        }

        public int StudentId { get; set; }
        public int ClubId { get; set; }
        public int Id { get; set; }
        [DataType(DataType.Date)] public DateTime? JoinDate { get; set; }
        [DataType(DataType.Date)] public DateTime? QuitDate { get; set; }
        public string? NickName { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}