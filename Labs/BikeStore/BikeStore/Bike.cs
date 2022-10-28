using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore
{
    public class Bike
    {
        public int BikeId { get; set; }
        public string Name { get; set; } = null!;
        public string Brand { get; set; }
        public string Category { get; set; }
        public short ModelYear { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{BikeId} - {Name}, {Brand}, {ModelYear}, {Price} ({Category})";
        }
    }
}
