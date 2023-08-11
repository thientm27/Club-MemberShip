using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class Grade : BaseEntity
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public DateTime GradeYear { get; set; }
        public DateTime? GraduateYear { get; set; }
        public DateTime? GraduateExpected { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
