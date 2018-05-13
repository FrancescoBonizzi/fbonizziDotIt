using System;
using System.Collections.Generic;

namespace fbonizziDotIt.Domain
{
    /// <summary>
    /// A set of curriculum vitae informations
    /// </summary>
    public class CurriculumVitae
    {
        /// <summary>
        /// Name and Surname
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// A brief description of what you do, like "Software developer"
        /// </summary>
        public string Headline { get; set; }

        /// <summary>
        /// Where you are currently working
        /// </summary>
        public string CurrentPosition { get; set; }

        /// <summary>
        /// Your address, could just be your city name
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Your birthdate
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Your photo
        /// </summary>
        public Uri PhotoUrl { get; set; }

        /// <summary>
        /// A list of your skills, such as: PHP, .NET, Java...
        /// </summary>
        public IEnumerable<string> Skills { get; set; }

        /// <summary>
        /// A list of you hobbies
        /// </summary>
        public IEnumerable<string> Hobbies { get; set; }

        /// <summary>
        /// The list of your work experiences, including the current job
        /// </summary>
        public IEnumerable<Experience> Experiences { get; set; }

        /// <summary>
        /// The list of you studies
        /// </summary>
        public IEnumerable<Experience> Education { get; set; }

        /// <summary>
        /// The list of the projects you completed
        /// </summary>
        public IEnumerable<Link> Projects { get; set; }

        /// <summary>
        /// Some links like your LinedIn page, you website...
        /// </summary>
        public IEnumerable<Link> OtherLinks { get; set; }
    }
}
