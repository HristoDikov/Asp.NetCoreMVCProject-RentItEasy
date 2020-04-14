namespace RentItEasy.Data.Models
{
    public class ImagePath
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public int AdId { get; set; }

        public virtual Ad Ad { get; set; }
    }
}
