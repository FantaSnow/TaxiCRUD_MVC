using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCrudCore.Entities
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name {  get; set; } = "None";
        public string SurName { get; set; } = "None";
        public string NumberPhone { get; set; } = "None";
        public string Email { get; set; } = "None";

    }
}
