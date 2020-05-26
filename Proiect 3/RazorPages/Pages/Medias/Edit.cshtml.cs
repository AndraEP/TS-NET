using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Medias
{
    public class EditModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public EditModel(RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MediaDTO MediaDTO { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaDTO = await _context.MediaDTO.FirstOrDefaultAsync(m => m.Id == id);

            if (MediaDTO == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MediaDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaDTOExists(MediaDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MediaDTOExists(int id)
        {
            return _context.MediaDTO.Any(e => e.Id == id);
        }
    }
}
