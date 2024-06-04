using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrudCore.Entities
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public double Cost {  get; set; }
        public Road Road { get; set; }
        public Status Status { get; set; }

    }
}
