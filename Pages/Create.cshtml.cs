using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TOHFerkey.Models;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IHeroService _heroService;

        public CreateModel(IHeroService heroService)
        {
            _heroService = heroService;
        }

        public async Task OnGet()
        {
        }

        [BindProperty]
        public string HeroName { get; set; }
    }
}
