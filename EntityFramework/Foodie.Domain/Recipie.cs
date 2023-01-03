namespace Foodie.Domain
{
    public class Recipie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int RecipieRatingId { get; set; }

        public RecipieRating RecipieRating { get; set; }

        public ICollection<Ingridient> Ingridients { get; set; }

        public ICollection<RecipieMetaTag> RecipieMetaTags { get; set; }
    }
}