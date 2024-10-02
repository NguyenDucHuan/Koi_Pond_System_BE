using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.DataAccess.Repository.Interfaces;
using KPOCOS.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace KPCOS.DataAccess.Repository.Implemnts
{
    public class RatingService : IRatingService
    {
        private readonly KpcosdbContext _context;

        public RatingService(KpcosdbContext context)
        {
            _context = context;
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            var ratingadd = await _context.Ratings.FirstOrDefaultAsync(rate => rate.AccountId == rating.AccountId && rate.OrderItemId == rating.OrderItemId);
            if (ratingadd != null)
            {
                throw new Exception("Rating have exist");
            }
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
            return rating;
        }

        public async Task DeleteRatingAsync(int ratingId)
        {
            var rating = await _context.Ratings.FindAsync(ratingId);
            if (rating == null)
            {
                throw new Exception("Rating not found");
            }
            _context.Ratings.Remove(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<Rating> GetRatingAsync(int ratingId)
        {
            var rating = await _context.Ratings.FindAsync(ratingId);
            if (rating == null)
            {
                return null;
            }
            return rating;
        }

        public async Task<List<Rating>> GetRatingsAsync()
        {
            var ratings = await _context.Ratings.ToListAsync();
            if (ratings == null)
            {
                return null;
            }
            return ratings;
        }

        public async Task<Rating> UpdateRatingAsync(Rating rating)
        {
            var rating3 = await _context.Ratings.FindAsync(rating.RatingId);
            if (rating3 == null)
            {
                throw new Exception("Rating not found");
            }
            _context.Ratings.Update(rating);
            await _context.SaveChangesAsync();
            return rating;
        }
    }
}