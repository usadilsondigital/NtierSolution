using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityTier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DataAccessTier
{
    public interface IReservationRepository
    {
        Task<ActionResult<IEnumerable<Reservation>>> GetReservations();

        Task<ActionResult<Reservation>> GetReservation(int id);

        Task<Reservation> PutReservation(int id, Reservation reservation);

        Task<Reservation> PostReservation(Reservation reservation);

        Task<Reservation> DeleteReservation(int id);

        Task<Reservation> MakeFavorite(int id);

        Task<Reservation> MakeUnfavorite(int id);

        Task<Reservation> Ranking5(int id);

        Task<Reservation> Ranking4(int id);

        Task<Reservation> Ranking3(int id);

        Task<Reservation> Ranking2(int id);

        Task<Reservation> Ranking1(int id);


    }
}
