using System.ComponentModel.DataAnnotations;

namespace ClubMemberShip.Repo.Models
{
    public partial class ClubActivity : BaseEntity
    {
        public ClubActivity()
        {
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public int ClubId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDay { get; set; }
        public TimeLineStatus? TimeLine { get; set; }

        public virtual Club Club { get; set; } = null!;
        public virtual ICollection<Participant> Participants { get; set; }
    }
}