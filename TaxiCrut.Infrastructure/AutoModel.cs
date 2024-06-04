namespace TaxiCrut.Infrastructure
{
    public class AutoModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Number { get; set; }

    }
    public class AutoCreate
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    public class AutoUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public int Number { get; set; }
    }
}
