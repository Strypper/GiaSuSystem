using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Location.Menu
{
    public class Food
    {
        public int FoodId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Visualize { get; set; }
        [Column(TypeName = "tinyint")]
        public int Rating { get; set; }
    }
}
