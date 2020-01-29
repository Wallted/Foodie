namespace Foodie.Models
{
    public class Ingriedient
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
        public Meal Meal { get; set; }
    }
}