using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Entity
{
    public class Common
    {
        [Key]
        public int Id { set; get; }
        [Required]
        [StringLength(250)]
        public string NAME { set; get; }

    }
}