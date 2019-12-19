using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AirBNB.Models;
using AirBNB.DAL;

namespace AirBNB.Controllers
{
    public class ListingsController : Controller
    {
        //private readonly AirBNBContext _context;
        private UnitOfWork unitOfWork;

        public ListingsController(AirBNBContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        // GET: Listings
        public async Task<IActionResult> Index()
        {
            return View(unitOfWork.Listings.GetAll());
        }

        // GET: Listings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = unitOfWork.Listings.Get((int)id);

            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // GET: Listings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Listings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ListingUrl,ScrapeId,LastScraped,Name,Summary,Space,Description,ExperiencesOffered,NeighborhoodOverview,Notes,Transit,Access,Interaction,HouseRules,ThumbnailUrl,MediumUrl,PictureUrl,XlPictureUrl,HostId,HostUrl,HostName,HostSince,HostLocation,HostAbout,HostResponseTime,HostResponseRate,HostAcceptanceRate,HostIsSuperhost,HostThumbnailUrl,HostPictureUrl,HostNeighbourhood,HostListingsCount,HostTotalListingsCount,HostVerifications,HostHasProfilePic,HostIdentityVerified,Street,Neighbourhood,NeighbourhoodCleansed,NeighbourhoodGroupCleansed,City,State,Zipcode,Market,SmartLocation,CountryCode,Country,Latitude,Longitude,IsLocationExact,PropertyType,RoomType,Accommodates,Bathrooms,Bedrooms,Beds,BedType,Amenities,SquareFeet,Price,WeeklyPrice,MonthlyPrice,SecurityDeposit,CleaningFee,GuestsIncluded,ExtraPeople,MinimumNights,MaximumNights,CalendarUpdated,HasAvailability,Availability30,Availability60,Availability90,Availability365,CalendarLastScraped,NumberOfReviews,FirstReview,LastReview,ReviewScoresRating,ReviewScoresAccuracy,ReviewScoresCleanliness,ReviewScoresCheckin,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresValue,RequiresLicense,License,JurisdictionNames,InstantBookable,IsBusinessTravelReady,CancellationPolicy,RequireGuestProfilePicture,RequireGuestPhoneVerification,CalculatedHostListingsCount,ReviewsPerMonth")] Listings listings)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Listings.Add(listings);
                unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(listings);
        }

        // GET: Listings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = unitOfWork.Listings.Get((int)id);
            if (listings == null)
            {
                return NotFound();
            }
            return View(listings);
        }

        // POST: Listings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ListingUrl,ScrapeId,LastScraped,Name,Summary,Space,Description,ExperiencesOffered,NeighborhoodOverview,Notes,Transit,Access,Interaction,HouseRules,ThumbnailUrl,MediumUrl,PictureUrl,XlPictureUrl,HostId,HostUrl,HostName,HostSince,HostLocation,HostAbout,HostResponseTime,HostResponseRate,HostAcceptanceRate,HostIsSuperhost,HostThumbnailUrl,HostPictureUrl,HostNeighbourhood,HostListingsCount,HostTotalListingsCount,HostVerifications,HostHasProfilePic,HostIdentityVerified,Street,Neighbourhood,NeighbourhoodCleansed,NeighbourhoodGroupCleansed,City,State,Zipcode,Market,SmartLocation,CountryCode,Country,Latitude,Longitude,IsLocationExact,PropertyType,RoomType,Accommodates,Bathrooms,Bedrooms,Beds,BedType,Amenities,SquareFeet,Price,WeeklyPrice,MonthlyPrice,SecurityDeposit,CleaningFee,GuestsIncluded,ExtraPeople,MinimumNights,MaximumNights,CalendarUpdated,HasAvailability,Availability30,Availability60,Availability90,Availability365,CalendarLastScraped,NumberOfReviews,FirstReview,LastReview,ReviewScoresRating,ReviewScoresAccuracy,ReviewScoresCleanliness,ReviewScoresCheckin,ReviewScoresCommunication,ReviewScoresLocation,ReviewScoresValue,RequiresLicense,License,JurisdictionNames,InstantBookable,IsBusinessTravelReady,CancellationPolicy,RequireGuestProfilePicture,RequireGuestPhoneVerification,CalculatedHostListingsCount,ReviewsPerMonth")] Listings listings)
        {
            if (id != listings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var found = unitOfWork.Listings.Get(id);
                    found.Name = listings.Name;
                    found.Summary = listings.Summary;

                    unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListingsExists(listings.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listings);
        }

        // GET: Listings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listings = unitOfWork.Listings.Get((int)id);
            if (listings == null)
            {
                return NotFound();
            }

            return View(listings);
        }

        // POST: Listings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listings = unitOfWork.Listings.Get(id);
            unitOfWork.Listings.Remove(listings);
            unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        private bool ListingsExists(int id)
        {
            return unitOfWork.Listings.Get(id) != null;
        }
    }
}
