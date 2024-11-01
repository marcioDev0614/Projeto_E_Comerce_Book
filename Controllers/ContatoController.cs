using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LivroEC_V2.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View();
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
