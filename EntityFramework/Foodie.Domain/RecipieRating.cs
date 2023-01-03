namespace Foodie.Domain
{
    public class RecipieRating
    {
        public int Id { get; set; }

        public double? Rating { get; set; }

        public DateTime LastUpdateTime { get; set; } = DateTime.Now;

        public int RecipieId { get; set; }

        public Recipie Recipie { get; set; }
    }
}