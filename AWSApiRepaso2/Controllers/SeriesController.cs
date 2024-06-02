using AWSApiRepaso2.Models;
using AWSApiRepaso2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWSApiRepaso2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private RepositorySeries repo;
        public SeriesController(RepositorySeries repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Serie>>> GetSeries()
        {
            return await this.repo.GetSeriesAsync();
        }

        [HttpGet]
        [Route("[action]/{idserie}")]
        public async Task<ActionResult<Serie>> FindSerie(int idserie)
        {
            return await this.repo.FindSerieAsync(idserie);

        }

        [HttpPost]
        public async Task<ActionResult> Create(Serie serie)
        {
            await this.repo.CreateSerieAsync(serie.Nombre , serie.Imagen , serie.Anyo);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Serie serie)
        {
            await this.repo.UpdateSerieAsync(serie.IdSerie, serie.Nombre, serie.Imagen, serie.Anyo);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]/{idserie}")]
        public async Task<ActionResult> Delete(int idserie)
        {
            await this.repo.DeleteSerieAsync(idserie);
            return Ok();
        }

    }
}
