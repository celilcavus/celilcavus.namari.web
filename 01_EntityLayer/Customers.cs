namespace _01_EntityLayer
{
    public class Customers
    {
        public int Id { get; set; }
        public String? Image { get; set; }
        public String? Description { get; set; }
        public String? FirstName { get; set; } = "";
        public String? LastName { get; set; } = "";
        public String? FullName => $"{FirstName} {LastName}";
    }
}
