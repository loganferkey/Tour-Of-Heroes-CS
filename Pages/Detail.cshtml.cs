using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;
using TOHFerkey.Models;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IHeroService _heroService;
        public DetailModel(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [BindProperty]
        public Hero Hero { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Hero = await _heroService.GetHeroAsync(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _heroService.UpdateHeroAsync(Hero);
            }

            return Page();
        }
    }
}
