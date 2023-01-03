namespace Foodie.Domain
{
    public class MetaTag
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<RecipieMetaTag> RecipieMetaTags { get; set; }
    }
}