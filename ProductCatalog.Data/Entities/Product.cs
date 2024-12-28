namespace ProductCatalog.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int? DurationInHours { get; set; }
        public double Price { get; set; }
        public byte[] Img { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
