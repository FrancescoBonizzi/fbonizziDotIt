using fbonizziDotIt.Data.Infrastructure;
using fbonizziDotIt.Domain;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Data
{
    public class JsonFileDataProvider : IDataProvider
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _webSiteInfosJsonFilePath;

        public JsonFileDataProvider()
        {
            _webSiteInfosJsonFilePath = "webSiteInfos.json";
        }

        public async Task<WhatIWantToShowTheWorld> GetData(CancellationToken cancellationToken)
        {
            var webSiteInfosJson = await File.ReadAllTextAsync(_webSiteInfosJsonFilePath);
            var webSiteInfos = JsonConvert.DeserializeObject<WebSiteInfos>(webSiteInfosJson);

            // Get my curriculum vitae infos from my GitHub page
            var curriculumVitaeResponse = await _httpClient.GetAsync(
                webSiteInfos.CurriculumVitaeJsonUrl,
                cancellationToken);
            curriculumVitaeResponse.EnsureSuccessStatusCode();
            var curriculumVitaeJson = await curriculumVitaeResponse.Content.ReadAsStringAsync();
            var curriculumVitae = JsonConvert.DeserializeObject<CurriculumVitae>(curriculumVitaeJson);

            return new WhatIWantToShowTheWorld(
                webSiteInfos.ContactInfos,
                webSiteInfos.Portfolio,
                curriculumVitae);
        }
    }
}
