using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManage.Data;
using FlightManage.Entity;
using FlightManage.Models.Flight;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManage.Controllers
{
    public class FlightController : Controller
    {
        private readonly FlightDbContext _context;

        private const int PageSize = 10;

        public FlightController()
        {
            _context = new FlightDbContext();
        }

        //Get: Flight/Create
        public IActionResult Create()
        {
            FlightCreateViewModel model = new FlightCreateViewModel();
            return View(model);
        }

        //POST: Flight/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(FlightCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flight flight = new Flight
                {
                    Id = model.Id,
                    LocationFrom = model.LocationFrom,
                    LocationTo = model.LocationTo,
                    TakeOffTime = model.TakeOffTime,
                    LandingTime = model.LandingTime,
                    AircraftType = model.AircraftType,
                    PilotName = model.PilotName,
                    PassengerCapacity = model.PassengerCapacity,
                    BusinessPassengerCapacity = model.BusinessPassengerCapacity
                };

                _context.Add(flight);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Get: Flight/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            Flight flight = await _context.Flights.FindAsync(id);

            if (flight == null)
            {
                return NotFound();
            }

            FlightEditViewModel model = new FlightEditViewModel
            {
                Id = flight.Id,
                LocationFrom = flight.LocationFrom,
                LocationTo = flight.LocationTo,
                TakeOffTime = flight.TakeOffTime,
                LandingTime = flight.LandingTime,
                AircraftType = flight.AircraftType,
                PilotName = flight.PilotName,
                PassengerCapacity = flight.PassengerCapacity,
                BusinessPassengerCapacity = flight.BusinessPassengerCapacity
            };

            return View(model);
        }

        //POST: Flight/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(FlightEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Flight flight = new Flight
                {
                    Id = model.Id,
                    LocationFrom = model.LocationFrom,
                    LocationTo = model.LocationTo,
                    TakeOffTime = model.TakeOffTime,
                    LandingTime = model.LandingTime,
                    AircraftType = model.AircraftType,
                    PilotName = model.PilotName,
                    PassengerCapacity = model.PassengerCapacity,
                    BusinessPassengerCapacity = model.BusinessPassengerCapacity
                };

                try
                {
                    _context.Update(flight);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //GET: Flight/Delete

        public async Task<IActionResult> Delete(int Id)
        {
            Flight flight = await _context.Flights.FindAsync(Id);
            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(int id)
        {
            return _context.Flights.Any(e => e.Id != id);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}