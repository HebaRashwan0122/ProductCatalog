namespace ProductCatalog.Service.ViewModels
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? DurationInHours { get; set; }
        public double Price { get; set; }
        public byte[] Img { get; set; }
    }
}
