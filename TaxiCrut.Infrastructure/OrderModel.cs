    using TaxiCrudCore.Entities;

    namespace TaxiCrut.Infrastructure

    {
        public class OrderModel
        {
            public Guid Id { get; set; }
            public double Cost { get; set; }
            public Road Road { get; set; }
            public Status Status { get; set; }

        }
        public class OrderCreate
        {
            public double Cost { get; set; }
            public Road Road { get; set; }
            public Status Status { get; set; }

        }
        public class OrderUpdate
        {
        public Guid Id { get; set; }

        public double Cost { get; set; }
            public Road Road { get; set; }
            public Status Status { get; set; }

        }
    }
