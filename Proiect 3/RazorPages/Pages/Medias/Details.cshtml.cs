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
    public class DetailsModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public DetailsModel(RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

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
    }
}
