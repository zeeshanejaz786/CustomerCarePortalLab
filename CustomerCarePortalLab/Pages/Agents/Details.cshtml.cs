using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerCarePortalLab.Data;
using CustomerCarePortalLab.Models;

namespace CustomerCarePortalLab.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly CustomerCarePortalLab.Data.ApplicationDbContext _context;

        public DetailsModel(CustomerCarePortalLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Agent Agent { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Agent == null)
            {
                return NotFound();
            }

            var agent = await _context.Agent.FirstOrDefaultAsync(m => m.AgentID == id);
            if (agent == null)
            {
                return NotFound();
            }
            else 
            {
                Agent = agent;
            }
            return Page();
        }
    }
}
