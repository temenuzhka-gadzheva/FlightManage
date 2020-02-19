using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightManage.Data;
using FlightManage.Entity;
using FlightManage.Models.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManage.Controllers
{
    public class ReservationController : Controller
    {

        private readonly ReservationDbContext _context;

        private const int PageSize = 10;

        public ReservationController()
        {
            _context = new ReservationDbContext();
        }

        //Get: Reservation/Create
        public IActionResult Create()
        {

            ReservationCreateViewModel model = new ReservationCreateViewModel();
            return View(model);
        }

        //POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ReservationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {

                    Id = model.Id,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    PersonalNumber = model.PersonalNumber,
                    TelephoneNumber = model.TelephoneNumber,
                    Nationality = model.Nationality,
                    TicketNumber = model.TicketNumber
                };

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        //Get: Reservation/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            Reservation reservation = await _context.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            ReservationEditViewModel model = new ReservationEditViewModel
            {

                Id = reservation.Id,
                FirstName = reservation.FirstName,
                MiddleName = reservation.MiddleName,
                LastName = reservation.LastName,
                PersonalNumber = reservation.PersonalNumber,
                TelephoneNumber = reservation.TelephoneNumber,
                Nationality = reservation.Nationality,
                TicketNumber = reservation.TicketNumber
            };

            return View(model);
        }

        //POST: Reservation/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ReservationEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Reservation reservation = new Reservation
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    PersonalNumber = model.PersonalNumber,
                    TelephoneNumber = model.TelephoneNumber,
                    Nationality = model.Nationality,
                    TicketNumber = model.TicketNumber
                };

                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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

        //GET: Reservation/Delete

        public async Task<IActionResult> Delete(int Id)
        {
            Reservation reservation = await _context.Reservations.FindAsync(Id);
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id != id);
        }


    }
}