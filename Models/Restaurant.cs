namespace Restaurant_Project.Models
{
    public class Restaurant
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Rating { get; set; }
        public int? MenuID { get; set; }
        public Menu? Menu { get; set; }
        public int? ChefID { get; set; }
        public Chef? Chef { get; set; }
    }
}
