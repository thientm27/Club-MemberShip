using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class ClubBoard : BaseEntity
    {
        public ClubBoard()
        {
            MemberRoles = new HashSet<MemberRole>();
        }

        public int Id { get; set; }
        public int ClubId { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortDecription { get; set; }
        public string? LongDecription { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
