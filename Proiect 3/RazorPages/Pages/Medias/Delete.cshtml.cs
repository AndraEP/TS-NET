using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Medias
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public DeleteModel(RazorPages.Data.RazorPagesContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MediaDTO = await _context.MediaDTO.FindAsync(id);

            if (MediaDTO != null)
            {
                _context.MediaDTO.Remove(MediaDTO);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
