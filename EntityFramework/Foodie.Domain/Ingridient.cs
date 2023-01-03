namespace Foodie.Domain
{
    public class Ingridient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public int RecipieId { get; set; }

        public Recipie Recipie { get; set; }
    }
}