using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Services;

namespace Web.Pages
{
    public class LiveModel : PageModel
    {
        private readonly IDataService service;

        public string LiveURL { get; set; }

        public LiveModel(IDataService service)
        {
            this.service = service;
        }
        public async Task OnGetAsync()
        {
            var list = await service.GetStreamVideosAsync();

            if (list.Any())
            {
                LiveURL = list.OrderByDescending(p=>p.DateAdded).First().URL;
            }
        }
    }
}
