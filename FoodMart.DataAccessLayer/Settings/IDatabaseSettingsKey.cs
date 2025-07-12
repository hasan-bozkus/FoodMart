namespace FoodMart.DataAccessLayer.Settings
{
    public interface IDatabaseSettingsKey
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string FeatureCollectionName { get; set; }
        public string DiscountCollectionName { get; set; }
        public string PeopleViewingCollectionName { get; set; }
        public string AdminCollectionName { get; set; }
    }
}