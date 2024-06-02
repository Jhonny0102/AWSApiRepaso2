using AWSApiRepaso2.Context;
using AWSApiRepaso2.Models;
using Microsoft.EntityFrameworkCore;

namespace AWSApiRepaso2.Repositories
{
    public class RepositorySeries
    {
        private SeriesContext context;
        public RepositorySeries(SeriesContext context)
        {
            this.context = context;
        }
        public async Task<List<Serie>> GetSeriesAsync()
        {
            return await this.context.Series.ToListAsync();
        }
        public async Task<Serie> FindSerieAsync(int idserie)
        {
            return await this.context.Series.FirstOrDefaultAsync(z => z.IdSerie == idserie);
        }
        public async Task<int> GetMaxIdAsync()
        {
            int max = await this.context.Series.MaxAsync(z => z.IdSerie);
            return max + 1;
        }
        public async Task CreateSerieAsync(string nombre , string imagen , int anyo)
        {
            Serie serie = new Serie();
            serie.IdSerie = await this.GetMaxIdAsync();
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            await this.context.Series.AddAsync(serie);
            this.context.SaveChanges();
        }

        public async Task UpdateSerieAsync(int idserie, string nombre, string imagen, int anyo)
        {
            Serie serie = await this.FindSerieAsync(idserie);
            serie.Nombre = nombre;
            serie.Imagen = imagen;
            serie.Anyo = anyo;
            this.context.SaveChanges();
        }

        public async Task DeleteSerieAsync(int idserie)
        {
            Serie serie = await this.FindSerieAsync(idserie);
            this.context.Series.Remove(serie);
            this.context.SaveChanges();
        }

    }
}
