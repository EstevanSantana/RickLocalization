using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickLocalization.Service
{
    public class RickService : IRickService
    {
        private readonly IRickRepository _repository;

        public RickService(IRickRepository repository)
        {
            _repository = repository;
        }

        public async Task<Rick> GetRickById(int id)
        {
            try
            {
                return await _repository.GetRickById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar obter Rick com id {id}. {ex.Message}");
            }
        }

        //Metodo retorna todos os dados relacionado a tabela Rick
        public async Task<Rick> GetRickByIdFull(int id)
        {
            try
            {
                return await _repository.GetRickByIdFull(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar obter todos os valores do Rick com id {id}. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Rick>> GetRicks()
        {
            try
            {
                return await _repository.GetRicks();
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Service ao tentar listar todos Rick. {ex.Message}");
            }        
        }
    }
}
