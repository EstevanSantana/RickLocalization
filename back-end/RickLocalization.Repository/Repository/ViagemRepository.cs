using Microsoft.EntityFrameworkCore;
using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public class ViagemRepository : Repository<Viagem>, IViagemRepository
    {
        public ViagemRepository(AppDbContext context) : base(context) { }
            
        public async Task AddViagem(Viagem viagem)
        {
            try
            {
                await Create(viagem);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar adicionar viagem. {ex.Message}");
            }
        }

        public async Task<Viagem> GetViagemById(int id)
        {
            try
            {
                return await GetById(x => x.ViagemId == id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar obter Viagem com id {id}. {ex.Message}");
            }
        }

        public async Task<Viagem> GetViagemByIdFull(int id)
        {
            try
            {
                return await Get().Include(x => x.Dimensao)
                                        .Include(x => x.Rick)
                                            .SingleOrDefaultAsync(x => x.ViagemId == id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar obter todos os valores de Viagem com id {id} do Rick. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Viagem>> GetViagemByRickId(int id)
        {
            try
            {
                return await Get().Include(x => x.Dimensao)
                                        .Where(x => x.RickId == id)
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar obter Viagem com id {id} do Rick. {ex.Message}");
            }
        }

    }
}
