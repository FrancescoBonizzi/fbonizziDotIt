using System;
using System.Collections.Generic;

namespace fbonizziDotIt.Domain
{
    public class WebSiteInfos
    {
        public Uri CurriculumVitaeJsonUrl { get; set; }
        public ContactInfos ContactInfos { get; set; }
        public IEnumerable<PortfolioItem> Portfolio { get; set; }
    }
}
