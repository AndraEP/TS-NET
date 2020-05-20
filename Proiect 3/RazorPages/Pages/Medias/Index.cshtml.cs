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
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Loc { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Locuri { get; set; }
        public async Task OnGetAsync()
        {
            var medias = from m in _context.MediaDTO select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                medias = medias.Where(s => s.Locuri.Contains(SearchString));
            }
            MediaDTO = await _context.MediaDTO.ToListAsync();
        }
    }
}


/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPages.Models;
using ServiceReferenceModelAndApi;

namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        MediaClient mediasCl = new MediaClient();
        public List<MediaDTO> Medias { get; set; }

        public IndexModel()
        {
            Medias = new List<MediaDTO>();
        }

        public async Task OnGetAsync()
        {
            var medias = await mediasCl.ShowDataAsync();
            foreach (var item in (dynamic)medias)
            {
                MediaDTO md = new MediaDTO();
                md.Path = item.Path;
                md.Moved = item.Moved;
                md.Evenimente = item.Evenimente;
                md.Persoane = item.Persoane;
                md.Peisaje = item.Peisaje;
                md.Locuri = item.Locuri;
                md.Altele = item.Altele;
                md.DataCreare = item.DataCreare;

                Medias.Add(md);
            }
        }

    }
}*/
