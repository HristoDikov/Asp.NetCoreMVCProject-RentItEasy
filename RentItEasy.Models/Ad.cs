namespace AspNetCoreTemplate.Data.Models
{
    public class Ad
    {
        public int Id { get; set; }

        public int CountOfVisits { get; set; } = 0;

        public int PropertyId { get; set; }

        public Property Property { get; set; }
    }
}
