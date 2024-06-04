using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrudCore.Entities
{
    public class City : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name {  get; set; }
    }
}
