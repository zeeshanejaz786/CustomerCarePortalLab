using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CustomerCarePortalLab.Data;
using CustomerCarePortalLab.Models;

namespace CustomerCarePortalLab.Pages.Organizations
{
    public class DeleteModel : PageModel
    {
        private readonly CustomerCarePortalLab.Data.ApplicationDbContext _context;

        public DeleteModel(CustomerCarePortalLab.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Organization Organization { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }

            var organization = await _context.Organization.FirstOrDefaultAsync(m => m.OrganizationID == id);

            if (organization == null)
            {
                return NotFound();
            }
            else 
            {
                Organization = organization;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Organization == null)
            {
                return NotFound();
            }
            var organization = await _context.Organization.FindAsync(id);

            if (organization != null)
            {
                Organization = organization;
                _context.Organization.Remove(Organization);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
