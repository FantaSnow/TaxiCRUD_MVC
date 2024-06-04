namespace TaxiCrut.Infrastructure

{
    public class StatusModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

    }
    public class StatusCreate
    {
        public string Name { get; set; }

    }
    public class StatusUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
