using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.WebMVCApp.ThuanVCT.Controllers
{
    public class EventsThuanVctsController : Controller
    {
        //private readonly PRN222_HACKATHONContext _context;
        private readonly IEventsThuanVctService _eventService;
        private readonly IRoundsThuanVctService _roundService;

        public EventsThuanVctsController(IEventsThuanVctService eventService, IRoundsThuanVctService roundService)
        {
            _eventService = eventService;
            _roundService = roundService;
        }

        // GET: EventsThuanVcts
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllAsync();
            return View(events);
        }

        // GET: EventsThuanVcts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var eventsThuanVct = await _context.EventsThuanVcts
            //    .FirstOrDefaultAsync(m => m.EventThuanVctid == id);

            var eventsThuanVct = await _eventService.GetByIdAsync(id.Value);

            if (eventsThuanVct == null)
            {
                return NotFound();
            }

            return View(eventsThuanVct);
        }

        // GET: EventsThuanVcts/Create
        public IActionResult Create()
        {
            ViewData["RoundThuanVctid"] = new SelectList(_roundService.GetAllAsync().Result, "RoundThuanVctid", "RoundName");
            ViewData["Status"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Inactive" },
                new SelectListItem { Value = "1", Text = "Active" }
            }, "Value", "Text");

            return View();
        }

        // POST: EventsThuanVcts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
        //[Bind("EventThuanVctid,EventName,Description,Status,PublishDate,IsActive")]
        EventsThuanVct eventsThuanVct)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(eventsThuanVct);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                await _eventService.CreateAsync(eventsThuanVct);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["RoundThuanVctid"] = new SelectList(_roundService.GetAllAsync().Result, "RoundThuanVctid", "RoundName", eventsThuanVct.RoundsThuanVcts.FirstOrDefault()?.RoundThuanVctid);

            ViewData["RoundThuanVctid"] = new SelectList(_roundService.GetAllAsync().Result, "RoundThuanVctid", "RoundName");
            ViewData["Status"] = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Value = "0", Text = "Inactive" },
                new SelectListItem { Value = "1", Text = "Active" }
            }, "Value", "Text");


            var item = new EventsThuanVct
            {
                EventName = eventsThuanVct.EventName,
                Description = eventsThuanVct.Description,
                Status = eventsThuanVct.Status,
                PublishDate = DateTime.Now, // Set the publish date to the current date and time
                IsActive = eventsThuanVct.IsActive
            };

            return View(eventsThuanVct);
        }

        // GET: EventsThuanVcts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var eventsThuanVct = await _context.EventsThuanVcts.FindAsync(id);

            var eventsThuanVct = await _eventService.GetByIdAsync(id.Value);
            if (eventsThuanVct == null)
            {
                return NotFound();
            }

            ViewData["RoundThuanVctid"] = new SelectList(_roundService.GetAllAsync().Result, "RoundThuanVctid", "RoundName", eventsThuanVct.RoundsThuanVcts.FirstOrDefault()?.RoundThuanVctid);

            return View(eventsThuanVct);
        }

        // POST: EventsThuanVcts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
        //int id, [Bind("EventThuanVctid,EventName,Description,Status,PublishDate,IsActive")] 
        EventsThuanVct eventsThuanVct)
        {
            //if (id != eventsThuanVct.EventThuanVctid)
            if (eventsThuanVct.EventThuanVctid <= 0)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(eventsThuanVct);
                    //await _context.SaveChangesAsync();
                    await _eventService.UpdateAsync(eventsThuanVct);
                }
                //catch (DbUpdateConcurrencyException)
                catch (Exception ex)
                {
                    //if (!EventsThuanVctExists(eventsThuanVct.EventThuanVctid))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                    throw new Exception($"An error occurred while updating the event with ID {eventsThuanVct.EventThuanVctid}: {ex.Message}");
                }
                return RedirectToAction(nameof(Index));
            }

            //View Data
            ViewData["RoundThuanVctid"] = new SelectList(_roundService.GetAllAsync().Result, "RoundThuanVctid", "RoundName", eventsThuanVct.RoundsThuanVcts.FirstOrDefault()?.RoundThuanVctid);

            return View(eventsThuanVct);
        }

        // GET: EventsThuanVcts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var eventsThuanVct = await _context.EventsThuanVcts
            //    .FirstOrDefaultAsync(m => m.EventThuanVctid == id);
            var eventsThuanVct = await _eventService.GetByIdAsync(id.Value);
            if (eventsThuanVct == null)
            {
                return NotFound();
            }

            return View(eventsThuanVct);
        }

        // POST: EventsThuanVcts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //var eventsThuanVct = await _context.EventsThuanVcts.FindAsync(id);
            var eventsThuanVct = await _eventService.GetByIdAsync(id);
            if (eventsThuanVct != null)
            {
                //_context.EventsThuanVcts.Remove(eventsThuanVct);
                await _eventService.DeleteAsync(id);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool EventsThuanVctExists(int id)
        //{
        //    return _context.EventsThuanVcts.Any(e => e.EventThuanVctid == id);
        //}
    }
}
