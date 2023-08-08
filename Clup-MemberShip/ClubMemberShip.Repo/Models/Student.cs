using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class Student
    {
        public Student()
        {
            Memberships = new HashSet<Membership>();
        }

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int MajorId { get; set; }
        public int GradeId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Status? Status { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual Major Major { get; set; } = null!;
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
