using System;
using System.Collections.Generic;

namespace fbonizziDotIt.Domain
{
    public class PortfolioItem
    {
        public string Title { get; }
        public string Description { get; }
        public IEnumerable<Link> Links { get; }
        public IEnumerable<Link> Images { get; }
        public IEnumerable<Link> Videos { get; }

        public PortfolioItem(
            string title, 
            string description, 
            IEnumerable<Link> links, 
            IEnumerable<Link> images, 
            IEnumerable<Link> videos)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Links = links ?? throw new ArgumentNullException(nameof(links));
            Images = images ?? throw new ArgumentNullException(nameof(images));
            Videos = videos ?? new List<Link>();
        }
    }
}
