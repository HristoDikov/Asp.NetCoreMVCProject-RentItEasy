
namespace RentItEasy.Models.Contracts
{
    using System;

    public interface IProfile
    {
        string Id { get; set; }

        DateTime CreatedOn { get; set; }
    }
}
