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
    [Table("types")]
    public class Types
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        // public virtual Reservation Reservation { get; set; }

        public Types(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;

        }
    }
}
