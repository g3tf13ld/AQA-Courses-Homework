namespace Homework3.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Address => $"{Country}, {City}, {Street}";
    }
}