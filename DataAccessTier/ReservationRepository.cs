using EntityTier;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace DataAccessTier
{
    public class ReservationRepository : DataAccessTier.IReservationRepository
    {
        private readonly AppDbContext _context;
        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            return reservation;
        }

        public async Task<Reservation> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;
        }

        public async Task<Reservation> PostReservation(Reservation reservation)
        {
            Reservation reservation1 = reservation;
            var types = await _context.Contacttypes.FindAsync(reservation.Contacttype.Id);
            reservation1.Contacttype = types;
            try
            {
                _context.Reservations.Add(reservation1);
                await _context.SaveChangesAsync();
                return reservation;
            }
            catch (Exception e)
            {
                var message = e.ToString();
                throw;
            }


        }

        public async Task<Reservation> DeleteReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return null;
            }

            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<Reservation> MakeFavorite(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Favorite = true;
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        public async Task<Reservation> MakeUnfavorite(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Favorite = false;
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        //Ranking Methods
        public async Task<Reservation> Ranking5(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Rating = "5";
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        public async Task<Reservation> Ranking4(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Rating = "4";
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        public async Task<Reservation> Ranking3(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Rating = "3";
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        public async Task<Reservation> Ranking2(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Rating = "2";
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }

        public async Task<Reservation> Ranking1(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            reservation.Rating = "1";
            if (reservation == null)
            {
                return null;
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return reservation;

        }


        private bool ReservationExists(int id)
        {
            return _context.Reservations.Any(e => e.Id == id);
        }

    }
}
