using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaxiCrudCore.Entities
{
    public class Road : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserOrderId { get; set; }
        public Guid UserDriverId { get; set; }
        public Guid CityStartId { get; set; }
        public Guid CityEndId { get; set; }

        public User UserOrder { get; set; }
        public User UserDriver { get; set; }
        public City CityStart { get; set; }
        public City CityEnd { get; set; }
    }
    public class RoadConfiguration : IEntityTypeConfiguration<Road>
    {
        public void Configure(EntityTypeBuilder<Road> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasOne(r => r.UserOrder)
                .WithMany()
                .HasForeignKey(r => r.UserOrderId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.UserDriver)
                .WithMany()
                .HasForeignKey(r => r.UserDriverId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.CityStart)
                .WithMany()
                .HasForeignKey(r => r.CityStartId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(r => r.CityEnd)
                .WithMany()
                .HasForeignKey(r => r.CityEndId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
