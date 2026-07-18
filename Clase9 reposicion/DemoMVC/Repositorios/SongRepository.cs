using DemoMVC.Entidades;
using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Repositorios
{
    public class SongRepository
    {
        private readonly ChinookContext _context;

        public SongRepository(ChinookContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> ObtenerTodasLasCanciones()
        {
            return await _context.Songs.ToListAsync();
        }

        public async Task<Song?> ObtenerCancionPorId(int id)
        {
            return await _context.Songs.FirstOrDefaultAsync(s => s.SongId == id);
        }

        public async Task<PaginatedResult<Song>> ObtenerCancionesPaginadas(int pageNumber, int pageSize = 10)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            var totalItems = await _context.Songs.CountAsync();

            var canciones = await _context.Songs
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Song>
            {
                Items = canciones,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }
    }
}

