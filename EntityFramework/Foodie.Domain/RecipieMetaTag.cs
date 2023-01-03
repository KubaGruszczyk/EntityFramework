namespace Foodie.Domain
{
    public class RecipieMetaTag
    {
        public int Id { get; set; }

        public int RecipieId { get; set; }

        public Recipie Recipie { get; set; }

        public int MetaTagId { get; set; }

        public MetaTag MetaTag { get; set; }
    }
}