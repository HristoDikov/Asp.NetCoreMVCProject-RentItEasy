﻿namespace RentItEasy.Areas.User.Controllers
{
    using global::RentItEasy.Areas.User.ViewModels;
    using global::RentItEasy.Common;
    using global::RentItEasy.Services.Contracts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Area(GlobalConstants.userRoleName)]
    [Authorize(Roles = GlobalConstants.userRoleName)]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        { 
            this.profileService = profileService;
        }

        public IActionResult ViewAgencies()
        {
            var agencies = profileService.GetAgencies();
            var minAgencies = new List<MinimizedAgencyProfile>();

            foreach (var agency in agencies)
            {
                var minAgency = new MinimizedAgencyProfile
                {
                    Id = agency.Id,
                    Name = agency.Name,
                    Description = agency.Description,
                    Rating = agency.Rating == null ? "No rating yet" : agency.Rating.AverageRating.ToString(),
                };

                minAgencies.Add(minAgency);
            }

            return this.View(minAgencies);
        }

        public IActionResult Details(string id)
        {
            var agency = profileService.GetAgencyById(id);

            var agencyDetails = new AgencyProfileViewModel
            {
                Id = agency.Id,
                Name = agency.Name,
                Description = agency.Description,
                Address = agency.Address,
                PhoneNumber = agency.PhoneNumber,
                Rating = agency.Rating,
            };
            
            return this.View(agencyDetails);
        }

        [HttpPost]
        public IActionResult Details(string agencyId, decimal rateDigit)
        {
            var currentUserUsername = this.User.Identity.Name;

            var userProfile = this.profileService.GetUserByUsername(currentUserUsername);

            var agencyProfile = this.profileService.GetAgencyById(agencyId);

            this.profileService.Rate(userProfile, agencyProfile, rateDigit);

            return this.Details(agencyId);
        }
    }
}
