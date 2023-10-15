using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOHFerkey.Models;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class SearchModel : PageModel
    {
        private readonly IHeroService _heroService;
        public SearchModel(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public IEnumerable<Hero> Heroes { get; set; } = new List<Hero>();

        public async Task OnGet(string? search)
        {
            if (search != null)
                Heroes = await _heroService.SearchHeroesAsync(search);
        }
    }
}
