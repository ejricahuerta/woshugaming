using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Web.Data.Models;
using Web.Services;

namespace Web.Pages
{
    public class ManageModel : PageModel
    {
        private readonly IDataService service;

        public List<StreamVideo> StreamVideos { get; set; } = new List<StreamVideo>();

        [BindProperty]
        [DataType(DataType.Url)]
        public string URL { get; set; }
        public string ErrorMessage { get; set; }

        public ManageModel(IDataService service)
        {
            this.service = service;
        }
        public async Task OnGetAsync()
        {
            var list = await service.GetStreamVideosAsync();
            StreamVideos = list.OrderByDescending(p => p.DateAdded).ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await service.AddNewStreamVideoAsync(URL);

                }
                catch (Exception ex)
                {
                    ErrorMessage = $"{ex.Message}";
                    await PopulateDataAsync();
                    return Page();
                }
                return Redirect("/Manage");
            }
            await PopulateDataAsync();
            return Page();
        }

        private async Task PopulateDataAsync()
        {
            var list = await service.GetStreamVideosAsync();
            StreamVideos = list.OrderByDescending(p => p.DateAdded).ToList();
        }
    }
}
