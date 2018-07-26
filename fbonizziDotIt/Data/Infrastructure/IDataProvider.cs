using fbonizziDotIt.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Data.Infrastructure
{
    public interface IDataProvider
    {
        Task<CurriculumVitae> GetCurriculumVitae(CancellationToken cancellationToken);
    }
}
