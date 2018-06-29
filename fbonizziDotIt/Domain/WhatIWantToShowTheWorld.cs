using System;
using System.Collections.Generic;

namespace fbonizziDotIt.Domain
{
    public class WhatIWantToShowTheWorld
    {
        public ContactInfos ContactInfos { get; }
        public IEnumerable<PortfolioItem> Portfolio { get; }
        public CurriculumVitae CurriculumVitae { get; }

        public WhatIWantToShowTheWorld(
            ContactInfos contactInfos,
            IEnumerable<PortfolioItem> portfolio,
            CurriculumVitae curriculumVitae)
        {
            ContactInfos = contactInfos ?? throw new ArgumentNullException(nameof(contactInfos));
            Portfolio = portfolio ?? throw new ArgumentNullException(nameof(portfolio));
            CurriculumVitae = curriculumVitae ?? throw new ArgumentNullException(nameof(curriculumVitae));
        }
    }
}
