using eCommerce.Context;
using eCommerce.Data.Services.ProducerServices;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var returnedAllProducers = await _service.GetAllAsync();
            return View(returnedAllProducers);
        }

        public async Task<IActionResult> Details(int id)
        {
            var returnedProducer= await _service.GetByIdAsync(id);
            if (returnedProducer != null)
            {
                return View(returnedProducer);
            }
            return View("NotFound");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var returnedProducer = await _service.GetByIdAsync(id);
            if ( returnedProducer != null )
            {
                return View(returnedProducer);
            }
            return View("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
            if (id == producer.Id)
            {
                await _service.UpdateAsync(id,producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var returnedProducer = await _service.GetByIdAsync(id);
            if (returnedProducer != null)
            {
                return View(returnedProducer);
            }
            return View("NotFound");
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var returnedProducer = await _service.GetByIdAsync(id);
            if (returnedProducer == null) return View("NotFound");
            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
