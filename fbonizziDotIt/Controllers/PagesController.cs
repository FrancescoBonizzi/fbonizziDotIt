﻿using fbonizziDotIt.Data.Infrastructure;
using fbonizziDotIt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Controllers
{
    public class PagesController : Controller
    {
        private readonly ICachedDataProvider _dataProvider;

        public PagesController(ICachedDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public async Task<IActionResult> Index(
            CancellationToken cancellationToken)
        {
            try
            {
                var webSiteData = await _dataProvider.GetData(cancellationToken);

                ViewBag.ContactInfos = webSiteData.ContactInfos;
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ApplicationError", "Pages");
            }
        }

        public async Task<IActionResult> CurriculumVitae(
            CancellationToken cancellationToken)
        {
            try
            {
                var webSiteData = await _dataProvider.GetData(cancellationToken);

                ViewBag.ContactInfos = webSiteData.ContactInfos;
                return View(new CurriculumVitaeViewModel(webSiteData.CurriculumVitae));
            }
            catch (Exception)
            {
                return RedirectToAction("ApplicationError", "Pages");
            }
        }

        public IActionResult Starfall()
            => View();

        public IActionResult ApplicationError()
            => View(new ApplicationErrorViewModel());
    }
}
