using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Service;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor
{
    public class IndexModel : PageModel
    {
        private readonly IMajorService _majorService;

        public IndexModel(IMajorService majorService)
        {
            _majorService = majorService;
        }

        public IList<Major> Major { get;set; } = default!;

        public void OnGetAsync()
        {
            Major = _majorService.GetAll();
        }
    }
}
