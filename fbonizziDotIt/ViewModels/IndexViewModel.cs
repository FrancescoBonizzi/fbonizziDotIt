using fbonizziDotIt.Domain;
using System;
using System.Collections.Generic;

namespace fbonizziDotIt.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<PortfolioItem> Portfolio { get; }

        public IndexViewModel(IEnumerable<PortfolioItem> portfolio)
        {
            Portfolio = portfolio ?? throw new ArgumentNullException(nameof(portfolio));
        }
    }
}
