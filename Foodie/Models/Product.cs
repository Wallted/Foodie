namespace Foodie.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbs { get; set; }
        public bool IsLiquid { get; set; }
    }
}