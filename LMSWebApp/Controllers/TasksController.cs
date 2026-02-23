using DataAccessLayer.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace LMSWebApp.Controllers
{
    public class TasksController : Controller
    {
        public readonly ITransient _transient1;
        public readonly ITransient _transient2;

        public readonly IScoped _scoped1;
        public readonly IScoped _scoped2;

        public readonly ISingleton _singleton1;
        public readonly ISingleton _singleton2;
        public TasksController(ITransient transient1, ITransient transient2,
            IScoped scoped1, IScoped scoped2,
            ISingleton singleton1, ISingleton singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }
        public IActionResult Index()
        {
            ViewBag.Transient1 = _transient1.GetGuid().ToString();
            ViewBag.Transient2 = _transient2.GetGuid().ToString();

            ViewBag.Scoped1 = _scoped1.GetGuid().ToString();
            ViewBag.Scoped2 = _scoped2.GetGuid().ToString();

            ViewBag.Singleton1 = _singleton1.GetGuid().ToString();
            ViewBag.Singleton2 = _singleton2.GetGuid().ToString();
            return View();
        }
    }
}
