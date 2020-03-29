namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Rating
    {
        public Rating()
        {
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public decimal RatingSum { get; set; } = 0;

        public int CountOfVotes { get; set; } = 0;
    }
}
