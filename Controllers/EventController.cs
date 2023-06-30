using laba6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace laba6.Controllers
{
    public class EventController : Controller
    {
        private readonly EventsContext _eventContext;

        public EventController(EventsContext eventContext)
        {
            _eventContext = eventContext;
        }
        public IActionResult Index()
        {
            List<Event> events = _eventContext.Events.ToList();
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Event @event)
        {
            int maxId = await _eventContext.Events.MaxAsync(a => a.Id);

            int newId = maxId + 1;

            @event.Id = newId;

            _eventContext.Events.Add(@event);
            await _eventContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Event @event = await _eventContext.Events.FirstOrDefaultAsync(p => p.Id == id);
                if (@event != null)
                    return View(@event);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Event user = await _eventContext.Events.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Event user)
        {
            _eventContext.Events.Update(user);
            await _eventContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Event user = await _eventContext.Events.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Event user = await _eventContext.Events.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    _eventContext.Events.Remove(user);
                    await _eventContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
