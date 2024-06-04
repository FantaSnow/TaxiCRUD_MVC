using TaxiCrudCore.Entities;

namespace TaxiCrut.Infrastructure

{
    public class RoadModel
    {
        public Guid Id { get; set; }
        public User UserOrder { get; set; }
        public User UserDriver { get; set; }
        public City CityStart { get; set; }
        public City CityEnd { get; set; }

    }
    public class RoadCreate
    {
        public User UserOrder { get; set; }
        public User UserDriver { get; set; }
        public City CityStart { get; set; }
        public City CityEnd { get; set; }

    }
    public class RoadUpdate
    {
        public Guid Id { get; set; }

        public User UserOrder { get; set; }
        public User UserDriver { get; set; }
        public City CityStart { get; set; }
        public City CityEnd { get; set; }

    }
}
