﻿using System;
using System.Collections.Generic;

namespace ClubMemberShip.Repo.Models
{
    public partial class Major : BaseEntity
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Detail { get; set; }
        public int Semeter { get; set; }

        public virtual ICollection<Student> Students { get; }
    }
}