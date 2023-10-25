using eCommerce.Context;
using eCommerce.Data.Services.ProducerServices;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace eCommerce.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var returnedCinema = await _service.GetAllAsync();
            return View(returnedCinema);
        }
        public async Task<IActionResult> Details(int id)
        {
            var returnedCinema= await _service.GetByIdAsync(id);
            if (returnedCinema != null)
            {
                return View(returnedCinema);
            }
            return View("NotFound");
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);

            await _service.AddAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var returnedCinema = await _service.GetByIdAsync(id);
            if (returnedCinema != null)
            {
                return View(returnedCinema);
            }
            return View("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo, Name, Description")] Cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            if (id == cinema.Id)
            {
                await _service.UpdateAsync(id, cinema);
                return RedirectToAction(nameof(Index));
            }
            return View(cinema);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var returnedCinema = await _service.GetByIdAsync(id);
            if (returnedCinema != null)
            {
                return View(returnedCinema);
            }
            return View("NotFound");
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var returnedCinema = await _service.GetByIdAsync(id);
            if (returnedCinema == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
