using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RickLocalization.Domain;
using RickLocalization.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagensController : ControllerBase
    {
        private readonly IViagemService _viagemService;

        public ViagensController(IViagemService viagemService)
        {
            _viagemService = viagemService;
        }

        [HttpGet("{id}", Name = "ObterViagem")]
        public async Task<ActionResult<Viagem>> GetViagem(int id)
        {
            try
            {
                return await _viagemService.GetViagemById(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro na conexão ao listar Viagem com id {id}"); ;
            }
        }

        [HttpGet("comRickId/{id}")]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetWithRick(int id)
        {
            try
            {
                var viagens = await _viagemService.GetViagemByRickId(id);
                
                return viagens.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro na conexão ao listar Viagem com id {id}"); 
            }
        }

        [HttpPost]
        public async Task<ActionResult<Viagem>> Post(Viagem viagem)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState.Values.SelectMany(error => error.Errors));
                }

                await _viagemService.AddViagem(viagem);

                return new CreatedAtRouteResult("ObterViagem", new { id = viagem.ViagemId }, viagem);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    "Erro ao criar uma nova Viagem!");
            }
        }
    }
}
