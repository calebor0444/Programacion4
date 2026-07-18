using DemoMVC.Entidades;
using DemoMVC.Models;
using DemoMVC.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly SongRepository _songRepository;

        public HomeController(ChinookContext context)
        {
            _songRepository = new SongRepository(context);
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var resultado = await _songRepository.ObtenerCancionesPaginadas(page, pageSize: 10);
            return View(resultado);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
