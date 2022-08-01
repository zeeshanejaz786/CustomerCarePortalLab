using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CustomerCarePortalLab.Data;
using CustomerCarePortalLab.Models;
using Microsoft.AspNetCore.Authorization;

namespace CustomerCarePortalLab.Pages.Organizations
    {
    [Authorize( Policy = "Admin" )]
    public class CreateModel : PageModel
        {
        private readonly CustomerCarePortalLab.Data.ApplicationDbContext _context;

        public CreateModel( CustomerCarePortalLab.Data.ApplicationDbContext context )
            {
            _context = context;
            }

        public IActionResult OnGet( )
            {
            return Page();
            }

        [BindProperty]
        public Organization Organization { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync( )
            {
            if (!ModelState.IsValid || _context.Organization == null || Organization == null)
                {
                return Page();
                }

            _context.Organization.Add( Organization );
            await _context.SaveChangesAsync();

            return RedirectToPage( "./Index" );
            }
        }
    }
