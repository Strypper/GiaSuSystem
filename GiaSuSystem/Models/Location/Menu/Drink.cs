using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GiaSuSystem.Models.Location.Menu
{
    public class Drink
    {
        public int DrinkId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DrinkName { get; set; }
        public decimal DrinkPrice { get; set; }
        public string Visualize { get; set; }
        [Column(TypeName = "tinyint")]
        public int Rating { get; set; }
    }
}
