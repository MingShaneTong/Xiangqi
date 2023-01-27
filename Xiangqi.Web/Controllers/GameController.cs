using Microsoft.AspNetCore.Mvc;

namespace Xiangqi.Web.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
