using ClubMemberShip.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMemberShip.Repo.Repository.Interface;

namespace ClubMemberShip.Repo.Repository
{
    public class ClubActivityRepo : GenericRepo<ClubActivity>, IClubActivityRepo
    {
        public override void Delete(object? id)
        {
            throw new NotImplementedException();
        }
    }
}
