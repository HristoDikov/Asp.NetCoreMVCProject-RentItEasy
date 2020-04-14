﻿namespace RentItEasy.Services
{
    using Microsoft.EntityFrameworkCore;
    using RentItEasy.Data;
    using RentItEasy.Data.Models;
    using RentItEasy.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdService : IAdService
    {
        private readonly ApplicationDbContext db;

        public AdService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task CreateAd(string userName, string title, string description, IEnumerable<string> stringImagesPaths, string propertyType,
            string size, string location, string rentPrice, string buildingClass)
        {
            var user = this.db.Users
                 .Include(x => x.UserProfile)
                .FirstOrDefault(x => x.UserName == userName);

            var ad = new Ad
            {
                Title = title,
                Description = description,
                PropertyType = Enum.Parse<PropertyType>(propertyType),
                BuildingClass = Enum.Parse<BuildingClass>(buildingClass),
                Size = size,
                Location = location,
                RentPrice = rentPrice,
                UserProfileId = user.UserProfileId,
            };

            var imagesPathsToBeAdded = CreateImagePath(stringImagesPaths, ad);

            ad.ImagesPaths = imagesPathsToBeAdded;

            await this.db.Ads.AddAsync(ad);
            await this.db.SaveChangesAsync();
        }

        public IEnumerable<ImagePath> CreateImagePath(IEnumerable<string> imagesPaths, Ad ad)
        {
            var imagesPathsAsList = imagesPaths.ToList();
            var createdImagesPaths = new List<ImagePath>();

            for (int i = 0; i < imagesPaths.Count(); i++)
            {
                var imagePath = new ImagePath();

                imagePath.Path = imagesPathsAsList[i];
                imagePath.Id = ad.Id;
                imagePath.Ad = ad;

                createdImagesPaths.Add(imagePath);
            }

            return createdImagesPaths;
        }
        public IEnumerable<Ad> GetTenOfMostVisitedAds()
        {
            var ads = this.db.Ads.Select(a => new Ad
            {
                Title = a.Title,
                Description = a.Description,
            })
                .ToList();

            return ads;
        }
    }
}
