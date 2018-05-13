using fbonizziDotIt.Domain;
using System;
using System.Globalization;
using System.Text;

namespace fbonizziDotIt.ViewModels
{
    public class CurriculumVitaeViewModel
    {
        public CultureInfo Culture => CultureInfo.InvariantCulture;
        public CurriculumVitae CurriculumVitae { get; }

        public CurriculumVitaeViewModel(
            CurriculumVitae curriculumVitae)
        {
            CurriculumVitae = curriculumVitae ?? throw new ArgumentNullException(nameof(curriculumVitae));
        }

        public string GetExperienceDescription(Experience experience)
        {
            var description = new StringBuilder();

            description.Append(experience.Description);

            if (experience.From != null)
            {
                description.Append($" from {experience.From.Value.Year}");
                if (experience.To != null)
                    description.Append($" to {experience.To.Value.Year}");
            }

            return description.ToString();
        }
    }
}
