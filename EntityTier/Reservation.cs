using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EntityTier
{
    [Table("reservation")]
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Contactname { get; set; }

        /*[Required]
        public string Contacttype { get; set; }*/
        public virtual Types Contacttype { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(8), MinLength(8)]
        public string Phonenumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [Required]
        public string Description { get; set; }


        [Comment("needed according to pictures")]
        [Required]
        [MaxLength(1), MinLength(1)]
        public string Rating { get; set; }


        [Comment("needed according to pictures")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateBooking { get; set; }


        [Comment("needed according to pictures")]
        [Required]
        public bool Favorite { get; set; }

        public Reservation(int Id, string Contactname, string Phonenumber, DateTime Birthdate
            , string Description, string Rating, DateTime DateBooking, bool Favorite)
        {
            this.Id = Id;
            this.Contactname = Contactname;
            this.Phonenumber = Phonenumber;
            this.Birthdate = Birthdate;
            this.Description = Description;
            this.Rating = Rating;
            this.DateBooking = DateBooking;
            this.Favorite = Favorite;
        }


    }
}
