using eCommerce.Data;
using eCommerce.Data.Services.ActorServices;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _context;

        public ActorsController(IActorsService context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var actors = await _context.GetAllAsync();
            return View(actors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")]Actor actor)
        {
            if(!ModelState.IsValid)
            {
            return View(actor);
            }
            await _context.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details (int id)
        {
            var details = await _context.GetByIdAsync(id);
            if (details == null)
                return View("NotFound");
            return View(details);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _context.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _context.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _context.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _context.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
           
            await _context.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
