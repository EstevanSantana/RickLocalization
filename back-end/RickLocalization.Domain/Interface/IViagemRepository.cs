using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RickLocalization.Domain
{
    public interface IViagemRepository
    {
        Task<Viagem> GetViagemById(int id);
        Task<Viagem> GetViagemByIdFull(int id);
        Task<IEnumerable<Viagem>> GetViagemByRickId(int id);
        Task AddViagem(Viagem viagem);
    }
}
