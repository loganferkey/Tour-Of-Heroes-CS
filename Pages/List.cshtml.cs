using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOHFerkey.Models;
using TOHFerkey.Services;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class ListModel : PageModel
    {
        private readonly IHeroService _heroService;
        public ListModel(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public IEnumerable<Hero> Heroes { get; set; } = new List<Hero>();

        public async Task<IActionResult> OnGet(string? crud, string? heroId, string? heroName)
        {
            switch (crud)
            {
                case "remove":
                    await _heroService.DeleteHeroAsync(int.Parse(heroId));
                    break;
                case "add":
                    await _heroService.AddHeroAsync(new Hero() { Name = heroName });
                    break;
                default:
                    // nothing!
                    break;
            }

            Heroes = await _heroService.GetHeroesAsync(null);
            return Page();
        }
    }
}
