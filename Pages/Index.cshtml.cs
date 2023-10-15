using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOHFerkey.Models;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHeroService _heroService;
        public IndexModel(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public IEnumerable<Hero> Heroes { get; set; } = new List<Hero>();

        public async Task OnGet()
        {
            Heroes = await _heroService.GetHeroesAsync(4);
        }
    }
}