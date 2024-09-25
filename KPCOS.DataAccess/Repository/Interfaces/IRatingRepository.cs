using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KPOCOS.Domain.Models;

namespace KPCOS.DataAccess.Repository.Interfaces
{
    public interface IRatingService
    {
        Task<List<Rating>> GetRatingsAsync();
        Task<Rating> GetRatingAsync(int ratingId);
        Task<Rating> AddRatingAsync(Rating rating);
        Task<Rating> UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(int ratingId);
    }
}