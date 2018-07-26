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
        private readonly ICachedDataProvider _dataProvider;

        public PagesController(ICachedDataProvider dataProvider)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        }

        public IActionResult Index(CancellationToken cancellationToken)
            => View();

        public async Task<IActionResult> CurriculumVitae(
            CancellationToken cancellationToken)
        {
            try
            {
                var curriculumVitae = await _dataProvider.GetCurriculumVitae(cancellationToken);
                return View(new CurriculumVitaeViewModel(curriculumVitae));
            }
            catch (Exception)
            {
                return RedirectToAction("ApplicationError", "Pages");
            }
        }

        public IActionResult Starfall()
            => View();

        public IActionResult Rellow()
            => View();

        public IActionResult ApplicationError()
            => View(new ApplicationErrorViewModel());
    }
}
