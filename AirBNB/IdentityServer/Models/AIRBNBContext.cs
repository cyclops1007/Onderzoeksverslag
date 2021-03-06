﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IdentityServer.Models
{
    public partial class AIRBNBContext : DbContext
    {
        public AIRBNBContext(DbContextOptions<AIRBNBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Calendar> Calendar { get; set; }
        public virtual DbSet<Listings> Listings { get; set; }
        public virtual DbSet<Neighbourhoods> Neighbourhoods { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Calendar>(entity =>
            {
                entity.ToTable("calendar");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdjustedPrice)
                    .IsRequired()
                    .HasColumnName("adjusted_price")
                    .HasMaxLength(50);

                entity.Property(e => e.Available)
                    .IsRequired()
                    .HasColumnName("available")
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ListingId).HasColumnName("listing_id");

                entity.Property(e => e.MaximumNights).HasColumnName("maximum_nights");

                entity.Property(e => e.MinimumNights).HasColumnName("minimum_nights");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Listings>(entity =>
            {
                entity.ToTable("listings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Accommodates).HasColumnName("accommodates");

                entity.Property(e => e.Amenities).HasColumnName("amenities");

                entity.Property(e => e.Availability30).HasColumnName("availability_30");

                entity.Property(e => e.Availability365).HasColumnName("availability_365");

                entity.Property(e => e.Availability60).HasColumnName("availability_60");

                entity.Property(e => e.Availability90).HasColumnName("availability_90");

                entity.Property(e => e.Bathrooms).HasColumnName("bathrooms");

                entity.Property(e => e.BedType).HasColumnName("bed_type");

                entity.Property(e => e.Bedrooms).HasColumnName("bedrooms");

                entity.Property(e => e.Beds).HasColumnName("beds");

                entity.Property(e => e.CalculatedHostListingsCount).HasColumnName("calculated_host_listings_count");

                entity.Property(e => e.CalculatedHostListingsCountEntireHomes).HasColumnName("calculated_host_listings_count_entire_homes");

                entity.Property(e => e.CalculatedHostListingsCountPrivateRooms).HasColumnName("calculated_host_listings_count_private_rooms");

                entity.Property(e => e.CalculatedHostListingsCountSharedRooms).HasColumnName("calculated_host_listings_count_shared_rooms");

                entity.Property(e => e.CalendarLastScraped).HasColumnName("calendar_last_scraped");

                entity.Property(e => e.CalendarUpdated).HasColumnName("calendar_updated");

                entity.Property(e => e.CancellationPolicy).HasColumnName("cancellation_policy");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.CleaningFee).HasColumnName("cleaning_fee");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.CountryCode).HasColumnName("country_code");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ExperiencesOffered).HasColumnName("experiences_offered");

                entity.Property(e => e.ExtraPeople).HasColumnName("extra_people");

                entity.Property(e => e.FirstReview).HasColumnName("first_review");

                entity.Property(e => e.GuestsIncluded).HasColumnName("guests_included");

                entity.Property(e => e.HasAvailability).HasColumnName("has_availability");

                entity.Property(e => e.HostAbout).HasColumnName("host_about");

                entity.Property(e => e.HostAcceptanceRate).HasColumnName("host_acceptance_rate");

                entity.Property(e => e.HostHasProfilePic).HasColumnName("host_has_profile_pic");

                entity.Property(e => e.HostId).HasColumnName("host_id");

                entity.Property(e => e.HostIdentityVerified).HasColumnName("host_identity_verified");

                entity.Property(e => e.HostIsSuperhost).HasColumnName("host_is_superhost");

                entity.Property(e => e.HostListingsCount).HasColumnName("host_listings_count");

                entity.Property(e => e.HostLocation).HasColumnName("host_location");

                entity.Property(e => e.HostName).HasColumnName("host_name");

                entity.Property(e => e.HostNeighbourhood).HasColumnName("host_neighbourhood");

                entity.Property(e => e.HostPictureUrl).HasColumnName("host_picture_url");

                entity.Property(e => e.HostResponseRate).HasColumnName("host_response_rate");

                entity.Property(e => e.HostResponseTime).HasColumnName("host_response_time");

                entity.Property(e => e.HostSince).HasColumnName("host_since");

                entity.Property(e => e.HostThumbnailUrl).HasColumnName("host_thumbnail_url");

                entity.Property(e => e.HostTotalListingsCount).HasColumnName("host_total_listings_count");

                entity.Property(e => e.HostUrl).HasColumnName("host_url");

                entity.Property(e => e.HostVerifications).HasColumnName("host_verifications");

                entity.Property(e => e.HouseRules).HasColumnName("house_rules");

                entity.Property(e => e.InstantBookable).HasColumnName("instant_bookable");

                entity.Property(e => e.Interaction).HasColumnName("interaction");

                entity.Property(e => e.IsBusinessTravelReady).HasColumnName("is_business_travel_ready");

                entity.Property(e => e.IsLocationExact).HasColumnName("is_location_exact");

                entity.Property(e => e.JurisdictionNames).HasColumnName("jurisdiction_names");

                entity.Property(e => e.LastReview).HasColumnName("last_review");

                entity.Property(e => e.LastScraped).HasColumnName("last_scraped");

                entity.Property(e => e.Latitude).HasColumnName("latitude");

                entity.Property(e => e.License).HasColumnName("license");

                entity.Property(e => e.ListingUrl).HasColumnName("listing_url");

                entity.Property(e => e.Longitude).HasColumnName("longitude");

                entity.Property(e => e.Market).HasColumnName("market");

                entity.Property(e => e.MaximumMaximumNights).HasColumnName("maximum_maximum_nights");

                entity.Property(e => e.MaximumMinimumNights).HasColumnName("maximum_minimum_nights");

                entity.Property(e => e.MaximumNights).HasColumnName("maximum_nights");

                entity.Property(e => e.MaximumNightsAvgNtm).HasColumnName("maximum_nights_avg_ntm");

                entity.Property(e => e.MediumUrl).HasColumnName("medium_url");

                entity.Property(e => e.MinimumMaximumNights).HasColumnName("minimum_maximum_nights");

                entity.Property(e => e.MinimumMinimumNights).HasColumnName("minimum_minimum_nights");

                entity.Property(e => e.MinimumNights).HasColumnName("minimum_nights");

                entity.Property(e => e.MinimumNightsAvgNtm).HasColumnName("minimum_nights_avg_ntm");

                entity.Property(e => e.MonthlyPrice).HasColumnName("monthly_price");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.NeighborhoodOverview).HasColumnName("neighborhood_overview");

                entity.Property(e => e.Neighbourhood).HasColumnName("neighbourhood");

                entity.Property(e => e.NeighbourhoodCleansed).HasColumnName("neighbourhood_cleansed");

                entity.Property(e => e.NeighbourhoodGroupCleansed).HasColumnName("neighbourhood_group_cleansed");

                entity.Property(e => e.Notes).HasColumnName("notes");

                entity.Property(e => e.NumberOfReviews).HasColumnName("number_of_reviews");

                entity.Property(e => e.NumberOfReviewsLtm).HasColumnName("number_of_reviews_ltm");

                entity.Property(e => e.PictureUrl).HasColumnName("picture_url");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.PropertyType).HasColumnName("property_type");

                entity.Property(e => e.RequireGuestPhoneVerification).HasColumnName("require_guest_phone_verification");

                entity.Property(e => e.RequireGuestProfilePicture).HasColumnName("require_guest_profile_picture");

                entity.Property(e => e.RequiresLicense).HasColumnName("requires_license");

                entity.Property(e => e.ReviewScoresAccuracy).HasColumnName("review_scores_accuracy");

                entity.Property(e => e.ReviewScoresCheckin).HasColumnName("review_scores_checkin");

                entity.Property(e => e.ReviewScoresCleanliness).HasColumnName("review_scores_cleanliness");

                entity.Property(e => e.ReviewScoresCommunication).HasColumnName("review_scores_communication");

                entity.Property(e => e.ReviewScoresLocation).HasColumnName("review_scores_location");

                entity.Property(e => e.ReviewScoresRating).HasColumnName("review_scores_rating");

                entity.Property(e => e.ReviewScoresValue).HasColumnName("review_scores_value");

                entity.Property(e => e.ReviewsPerMonth).HasColumnName("reviews_per_month");

                entity.Property(e => e.RoomType).HasColumnName("room_type");

                entity.Property(e => e.ScrapeId).HasColumnName("scrape_id");

                entity.Property(e => e.SecurityDeposit).HasColumnName("security_deposit");

                entity.Property(e => e.SmartLocation).HasColumnName("smart_location");

                entity.Property(e => e.Space).HasColumnName("space");

                entity.Property(e => e.SquareFeet).HasColumnName("square_feet");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Street).HasColumnName("street");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.ThumbnailUrl).HasColumnName("thumbnail_url");

                entity.Property(e => e.Transit).HasColumnName("transit");

                entity.Property(e => e.WeeklyPrice).HasColumnName("weekly_price");

                entity.Property(e => e.XlPictureUrl).HasColumnName("xl_picture_url");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Neighbourhoods>(entity =>
            {
                entity.ToTable("neighbourhoods");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Neighbourhood)
                    .IsRequired()
                    .HasColumnName("neighbourhood")
                    .HasMaxLength(50);

                entity.Property(e => e.NeighbourhoodGroup)
                    .HasColumnName("neighbourhood_group")
                    .HasMaxLength(1);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.ToTable("reviews");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnName("date");

                entity.Property(e => e.ListingId).HasColumnName("listing_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
