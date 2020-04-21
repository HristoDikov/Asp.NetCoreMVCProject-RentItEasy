namespace RentItEasy.Data.Models
{
    using System;
    public class UserRating
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }

        public string RatingId { get; set; }
        public Rating Rating { get; set; }
    }
}
