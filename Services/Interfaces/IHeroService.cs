using TOHFerkey.Models;

namespace TOHFerkey.Services.Interfaces
{
    public interface IHeroService
    {
        Task<IEnumerable<Hero>> GetHeroesAsync(int? limit);
        Task<Hero> GetHeroAsync(int id);
        Task<Hero> UpdateHeroAsync(Hero hero);
        Task<Hero> AddHeroAsync(Hero hero);
        Task<Hero> DeleteHeroAsync(int id);
        Task<IEnumerable<Hero>> SearchHeroesAsync(string term);
    }
}
