namespace RentItEasy.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Rating
    {
        public Rating()
        {
            this.VotedUsers = new HashSet<UserRating>();
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal RatingSum { get; set; } = 0;

        public int CountOfVotes { get; set; } = 0;

        public decimal AverageRating { get; set; } = 0;

        public HashSet<UserRating> VotedUsers { get; set; }
    }
}
