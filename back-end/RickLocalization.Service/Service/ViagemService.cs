using RickLocalization.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickLocalization.Service
{
    public class ViagemService : IViagemService
    {
        private readonly IViagemRepository _repository;
        private readonly IRickService _rickService;

        public ViagemService(IViagemRepository repository, IRickService rickService)
        {
            _repository = repository;
            _rickService = rickService;
        }

        public async Task AddViagem(Viagem viagem)
        {
            try
            {
                if (viagem == null)
                {
                    throw new ArgumentException("Atenção, adicionar todas as informações");
                }

                await _repository.AddViagem(viagem);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar adicionar uma Viagem. {ex.Message}");
            }
        }

        public Task<Viagem> GetViagemById(int id)
        {
            try
            {
                return _repository.GetViagemById(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar obter Viagem com id {id}. {ex.Message}");
            }
        }

        public async Task<Viagem> GetViagemByIdFull(int id)
        {
            try
            {
                return await _repository.GetViagemByIdFull(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar obter todos os valores de Viagem com id {id}. {ex.Message}");
            }
        }

        public async Task<IEnumerable<Viagem>> GetViagemByRickId(int id)
        {
            try
            {
                var rick = _rickService.GetRickById(id);

                if (rick == null)
                {
                    throw new ArgumentException($"Rick com id {id} não existe!");
                }

                return await _repository.GetViagemByRickId(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Erro no Servico ao tentar obter Viagem com id {id} do Rick. {ex.Message}");
            }
        }

    }
}
