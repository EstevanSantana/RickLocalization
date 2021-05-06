using System.Collections.Generic;
using System.Threading.Tasks;

namespace RickLocalization.Domain
{
    public interface IRickRepository
    { 
        Task<IEnumerable<Rick>> GetRicks();
        Task<Rick> GetRickById(int id);
        Task<Rick> GetRickByIdFull(int id);
    }
}
