﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClubMemberShip.Repo.Models;

namespace ClubMemberShip.Web.Pages.PageAdmin.AdminMajor
{
    public class IndexModel : PageModel
    {
        private readonly ClubMemberShip.Repo.Models.ClubMembershipContext _context;

        public IndexModel(ClubMemberShip.Repo.Models.ClubMembershipContext context)
        {
            _context = context;
        }

        public IList<Major> Major { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Majors != null)
            {
                Major = await _context.Majors.ToListAsync();
            }
        }
    }
}
