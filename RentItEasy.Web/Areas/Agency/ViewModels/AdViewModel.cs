namespace RentItEasy.Areas.User.ViewModels
{
    public class AdViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string MinimizedDescription
        {
            get => Description.Length > 20
                   ? Description.Substring(0, 19) + "..."
                   : Description;
        }

        public string Path { get; set; }
    }
}
