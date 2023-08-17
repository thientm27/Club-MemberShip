using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClubMemberShip.Repo.Models
{
    public class Grade : BaseEntity
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        [DataType(DataType.Date)] public DateTime GradeYear { get; set; }
        [DataType(DataType.Date)] public DateTime? GraduateYear { get; set; }
        [DataType(DataType.Date)] public DateTime? ExpeiredYear { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}