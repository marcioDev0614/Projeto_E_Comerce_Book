using LivroEC_V2.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace LivroEC_V2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {

        private readonly ReletorioVendasServicos _reletorioVendasServicos;

        public AdminRelatorioVendasController(ReletorioVendasServicos reletorioVendasServicos)
        {
            _reletorioVendasServicos = reletorioVendasServicos;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxdate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _reletorioVendasServicos.FindByDateAsync(minDate, maxDate);

            return View(result);
        }
    }
}
