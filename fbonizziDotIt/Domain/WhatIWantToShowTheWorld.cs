using System;

namespace fbonizziDotIt.Domain
{
    public class WhatIWantToShowTheWorld
    {
        public SocialInfos ContactInfos { get; }
        public CurriculumVitae CurriculumVitae { get; }

        public WhatIWantToShowTheWorld(
            SocialInfos contactInfos,
            CurriculumVitae curriculumVitae)
        {
            ContactInfos = contactInfos ?? throw new ArgumentNullException(nameof(contactInfos));
            CurriculumVitae = curriculumVitae ?? throw new ArgumentNullException(nameof(curriculumVitae));
        }
    }
}
