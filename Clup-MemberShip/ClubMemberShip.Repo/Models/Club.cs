using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubMemberShip.Repo.Models
{
    public partial class Club : BaseEntity
    {
        public Club()
        {
            ClubActivities = new HashSet<ClubActivity>();
            ClubBoards = new HashSet<ClubBoard>();
            Memberships = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Logo { get; set; }
        public string? ShortDecription { get; set; }
        public string? LongDecription { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfEstablishment { get; set; }

        public virtual ICollection<ClubActivity> ClubActivities { get; set; }
        public virtual ICollection<ClubBoard> ClubBoards { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
