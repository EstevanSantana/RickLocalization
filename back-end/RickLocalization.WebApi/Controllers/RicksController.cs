using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class RicksController : ControllerBase
    {
        private readonly IRickService _rickService;

        public RicksController(IRickService rickService)
        {
            _rickService = rickService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rick>>> Get()
        {
            try
            {
                var ricks = await _rickService.GetRicks();

                return ricks.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro na conexão ao listar todas as Ricks");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rick>> Get(int id)
        {
            try
            {
                return await _rickService.GetRickByIdFull(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                        $"Erro na conexão ao listar Rick com id {id}"); ;
            }
        }
    }
}
