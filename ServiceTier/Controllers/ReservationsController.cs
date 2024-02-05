using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessTier;
using EntityTier;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;

namespace ServiceTier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {

        private IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;

        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            return await _reservationRepository.GetReservations();
        }


        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _reservationRepository.GetReservation(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return reservation;
        }

        // PUT: api/Reservations/5        
        [HttpPut("{id}")]
        public async Task<Reservation> PutReservation(int id, Reservation reservation)
        {
            var method = await _reservationRepository.PutReservation(id, reservation);
            if (method == null)
            {
                return null;
            }
            return await _reservationRepository.PutReservation(id, reservation);
        }

        // POST: api/Reservations        
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _reservationRepository.PostReservation(reservation);
            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<Reservation> DeleteReservation(int id)
        {
            return await _reservationRepository.DeleteReservation(id);
        }



        // GET: api/AlphabeticAscending
        [HttpGet]
        [Route("AlphabeticAscending")]
        public IEnumerable<Reservation> AlphabeticAscending()
        {
            return AlphabeticReservationAscending();
        }

        private List<Reservation> AlphabeticReservationAscending()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AlphabeticReservationAscending";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Reservation> listado = new List<Reservation>();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xContactname = ds.Tables[0].Rows[i][1].ToString();
                var xContacttypeId = ds.Tables[0].Rows[i][2].ToString();
                var xPhonenumber = ds.Tables[0].Rows[i][3].ToString();
                var xBirthdate = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                var xDescription = ds.Tables[0].Rows[i][5].ToString();
                var xRating = ds.Tables[0].Rows[i][6].ToString();
                var xDateBooking = DateTime.Parse(ds.Tables[0].Rows[i][7].ToString());
                var xFavorite = Boolean.Parse(ds.Tables[0].Rows[i][8].ToString());

                Reservation auxiliarRes = new Reservation(xid, xContactname, xPhonenumber,
                    xBirthdate, xDescription, xRating, xDateBooking, xFavorite);
                listado.Add(auxiliarRes);
            }
            connection.Close();
            return listado;
        }



        // GET: api/AlphabeticDescending
        [HttpGet]
        [Route("AlphabeticDescending")]
        public IEnumerable<Reservation> AlphabeticDescending()
        {
            return AlphabeticReservationDescending();
        }
        private List<Reservation> AlphabeticReservationDescending()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "AlphabeticReservationDescending";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Reservation> listado = new List<Reservation>();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xContactname = ds.Tables[0].Rows[i][1].ToString();
                var xContacttypeId = ds.Tables[0].Rows[i][2].ToString();
                var xPhonenumber = ds.Tables[0].Rows[i][3].ToString();
                var xBirthdate = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                var xDescription = ds.Tables[0].Rows[i][5].ToString();
                var xRating = ds.Tables[0].Rows[i][6].ToString();
                var xDateBooking = DateTime.Parse(ds.Tables[0].Rows[i][7].ToString());
                var xFavorite = Boolean.Parse(ds.Tables[0].Rows[i][8].ToString());

                Reservation auxiliarRes = new Reservation(xid, xContactname, xPhonenumber,
                    xBirthdate, xDescription, xRating, xDateBooking, xFavorite);
                listado.Add(auxiliarRes);
            }
            connection.Close();
            return listado;
        }




        // GET: api/DateAscending
        [HttpGet]
        [Route("DateAscending")]
        public IEnumerable<Reservation> DateAscending()
        {
            return DateReservationAscending();
        }

        private List<Reservation> DateReservationAscending()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DateReservationAscending";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Reservation> listado = new List<Reservation>();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xContactname = ds.Tables[0].Rows[i][1].ToString();
                var xContacttypeId = ds.Tables[0].Rows[i][2].ToString();
                var xPhonenumber = ds.Tables[0].Rows[i][3].ToString();
                var xBirthdate = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                var xDescription = ds.Tables[0].Rows[i][5].ToString();
                var xRating = ds.Tables[0].Rows[i][6].ToString();
                var xDateBooking = DateTime.Parse(ds.Tables[0].Rows[i][7].ToString());
                var xFavorite = Boolean.Parse(ds.Tables[0].Rows[i][8].ToString());

                Reservation auxiliarRes = new Reservation(xid, xContactname, xPhonenumber,
                    xBirthdate, xDescription, xRating, xDateBooking, xFavorite);
                listado.Add(auxiliarRes);
            }
            connection.Close();
            return listado;
        }

        // GET: api/DateDescending
        [HttpGet]
        [Route("DateDescending")]
        public IEnumerable<Reservation> DateDescending()
        {
            return DateReservationDescending();
        }

        private List<Reservation> DateReservationDescending()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "DateReservationDescending";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Reservation> listado = new List<Reservation>();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xContactname = ds.Tables[0].Rows[i][1].ToString();
                var xContacttypeId = ds.Tables[0].Rows[i][2].ToString();
                var xPhonenumber = ds.Tables[0].Rows[i][3].ToString();
                var xBirthdate = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                var xDescription = ds.Tables[0].Rows[i][5].ToString();
                var xRating = ds.Tables[0].Rows[i][6].ToString();
                var xDateBooking = DateTime.Parse(ds.Tables[0].Rows[i][7].ToString());
                var xFavorite = Boolean.Parse(ds.Tables[0].Rows[i][8].ToString());

                Reservation auxiliarRes = new Reservation(xid, xContactname, xPhonenumber,
                    xBirthdate, xDescription, xRating, xDateBooking, xFavorite);
                listado.Add(auxiliarRes);
            }
            connection.Close();
            return listado;
        }



        // GET: api/Ranking
        [HttpGet]
        [Route("Ranking")]
        public IEnumerable<Reservation> Ranking()
        {
            return ReservationRanking();
        }

        private List<Reservation> ReservationRanking()
        {
            string connetionString = null;
            SqlConnection connection;
            SqlDataAdapter adapter;
            SqlCommand command = new SqlCommand();
            DataSet ds = new DataSet();
            int i = 0;

            connetionString = "data source=DESKTOP-44MPC1H\\SQLEXPRESS;Initial Catalog=newdb;integrated security=true;";
            connection = new SqlConnection(connetionString);
            connection.Open();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "ReservationRanking";
            adapter = new SqlDataAdapter(command);
            adapter.Fill(ds);
            List<Reservation> listado = new List<Reservation>();
            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                var xid = Int32.Parse(ds.Tables[0].Rows[i][0].ToString());
                var xContactname = ds.Tables[0].Rows[i][1].ToString();
                var xContacttypeId = ds.Tables[0].Rows[i][2].ToString();
                var xPhonenumber = ds.Tables[0].Rows[i][3].ToString();
                var xBirthdate = DateTime.Parse(ds.Tables[0].Rows[i][4].ToString());
                var xDescription = ds.Tables[0].Rows[i][5].ToString();
                var xRating = ds.Tables[0].Rows[i][6].ToString();
                var xDateBooking = DateTime.Parse(ds.Tables[0].Rows[i][7].ToString());
                var xFavorite = Boolean.Parse(ds.Tables[0].Rows[i][8].ToString());

                Reservation auxiliarRes = new Reservation(xid, xContactname, xPhonenumber,
                    xBirthdate, xDescription, xRating, xDateBooking, xFavorite);
                listado.Add(auxiliarRes);
            }
            connection.Close();
            return listado;
        }


        [HttpGet("Favorite/{id:int}")] // GET /api/Reservations/Favorite/3
        public async Task<ActionResult<Reservation>> MakeFavorite(int id)
        {
            var reservation = await _reservationRepository.MakeFavorite(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }

        [HttpGet("Unfavorite/{id:int}")] // GET /api/Reservations/Favorite/3
        public async Task<ActionResult<Reservation>> MakeUnfavorite(int id)
        {
            var reservation = await _reservationRepository.MakeUnfavorite(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }


        //Rankings Methods

        [HttpGet("Ranking5/{id:int}")] // GET /api/Reservations/Ranking5/3
        public async Task<ActionResult<Reservation>> Ranking5(int id)
        {
            var reservation = await _reservationRepository.Ranking5(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }
        [HttpGet("Ranking4/{id:int}")] // GET /api/Reservations/Ranking4/3
        public async Task<ActionResult<Reservation>> Ranking4(int id)
        {
            var reservation = await _reservationRepository.Ranking4(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }
        [HttpGet("Ranking3/{id:int}")] // GET /api/Reservations/Ranking3/3
        public async Task<ActionResult<Reservation>> Ranking3(int id)
        {
            var reservation = await _reservationRepository.Ranking3(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }
        [HttpGet("Ranking2/{id:int}")] // GET /api/Reservations/Ranking2/3
        public async Task<ActionResult<Reservation>> Ranking2(int id)
        {
            var reservation = await _reservationRepository.Ranking2(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }
        [HttpGet("Ranking1/{id:int}")] // GET /api/Reservations/Ranking1/3
        public async Task<ActionResult<Reservation>> Ranking1(int id)
        {
            var reservation = await _reservationRepository.Ranking1(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return await _reservationRepository.PutReservation(id, reservation);
        }



    }
}
