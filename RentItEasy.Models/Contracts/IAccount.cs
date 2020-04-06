
namespace RentItEasy.Models.Contracts
{
    using System;

    public interface IAccount
    {
        string Id { get; set; }

        DateTime CreatedOn { get; set; }
    }
}
