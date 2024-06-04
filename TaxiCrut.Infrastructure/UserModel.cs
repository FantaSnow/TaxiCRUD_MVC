namespace TaxiCrut.Infrastructure

{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "None";
        public string SurName { get; set; } = "None";
        public string NumberPhone { get; set; } = "None";
        public string Email { get; set; } = "None";

    }
    public class UserCreate
    {
        public string Name { get; set; } = "None";
        public string SurName { get; set; } = "None";
        public string NumberPhone { get; set; } = "None";
        public string Email { get; set; } = "None";

    }
    public class UserUpdate
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "None";
        public string SurName { get; set; } = "None";
        public string NumberPhone { get; set; } = "None";
        public string Email { get; set; } = "None";

    }
}
