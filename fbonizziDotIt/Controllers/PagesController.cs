using fbonizziDotIt.Data.Infrastructure;
using fbonizziDotIt.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace fbonizziDotIt.Controllers
{
    public class PagesController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public PagesController(IDataProvider dataProvider)
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
                return View(new IndexViewModel(webSiteData.Portfolio));
            }
            catch (Exception ex)
            {
                return RedirectToAction("ApplicationError", "Pages", new { exception = ex });
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
            catch (Exception ex)
            {
                return RedirectToAction("ApplicationError", "Pages", new { exception = ex });
            }
        }

        public IActionResult ApplicationError(Exception exception)
            => View(new ApplicationErrorViewModel(exception));
    }
}
