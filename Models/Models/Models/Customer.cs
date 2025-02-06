using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerNumber { get; set; }

        [StringLength(20)]
        [Required]
        public string FullName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

    }
}
