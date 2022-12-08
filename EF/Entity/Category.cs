using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Entity

{
    [Table("Category")]
    public class Category : Common
    {

        [Column(TypeName = "ntext")]
        public string Description { set; get; }
        public List<Product>? listProduct { set; get; }

    }
}