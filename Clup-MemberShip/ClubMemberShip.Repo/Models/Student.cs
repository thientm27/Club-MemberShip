using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubMemberShip.Repo.Models
{
    public partial class Student : BaseEntity
    {
        public Student()
        {
            Memberships = new HashSet<Membership>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public int MajorId { get; set; }
        public int GradeId { get; set; }
        [DataType(DataType.Date)] public DateTime? DateOfBirth { get; set; }
        public virtual Grade? Grade { get; set; } = null!;
        public virtual Major? Major { get; set; } = null!;
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}