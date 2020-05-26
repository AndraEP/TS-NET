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
    public class IndexModel : PageModel
    {
        private readonly RazorPages.Data.RazorPagesContext _context;

        public IndexModel(RazorPages.Data.RazorPagesContext context)
        {
            _context = context;
        }

        public IList<MediaDTO> MediaDTO { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString1 { get; set; }
        public SelectList AlteDetalii { get; set; }
/*        [BindProperty(SupportsGet = true)]
        public string alt_detaliu { get; set; }*/


        [BindProperty(SupportsGet = true)]
        public string SearchString2 { get; set; }
        public SelectList Evenimente { get; set; }
/*        [BindProperty(SupportsGet = true)]
        public string eveniment { get; set; }*/


        [BindProperty(SupportsGet = true)]
        public string SearchString3 { get; set; }
        public SelectList Locuri { get; set; }
/*        [BindProperty(SupportsGet = true)]
        public string loc { get; set; }*/


        [BindProperty(SupportsGet = true)]
        public string SearchString4 { get; set; }
        public SelectList Peisaje { get; set; }
/*        [BindProperty(SupportsGet = true)]
        public string peisaj { get; set; }*/


        [BindProperty(SupportsGet = true)]
        public string SearchString5 { get; set; }
        public SelectList Persoane { get; set; }
/*        [BindProperty(SupportsGet = true)]
        public string persoana { get; set; }*/


        public async Task OnGetAsync()
        {
            var medias = from m in _context.MediaDTO select m;
            if (!string.IsNullOrEmpty(SearchString1))
            {
                medias = medias.Where(s => s.Altele.Contains(SearchString1));
            }
            MediaDTO = await medias.ToListAsync();
            if (!string.IsNullOrEmpty(SearchString2))
            {
                medias = medias.Where(s => s.Evenimente.Contains(SearchString2));
            }
            MediaDTO = await medias.ToListAsync();
            if (!string.IsNullOrEmpty(SearchString3))
            {
                medias = medias.Where(s => s.Locuri.Contains(SearchString3));
            }
            MediaDTO = await medias.ToListAsync();
            if (!string.IsNullOrEmpty(SearchString4))
            {
                medias = medias.Where(s => s.Peisaje.Contains(SearchString4));
            }
            MediaDTO = await medias.ToListAsync();
            if (!string.IsNullOrEmpty(SearchString5))
            {
                medias = medias.Where(s => s.Persoane.Contains(SearchString5));
            }
            MediaDTO = await medias.ToListAsync();
        }
    }
}
