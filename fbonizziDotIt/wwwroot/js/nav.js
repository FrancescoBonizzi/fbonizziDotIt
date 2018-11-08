var _currentPageUrl = null;

function navigateAsync(url, thenFunction) {

    if (_currentPageUrl !== url) {

        $.get(url)
            .done(function (response) {

                $("#async-content").html(response);
                _currentPageUrl = url;

                if (thenFunction !== undefined) {
                    thenFunction();
                }

            });

    }

    return false;
}

function reloadAsync() {

    $.get(_currentPageUrl)
        .done(function (response) {

            $("#async-content").html(response);

        });

    return false;

}

function loadCurriculumVitaeJson() {

    // A little cache
    var curriculumVitaeJsonRaw = localStorage['curriculumVitaeJsonRaw'];

    if (curriculumVitaeJsonRaw === undefined) {

        $.get("https://raw.githubusercontent.com/FrancescoBonizzi/CurriculumVitaeExporter/master/FrancescoBonizziConsoleCurriculum/FrancescoBonizzi-CV.json")
            .done(function (response) {
                curriculumVitaeJsonRaw = response;
                localStorage['curriculumVitaeJsonRaw'] = curriculumVitaeJsonRaw;
                populateCurriculumPage(JSON.parse(curriculumVitaeJsonRaw));
            });

    }
    else {
        populateCurriculumPage(JSON.parse(curriculumVitaeJsonRaw));
    }

}

function populateCurriculumPage(curriculumVitaeJson) {
    $('#curriculumFullName').text(curriculumVitaeJson.FullName);
    $('#curriculumHeadLine').text(curriculumVitaeJson.Headline);
    $('#curriculumCurrentPosition').text(curriculumVitaeJson.CurrentPosition);
    $('#curriculumBirthDate').text(curriculumVitaeJson.BirthDate);
    $('#curriculumAddress').text(curriculumVitaeJson.Address);
    $('#curriculumEmail').text(curriculumVitaeJson.Email);
    $('#curriculumEmail').attr("href", "mailto: " + curriculumVitaeJson.Email);

    curriculumVitaeJson.Experiences.forEach(function (experience) {
        $("#curriculumVitaeExperiences").append(`<li>&middot; ${getExperienceDescription(experience)}</li>`);
    });

    curriculumVitaeJson.Education.forEach(function (education) {
        $("#curriculumVitaeEducation").append(`<li>&middot; ${getExperienceDescription(education)}</li>`);
    });

    curriculumVitaeJson.Skills.forEach(function (skill) {
        $("#curriculumVitaeSkills").append(`<li>&middot; ${skill}</li>`);
    });

    curriculumVitaeJson.Projects.forEach(function (project) {
        $("#curriculumVitaeProjects").append(`<li>&middot; <a href="${project.Url}" alt="Project title" title="Project link" rel="nofollow">${project.Title}</a></li>`);
    });

    curriculumVitaeJson.Hobbies.forEach(function (hobby) {
        $("#curriculumVitaeHobbies").append(`<li>&middot; ${hobby}</li>`);
    });
}

function getExperienceDescription(experience)
{
    var description = experience.Description;

    if (experience.From !== undefined) {
        description = `${description} from ${new Date(experience.From).getFullYear()}`;
        if (experience.To !== undefined)
            description = `${description} to ${new Date(experience.To).getFullYear()}`;
    }

    return description;
}