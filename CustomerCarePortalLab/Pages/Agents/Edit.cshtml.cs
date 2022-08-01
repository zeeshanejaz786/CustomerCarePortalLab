using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CustomerCarePortalLab.Data;
using CustomerCarePortalLab.Models;

namespace CustomerCarePortalLab.Pages.Agents
    {
    public class EditModel : PageModel
        {
        private readonly CustomerCarePortalLab.Data.ApplicationDbContext _context;

        public EditModel( CustomerCarePortalLab.Data.ApplicationDbContext context )
            {
            _context = context;
            }

        [BindProperty]
        public Agent Agent { get; set; } = default!;

        public List<Ticket> Tickets { get; set; }

        public async Task<IActionResult> OnGetAsync( int? id )
            {
            if (id == null || _context.Agent == null)
                {
                return NotFound();
                }

            var agent = await _context.Agent.FirstOrDefaultAsync( m => m.AgentID == id );
            if (agent == null)
                {
                return NotFound();
                }
            Agent = agent;
            return Page();
            }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync( )
            {
            if (!ModelState.IsValid)
                {
                return Page();
                }

            _context.Attach( Agent ).State = EntityState.Modified;

            try
                {
                await _context.SaveChangesAsync();
                }
            catch (DbUpdateConcurrencyException)
                {
                if (!AgentExists( Agent.AgentID ))
                    {
                    return NotFound();
                    }
                else
                    {
                    throw;
                    }
                }

            return RedirectToPage( "./Index" );
            }

        private bool AgentExists( int id )
            {
            return (_context.Agent?.Any( e => e.AgentID == id )).GetValueOrDefault();
            }
        }
    }
