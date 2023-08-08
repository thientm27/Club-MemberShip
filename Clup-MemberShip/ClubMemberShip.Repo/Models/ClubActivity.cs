using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class ClubActivity
    {
        public ClubActivity()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public int ClubId { get; set; }
        public string StatusId { get; set; } = null!;
        public DateTime StartDay { get; set; }
        public DateTime? EndDay { get; set; }
        public DateTime CreateDay { get; set; }
        public int? Status { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
