using fbonizziDotIt.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Data.Infrastructure
{
    public interface IDataProvider
    {
        Task<WhatIWantToShowTheWorld> GetData(CancellationToken cancellationToken);
    }
}
