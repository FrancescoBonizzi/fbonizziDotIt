using System;

namespace fbonizziDotIt.Domain
{
    /// <summary>
    /// It describes an experience occured in a certain time range
    /// </summary>
    public class Experience
    {
        /// <summary>
        /// The experience description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// When this experience began
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// When this experience ended
        /// </summary>
        public DateTime? To { get; set; }
    }
}
