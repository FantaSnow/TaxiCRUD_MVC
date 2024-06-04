using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrut.Infrastructure
{
    public class CityModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
    }

    public class CityCreate
    {
        public string Name { get; set; }
    }

    public class CityUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
