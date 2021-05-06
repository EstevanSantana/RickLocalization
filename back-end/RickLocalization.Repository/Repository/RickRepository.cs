using Microsoft.EntityFrameworkCore;
using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickLocalization.Repository
{
    public class RickRepository : Repository<Rick>, IRickRepository
    {
        public RickRepository(AppDbContext context) : base(context) { }

        public async Task<Rick> GetRickById(int id)
        {
            try
            {
                var pessoa = await GetById(x => x.RickId == id);

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar obter Rick com id {id}. {ex.Message}");
            }
        }

        //Metodo retorna todos os dados relacionado a tabela Rick
        public async Task<Rick> GetRickByIdFull(int id)
        {
            try
            {
                var pessoa = await Get().Include(x => x.Viagens)
                                            .Include(x => x.Origem)
                                                .AsNoTracking()
                                                    .SingleOrDefaultAsync(x => x.RickId == id);

                return pessoa;
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar obter todos os valores do Rick com id {id}. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Rick>> GetRicks()
        {
            try
            {
                return await Get().Include(x => x.Viagens)
                                    .Include(x => x.Origem) 
                                        .AsNoTracking()
                                            .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Repository ao tentar listar todos Rick. {ex.Message}");
            }
        }
    }
}
