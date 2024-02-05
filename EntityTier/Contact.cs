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
    [Table("contact")]
    public  class Contact
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Contactname { get; set; }
        

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(8), MinLength(8)]
        public string Phonenumber { get; set; }


        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public virtual Types Contacttype { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
