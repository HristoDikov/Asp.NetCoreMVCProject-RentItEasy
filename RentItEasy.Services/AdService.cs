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
            var user = this.db.AgenciesProfiles
                .FirstOrDefault(x => x.Username == userName);

            var ad = new Ad
            {
                Title = title,
                Description = description,
                PropertyType = Enum.Parse<PropertyType>(propertyType),
                BuildingClass = Enum.Parse<BuildingClass>(buildingClass),
                Size = size,
                Location = location,
                RentPrice = rentPrice,
                CreatedOn = DateTime.UtcNow,
                AgencyProfileId = user.Id,
            };

            var imagesPathsToBeAdded = CreateImagePath(stringImagesPaths, ad);

            ad.ImagesPaths = imagesPathsToBeAdded;

            await this.db.Ads.AddAsync(ad);
            await this.db.SaveChangesAsync();
        }

        private IEnumerable<ImagePath> CreateImagePath(IEnumerable<string> imagesPaths, Ad ad)
        {
            var imagesPathsAsList = imagesPaths.ToList();
            var createdImagesPaths = new List<ImagePath>();

            for (int i = 0; i < imagesPaths.Count(); i++)
            {
                var imagePath = new ImagePath
                {
                    Path = imagesPathsAsList[i],
                    Id = ad.Id,
                    Ad = ad
                };

                createdImagesPaths.Add(imagePath);
            }

            return createdImagesPaths;
        }

        public Ad GetAd(int id)
        {
            var ad = this.db.Ads
                .Select(a => new Ad
                {
                    Id = a.Id,
                    Title = a.Title,
                    Description = a.Description,
                    RentPrice = a.RentPrice,
                    BuildingClass = a.BuildingClass,
                    Location = a.Location,
                    PropertyType = a.PropertyType,
                    Size = a.Size,
                    CreatedOn = a.CreatedOn,
                    AgencyProfileId = a.AgencyProfile.Id,
                    ImagesPaths = a.ImagesPaths.Select(ip => new ImagePath
                    {
                        Path = ip.Path,
                    })
                    .ToList(),
                    AgencyProfile = new AgencyProfile
                    {
                        Username = a.AgencyProfile.Username,
                    },
                })
                .FirstOrDefault(a => a.Id == id);

            return ad;
        }

        public IEnumerable<Ad> GetSixAds()
        {
            var ads = this.db.Ads
                 .Select(a => new Ad
                 {
                     Title = a.Title,
                     Description = a.Description,
                     Id = a.Id,
                     CreatedOn = a.CreatedOn,
                     ImagesPaths = a.ImagesPaths.Select(ip => new ImagePath
                     {
                         Path = ip.Path,
                     })
                    .ToList(),
                 })
                .ToList()
                .Take(6);

            return ads;
        }

        public IEnumerable<Ad> GetAllAds(int? take = null, int skip = 0)
        {
            var ads = this.db.Ads
                .Select(a => new Ad
                {
                    Title = a.Title,
                    Description = a.Description,
                    Id = a.Id,
                    CreatedOn = a.CreatedOn,
                    ImagesPaths = a.ImagesPaths.Select(ip => new ImagePath
                    {
                        Path = ip.Path,
                    })
                    .ToList(),
                })
                .OrderByDescending(x => x.CreatedOn)
                .ToList()
                .Skip(skip);

            if (take.HasValue)
            {
                ads = ads.Take(take.Value).ToList();
            }

            return ads;
        }

        public IEnumerable<Ad> GetAgencyAds(string name, int? take = null, int skip = 0)
        {
            var ads = this.db.Ads
                .Where(a => a.AgencyProfile.Username == name)
                .Select(a => new Ad
                {
                    Title = a.Title,
                    Description = a.Description,
                    Id = a.Id,
                    CreatedOn = a.CreatedOn,
                    ImagesPaths = a.ImagesPaths.Select(ip => new ImagePath
                    {
                        Path = ip.Path,
                    })
                    .ToList(),
                })
                .OrderByDescending(a => a.CreatedOn)
                .ToList()
                .Skip(skip);


            if (take.HasValue)
            {
                ads = ads.Take(take.Value).ToList();
            }

            return ads;
        }

        public async Task EditAd(int id, string title, string description, string propertyType,
            string size, string location, string rentPrice, string buildingClass)
        {
            var ad = this.db.Ads
                .Where(a => a.Id == id)
                .Select(a => a)
                .FirstOrDefault();

            ad.Title = title;
            ad.Description = description;
            ad.PropertyType = Enum.Parse<PropertyType>(propertyType);
            ad.Size = size;
            ad.Location = location;
            ad.RentPrice = rentPrice;
            ad.BuildingClass = Enum.Parse<BuildingClass>(buildingClass);

            await this.db.SaveChangesAsync();
        }

        public async Task DeleteAd(int id)
        {
            var ad = this.db.Ads
           .Where(a => a.Id == id)
           .Select(a => a)
           .FirstOrDefault();

            this.db.Ads.Remove(ad);

            await this.db.SaveChangesAsync();
        }

        public int GetAdsCount()
        {
            return this.db.Ads.Count();
        }

        public int GetAdsByAgencyCount(string username)
        {
            return this.db.Ads
                .Select(a => a.AgencyProfile)
                .Where(a => a.Username == username)
                .Count();
        }
    }
}
