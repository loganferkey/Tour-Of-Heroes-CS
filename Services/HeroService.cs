using Microsoft.EntityFrameworkCore;
using TOHFerkey.Data;
using TOHFerkey.Models;
using TOHFerkey.Services.Interfaces;

namespace TOHFerkey.Services
{
    public class HeroService : IHeroService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMessageService _messageService;

        public HeroService(ApplicationDbContext context, 
                           IMessageService messageService)
        {
            _context = context;
            _messageService = messageService;
        }

        public async Task<IEnumerable<Hero>> GetHeroesAsync(int? limit)
        {
            _messageService.Add("HeroService: fetched heroes");
            if (limit != null)
                return await _context.Heroes.Take((int)limit).ToListAsync();
            return await _context.Heroes.ToListAsync();
        }

        public async Task<Hero?> GetHeroAsync(int id)
        {
            Hero? hero = await _context.Heroes.FirstOrDefaultAsync(hero => hero.Id == id);
            if (hero == null)
                return null;
            _messageService.Add($"HeroService: fetched hero id={id}");
            return hero;
        }

        public async Task<Hero> UpdateHeroAsync(Hero hero)
        {
            _context.Heroes.Update(hero);
            await _context.SaveChangesAsync();
            _messageService.Add($"HeroService: updated hero id={hero.Id}");

            return hero;
        }

        public async Task<Hero> AddHeroAsync(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            _messageService.Add($"HeroService: added hero w/ id={hero.Id}");

            return hero;
        }

        public async Task<Hero?> DeleteHeroAsync(int id)
        {
            Hero? hero = await _context.Heroes.FindAsync(id);
            if (hero == null)
                return null;

            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            _messageService.Add($"HeroService: deleted hero id={id}");

            return hero;
        }

        public async Task<IEnumerable<Hero>> SearchHeroesAsync(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                _messageService.Add($"HeroService: no heroes matching \"{term}\"");
                return new List<Hero>();
            }

            IEnumerable<Hero> heroes = await _context.Heroes.Where(hero => hero.Name.Contains(term)).ToListAsync();
            if (heroes.Any())
            {
                _messageService.Add($"HeroService: found heroes matching \"{term}\"");
                return heroes;
            } else
            {
                _messageService.Add($"HeroService: no heroes matching \"{term}\"");
                return new List<Hero>();
            }
        }
    }
}
