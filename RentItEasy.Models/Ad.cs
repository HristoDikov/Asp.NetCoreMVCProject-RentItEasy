namespace AspNetCoreTemplate.Data.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public int CountOfVisits { get; set; } = 0;

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }
    }
}
