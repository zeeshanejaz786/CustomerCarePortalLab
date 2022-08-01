﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerCarePortalLab.Data;
using CustomerCarePortalLab.Models;

namespace CustomerCarePortalLab.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly CustomerCarePortalLab.Data.ApplicationDbContext _context;

        public IndexModel(CustomerCarePortalLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Department> Department { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Department != null)
            {
                Department = await _context.Department.ToListAsync();
            }
        }
    }
}
